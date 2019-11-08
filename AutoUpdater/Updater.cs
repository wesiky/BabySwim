using System;
using System.Collections.Generic;
using System.Text;
using ESBasic;
using OAUS.Core;
using ESPlus.Rapid;
using ESPlus.Serialization;
using ESPlus.FileTransceiver;
using System.IO;
using ESBasic.Loggers;
using ESPlus.Application.Basic;
using System.Threading;

namespace AutoUpdater
{
    public class Updater
    {
        private FileAgileLogger logger = new FileAgileLogger(AppDomain.CurrentDomain.BaseDirectory + "UpdateLog.txt");
        private IRapidPassiveEngine rapidPassiveEngine;
        private UpdateConfiguration updateConfiguration = new UpdateConfiguration();
        private int fileCount = 0; //要升级的文件个数。
        private int haveUpgradeCount = 0; //已经升级的文件个数。       
        private IList<FileUnit> removedFileList; //将被删除的文件个数。
        private IList<string> downLoadFileRelativeList; //需要升级的所有文件的相对路径 的列表。
        private string appDirPath;

        public event CbGeneric<int> ToBeUpdatedFilesCount;
        public event CbGeneric UpdateStarted;
        public event CbGeneric<int, string, ulong> FileToBeUpdated;
        public event CbGeneric<ulong, ulong> CurrentFileUpdatingProgress;
        public event CbGeneric<string> UpdateDisruptted;
        public event CbGeneric UpdateCompleted;
        public event CbGeneric ConnectionInterrupted;
        /// <summary>
        /// 重连成功后，开始续传。
        /// </summary>
        public event CbGeneric UpdateContinued;

        public Updater(string serverIP, int serverPort)
        {
            this.UpdateStarted += new CbGeneric(Updater_UpdateStarted);
            this.UpdateDisruptted += new CbGeneric<string>(Updater_UpdateDisruptted);
            this.UpdateCompleted += new CbGeneric(Updater_UpdateCompleted);

            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            this.appDirPath = dir.FullName + "\\";

            this.rapidPassiveEngine = RapidEngineFactory.CreatePassiveEngine();
            this.rapidPassiveEngine.AutoReconnect = true;
            Random random = new Random();
            //初始化引擎并登录，返回登录结果
            bool canLogon = false;
            for (int i = 0; i < 100; i++)
            {
                string userid = random.Next(1000000).ToString("00000");
                LogonResponse logonResponse = rapidPassiveEngine.Initialize(userid, "", serverIP, serverPort, null);
                if (logonResponse.LogonResult == LogonResult.Succeed)
                {
                    canLogon = true;
                    break;
                }
            }
            if (!canLogon)
            {
                throw new Exception("连接自动更新服务器失败 !");
            }

            this.rapidPassiveEngine.ConnectionInterrupted += new CbGeneric(rapidPassiveEngine_ConnectionInterrupted);
            this.rapidPassiveEngine.RelogonCompleted += new CbGeneric<LogonResponse>(rapidPassiveEngine_RelogonCompleted);
        }

        void rapidPassiveEngine_RelogonCompleted(LogonResponse res)
        {
            if (res.LogonResult == LogonResult.Succeed)
            {               
                this.DownloadNextFile();
                this.logger.LogWithTime("重连成功，开始续传！");
                if (this.UpdateContinued != null)
                {
                    this.UpdateContinued();
                }

                return;
            }

            this.logger.LogWithTime("重连失败！");
            if (this.UpdateDisruptted != null)
            {
                this.UpdateDisruptted(FileTransDisrupttedType.SelfOffline.ToString());
            }
        }

        void rapidPassiveEngine_ConnectionInterrupted()
        {            
            if (this.ConnectionInterrupted != null)
            {
                this.ConnectionInterrupted();
            }

            this.logger.LogWithTime("连接断开，正在重连！");            
        }

        void Updater_UpdateCompleted()
        {
            this.logger.LogWithTime("更新完成！");
        }

        void Updater_UpdateDisruptted(string fileTransDisrupttedType)
        {
            this.logger.LogWithTime(string.Format("更新失败！原因：{0}。", fileTransDisrupttedType));
        }

        void Updater_UpdateStarted()
        {
            this.logger.LogWithTime(string.Format("更新开始. 共 {0} 个文件需要更新 ......", this.fileCount));
        }

        public void Start()
        {
            //配置文件中记录着各个文件的版本信息。
            if (!File.Exists(UpdateConfiguration.ConfigurationPath))
            {
                this.updateConfiguration.Save();
            }
            else
            {
                this.updateConfiguration = (UpdateConfiguration)UpdateConfiguration.Load(UpdateConfiguration.ConfigurationPath);
            }            

            //启动升级线程
            CbGeneric cb2 = new CbGeneric(this.UdpateThread);
            cb2.BeginInvoke(null, null);
        }

