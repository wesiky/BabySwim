using System;
using ESPlus.Application.FileTransfering.Server;
using OAUS.Core;
using ESPlus.Serialization;
using ESPlus.FileTransceiver;
using ESPlus.Application.FileTransfering;
using ESPlus.Application.CustomizeInfo;

namespace OAUS.Server
{
    class CustomizeHandler : ICustomizeHandler
    {
        private IFileController fileController;
        private UpdateConfiguration fileConfig;

        public void Initialize(IFileController _fileController, UpdateConfiguration _fileConfig)
        {
            this.fileController = _fileController;
            this.fileConfig = _fileConfig;

            this.fileController.FileRequestReceived += new CbFileRequestReceived(fileController_FileRequestReceived);
        }

        void fileController_FileRequestReceived(string projectID, string senderID, string fileName, ulong totalSize, ResumedProjectItem resumedFileItem, string savePath)
        {
            //准备开始接受文件
            this.fileController.BeginReceiveFile(projectID, savePath);
        }

        /// <summary>
        /// 处理接收到的信息（包括大数据快信息）
        /// </summary>
        /// <param name="sourceUserID"></param>
        /// <param name="informationType"></param>
        /// <param name="info"></param>
        public void HandleInformation(string sourceUserID, int informationType, byte[] info)
        {
            if (informationType == InformationTypes.DownloadFiles)
            {
                DownloadFileContract contract = CompactPropertySerializer.Default.Deserialize<DownloadFileContract>(info, 0);

                string fileID;
                string filePath = string.Format("{0}FileFolder\\{1}", AppDomain.CurrentDomain.BaseDirectory, contract.FileName);
                this.fileController.BeginSendFile(sourceUserID, filePath, contract.FileName, out fileID);

            }
        }

        /// <summary>
        /// 处理接受到的请求并返回应答信息
        /// </summary>
        /// <param name="sourceUserID"></param>
        /// <param name="informationType"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public byte[] HandleQuery(string sourceUserID, int informationType, byte[] info)
        {
            //获取服务器最新文件信息
            if (informationType == InformationTypes.GetAllFilesInfo)
            {
                FilesInfoContract contract = new FilesInfoContract();
                contract.AllFileInfoList = this.fileConfig.FileList;
                return CompactPropertySerializer.Default.Serialize<FilesInfoContract>(contract);
            }
            //获取服务器最新版本号
            if (informationType == InformationTypes.GetLastUpdateTime)
            {
                LastUpdateTimeContract contract = new LastUpdateTimeContract(this.fileConfig.ClientVersion);                
                return CompactPropertySerializer.Default.Serialize<LastUpdateTimeContract>(contract);
            }
            return null;
        }
    }
}
