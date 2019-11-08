using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESBasic;
using AutoUpdater.Properties;
using ESBasic.Helpers;
using System.Runtime.InteropServices;

namespace AutoUpdater
{
    /// <summary>
    /// 说明：
    /// OAUS使用的是免费版的通信框架ESFramework，最多支持10个人同时在线更新。如果要突破10人限制，请联系 www.oraycn.com
    /// </summary>
    public partial class MainForm : Form
    {
        private const int SW_SHOWNOMAL = 1;
        private Updater updater;    
        private int fileCount = 0; //要升级的文件个数。
        private Timer timer = new Timer();
        private string callBackExeName;   //自动升级完成后，要启动的exe的名称。
        private string callBackPath = ""; //自动升级完成后，要启动的exe的完整路径。        
        private bool startAppAfterClose = false; //关闭升级窗体前，是否启动应用程序。

        ///<summary>
        /// 该函数设置由不同线程产生的窗口的显示状态
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表，请查阅ShowWlndow函数的说明部分</param>
        /// <returns>如果函数原来可见，返回值为非零；如果函数原来被隐藏，返回值为零</returns>
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);


        /// <summary>
        ///  该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。
        ///  系统给创建前台窗口的线程分配的权限稍高于其他线程。 
        /// </summary>
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄</param>
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零</returns>
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public MainForm(string serverIP, int serverPort, string _callBackExeName, string title)
        {
            InitializeComponent();
            this.updater = new Updater(serverIP, serverPort);
            this.updater.ToBeUpdatedFilesCount += new CbGeneric<int>(updater_ToBeUpdatedFilesCount);
            this.updater.UpdateStarted += new CbGeneric(updater_UpdateStarted);
            this.updater.FileToBeUpdated += new CbGeneric<int, string, ulong>(updater_FileToBeUpdated);
            this.updater.CurrentFileUpdatingProgress += new CbGeneric<ulong, ulong>(updater_CurrentFileUpdatingProgress);
            this.updater.UpdateDisruptted += new CbGeneric<string>(updater_UpdateDisruptted);
            this.updater.UpdateCompleted += new CbGeneric(updater_UpdateCompleted);
            this.updater.ConnectionInterrupted += new CbGeneric(updater_ConnectionInterrupted);
            this.updater.UpdateContinued += new CbGeneric(updater_UpdateContinued);

            this.timer.Interval = 1000;
            this.timer.Tick += new EventHandler(timer_Tick);
           
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);           
            this.callBackExeName = _callBackExeName;
            this.callBackPath = dir.FullName + "\\" + this.callBackExeName; //自动升级完成后，要启动的exe的完整路径。（1）被分发的程序的可执行文件exe必须位于部署目录的根目录。（2）OAUS的客户端（即整个AutoUpdater文件夹)也必须位于这个根目录。
            this.Text = title;
            this.label1.Text = Resources.InitialInformation;

            this.progressBar1.Visible = false;

            this.updater.Start();
                       
        }

        void updater_UpdateContinued()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric(this.updater_UpdateContinued));
            }
            else
            {
                //this.label_reconnect.Visible = false;
                this.label_reconnect.Text = "重连成功，正在续传...";
            }
        }

        void updater_ConnectionInterrupted()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric(this.updater_ConnectionInterrupted));
            }
            else
            {
                this.label_reconnect.Visible = true;
                this.label_reconnect.Text = "连接断开，正在重连中...";
            }
        }

        void updater_UpdateCompleted()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric(this.updater_UpdateCompleted));
            }
            else
            {
                this.label1.Text = Resources.UpdateSuccess;
                this.timer.Start();
            }
        }

        void updater_UpdateDisruptted(string disrupttedType)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CbGeneric<string>(updater_UpdateDisruptted), disrupttedType);
            }
            else
            {
                this.label1.Text = Resources.UpdateFailed;              
                this.label1.ForeColor = Color.Red;                
                MessageBox.Show(Resources.ConnectionInterrupted);
                this.startAppAfterClose = false;
                this.Close();
            }
        }

        void updater_CurrentFileUpdatingProgress(ulong total, ulong transfered)
        {
            this.SetProgress(total, transfered);
        }

        void updater_FileToBeUpdated(int fileIndex, string fileName, ulong fileSize)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CbGeneric<int, string, ulong>(updater_FileToBeUpdated), fileIndex, fileName, fileSize);
            }
            else
            {
                this.label1.Text = string.Format("{0}{1}{2}{3}{4}", Resources.Updateing_string1, this.fileCount, Resources.Updateing_string2, fileIndex + 1, Resources.Updateing_string3);
                this.label2.Text = fileName;
            }
        }

        void updater_UpdateStarted()
        {
            this.ShowMessage(2);
        }

        void updater_ToBeUpdatedFilesCount(int needUpdatedFileCount)
        {
            this.fileCount = needUpdatedFileCount;
            if (needUpdatedFileCount == 0)
            {
                this.ShowMessage(1);
            }
        }      

        private void ShowMessage(int messageType)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<int>(this.ShowMessage), messageType);
            }
            else
            {
                string message = "";
                if (messageType == 1)
                {
                    message = Resources.NoFileNeedUpdate;
                    this.startAppAfterClose = true;
                    this.Close();  
                    //this.timer.Start();
                }
                if (messageType == 2)
                {
                    message = string.Format("{0}{1}{2}", Resources.NeedUpdate_string1, this.fileCount, Resources.NeedUpdate_string2);
                    this.progressBar1.Visible = true;
                }
                if (messageType == 3)
                {
                    MessageBox.Show(Resources.ConnectionInterrupted);
                    this.startAppAfterClose = false;
                    this.Close();                    
                }

                this.label1.Text = message;
            }
        }       
       
        void timer_Tick(object sender, EventArgs e)
        {
            this.TimeUp();
        }

        private void TimeUp()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric(this.TimeUp));
            }
            else
            {
                this.startAppAfterClose = true;
                this.timer.Stop();
                this.Close();  
            }
        }       

        #region SetProgress
        private DateTime lastShowTime = DateTime.Now;
        /// <summary>
        /// 设置UI显示的进度表。
        /// </summary>       
        private void SetProgress(ulong total, ulong transmitted)
        {
            if (this.InvokeRequired)
            {
                object[] args = { total, transmitted };
                this.BeginInvoke(new CbGeneric<ulong, ulong>(this.SetProgress), args);
            }
            else
            {
                this.progressBar1.Maximum = 1000;
                this.progressBar1.Value = (int)(transmitted * 1000 / total);

                TimeSpan span = DateTime.Now - this.lastShowTime;
                if (span.TotalSeconds >= 1)
                {
                    this.lastShowTime = DateTime.Now;
                    this.label_progress.Text = string.Format("{0}/{1}", PublicHelper.GetSizeString(transmitted), PublicHelper.GetSizeString(total));
                }
            }
        }    
        #endregion     

        #region MainForm_FormClosing
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string processName = this.callBackExeName.Substring(0, this.callBackExeName.Length - 4);
                ESBasic.Helpers.ApplicationHelper.ReleaseAppInstance(processName);

                if (!this.startAppAfterClose)
                {
                    return;
                }

                if (File.Exists(this.callBackPath))
                {
                    System.Diagnostics.Process myProcess = System.Diagnostics.Process.Start(this.callBackPath);
                    ShowWindowAsync(myProcess.MainWindowHandle, SW_SHOWNOMAL);//显示
                    SetForegroundWindow(myProcess.MainWindowHandle);//当到最前端
                }                
            }
            catch (Exception ee)
            {             
                MessageBox.Show(ee.Message);
            }
        }   
        #endregion              
    }
}