        /// <summary>
        /// 更新文件线程
        /// </summary>
        private void UdpateThread()
        {
            try
            {
                //获取更新信息
                this.GetUpdateInfo(out this.downLoadFileRelativeList, out this.removedFileList);
                this.fileCount = this.downLoadFileRelativeList.Count;

                if (this.ToBeUpdatedFilesCount != null)
                {
                    this.ToBeUpdatedFilesCount(this.fileCount);
                }

                if (this.fileCount == 0 && this.removedFileList.Count == 0)
                {
                    return;
                }

                if (this.UpdateStarted != null)
                {
                    this.UpdateStarted();
                }

                this.rapidPassiveEngine.FileOutter.FileRequestReceived += new ESPlus.Application.FileTransfering.CbFileRequestReceived(fileOutter_FileRequestReceived);
                this.rapidPassiveEngine.FileOutter.FileReceivingEvents.FileTransStarted += new CbGeneric<TransferingProject>(FileReceivingEvents_FileTransStarted);
                this.rapidPassiveEngine.FileOutter.FileReceivingEvents.FileTransCompleted += new ESBasic.CbGeneric<TransferingProject>(FileReceivingEvents_FileTransCompleted);
                this.rapidPassiveEngine.FileOutter.FileReceivingEvents.FileTransDisruptted += new CbGeneric<TransferingProject, FileTransDisrupttedType>(FileReceivingEvents_FileTransDisruptted);
                this.rapidPassiveEngine.FileOutter.FileReceivingEvents.FileTransProgress += new CbFileSendedProgress(FileReceivingEvents_FileTransProgress);

                if (downLoadFileRelativeList.Count > 0)
                {
                    DownloadFileContract downLoadFileContract = new DownloadFileContract();
                    downLoadFileContract.FileName = this.downLoadFileRelativeList[0];
                    //请求下载第一个文件
                    this.rapidPassiveEngine.CustomizeOutter.Send(InformationTypes.DownloadFiles, CompactPropertySerializer.Default.Serialize<DownloadFileContract>(downLoadFileContract));
                }
                else 
                {
                    //仅仅只有删除文件
                    if (this.removedFileList.Count > 0)
                    {
                        foreach (FileUnit file in this.removedFileList)
                        {
                            ESBasic.Helpers.FileHelper.DeleteFile(AppDomain.CurrentDomain.BaseDirectory + file.FileRelativePath);
                        }
                        this.updateConfiguration.Save();

                        if (this.UpdateCompleted != null)
                        {
                            this.UpdateCompleted();
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                this.logger.Log(ee, "线程AutoUpdater.Updater.UdpateThread出错", ErrorLevel.High);
                if (this.UpdateDisruptted != null)
                {
                    this.UpdateDisruptted(FileTransDisrupttedType.InnerError.ToString());
                }
            }
        }

        /// <summary>
        /// 与服务器的最新版本进行比较，获取要升级的所有文件信息。
        /// </summary>       
        private void GetUpdateInfo(out IList<string> downLoadFileNameList, out IList<FileUnit> removeFileNameList)
        {
            byte[] lastUpdateTime = rapidPassiveEngine.CustomizeOutter.Query(InformationTypes.GetLastUpdateTime, null);
            LastUpdateTimeContract lastUpdateTimeContract = CompactPropertySerializer.Default.Deserialize<LastUpdateTimeContract>(lastUpdateTime, 0);
            downLoadFileNameList = new List<string>();
            removeFileNameList = new List<FileUnit>();
            if (this.updateConfiguration.ClientVersion != lastUpdateTimeContract.ClientVersion)
            {
                //获取服务器文件版本信息列表
                byte[] fileInfoBytes = rapidPassiveEngine.CustomizeOutter.Query(InformationTypes.GetAllFilesInfo, null);
                FilesInfoContract contract = CompactPropertySerializer.Default.Deserialize<FilesInfoContract>(fileInfoBytes, 0);

                //更新现有文件
                foreach (FileUnit file in this.updateConfiguration.FileList)
                {
                    FileUnit fileAtServer = ContainsFile(file.FileRelativePath, contract.AllFileInfoList);
                    if (fileAtServer != null)
                    {
                        if (file.Version < fileAtServer.Version)
                        {
                            downLoadFileNameList.Add(file.FileRelativePath);
                        }
                    }
                    else
                    {
                        removeFileNameList.Add(file);
                    }
                }

                //下载新文件
                foreach (FileUnit file in contract.AllFileInfoList)
                {
                    FileUnit fileAtServer = ContainsFile(file.FileRelativePath, this.updateConfiguration.FileList);
                    if (fileAtServer == null)
                    {
                        downLoadFileNameList.Add(file.FileRelativePath);
                    }
                }
                this.updateConfiguration.FileList = contract.AllFileInfoList;
                this.updateConfiguration.ClientVersion = lastUpdateTimeContract.ClientVersion;
            }
        }

        /// <summary>
        /// 文件查询
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="fileObjects">文件名集</param>
        /// <returns></returns>
        private FileUnit ContainsFile(string fileName, IList<FileUnit> fileObjects)
        {
            foreach (FileUnit file in fileObjects)
            {
                if (file.FileRelativePath == fileName)
                {
                    return file;
                }
            }
            return null;
        }

        /// <summary>
        /// 服务端要发送某个新版本的文件给客户端时，准备开始接收文件。
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="senderID"></param>
        /// <param name="fileName"></param>
        /// <param name="totalSize"></param>
        /// <param name="resumedFileItem"></param>
        /// <param name="comment"></param>
        void fileOutter_FileRequestReceived(string projectID, string senderID, string fileName, ulong totalSize, ResumedProjectItem resumedFileItem, string comment)
        {
            string relativePath = comment;
            string localSavePath = AppDomain.CurrentDomain.BaseDirectory + "temp\\" + relativePath;
            this.EnsureDirectoryExist(localSavePath);

            //准备开始接收文件
            this.rapidPassiveEngine.FileOutter.BeginReceiveFile(projectID, localSavePath,true);
        }


        void FileReceivingEvents_FileTransStarted(TransferingProject transferingProject)
        {
            if (this.FileToBeUpdated != null)
            {
                this.FileToBeUpdated(this.haveUpgradeCount, transferingProject.ProjectName, transferingProject.TotalSize);
            }
        }

        void FileReceivingEvents_FileTransProgress(string fileID, ulong total, ulong transfered)
        {
            if (this.CurrentFileUpdatingProgress != null)
            {
                this.CurrentFileUpdatingProgress(total, transfered);
            }
        }

        #region FileReceivingEvents_FileTransDisruptted
        void FileReceivingEvents_FileTransDisruptted(TransferingProject transmittingFileInfo, FileTransDisrupttedType fileTransDisrupttedType)
        {
            if (fileTransDisrupttedType == FileTransDisrupttedType.SelfOffline)
            {                
                return;
            }

            //删除已经更新的文件
            string sourcePath = AppDomain.CurrentDomain.BaseDirectory + "temp\\";
            ESBasic.Helpers.FileHelper.DeleteDirectory(sourcePath);
            if (this.UpdateDisruptted != null)
            {
                this.UpdateDisruptted(fileTransDisrupttedType.ToString());
            }
        }
        #endregion

        private void DownloadNextFile()
        {
            if (this.haveUpgradeCount >= this.fileCount)
            {
                return;
            }

            DownloadFileContract downLoadFileContract = new DownloadFileContract();
            downLoadFileContract.FileName = this.downLoadFileRelativeList[this.haveUpgradeCount];
            //请求下载下一个文件
            this.rapidPassiveEngine.CustomizeOutter.Send(InformationTypes.DownloadFiles, CompactPropertySerializer.Default.Serialize<DownloadFileContract>(downLoadFileContract));
               
        }

        #region FileReceivingEvents_FileTransCompleted
        void FileReceivingEvents_FileTransCompleted(TransferingProject obj)
        {
            try
            {
                this.haveUpgradeCount++;
                if (this.haveUpgradeCount < this.fileCount)
                {
                    this.DownloadNextFile();
                }
                else //所有文件都升级完毕
                {
                    //copy文件，删除temp文件夹
                    string sourcePath = AppDomain.CurrentDomain.BaseDirectory + "temp\\";
                    foreach (string fileRelativePath in this.downLoadFileRelativeList)
                    {
                        string sourceFile = sourcePath + fileRelativePath;
                        string destFile = AppDomain.CurrentDomain.BaseDirectory + fileRelativePath;
                        this.EnsureDirectoryExist(destFile);
                        File.Copy(sourceFile, destFile, true);
                    }
                    ESBasic.Helpers.FileHelper.DeleteDirectory(sourcePath);

                    //删除多余的文件
                    foreach (FileUnit file in this.removedFileList)
                    {
                        ESBasic.Helpers.FileHelper.DeleteFile(AppDomain.CurrentDomain.BaseDirectory + file.FileRelativePath);
                    }
                    this.updateConfiguration.Save();

                    if (this.UpdateCompleted != null)
                    {
                        this.UpdateCompleted();
                    }
                }
            }
            catch (Exception ee)
            {
                this.logger.Log(ee, "线程AutoUpdater.Updater.UdpateThread出错", ErrorLevel.High);
                if (this.UpdateDisruptted != null)
                {
                    this.UpdateDisruptted(FileTransDisrupttedType.InnerError.ToString());
                }
            }
        }
        #endregion

        private void EnsureDirectoryExist(string filePath)
        {
            int index = filePath.LastIndexOf("\\");
            string dir = filePath.Substring(0, index + 1);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
