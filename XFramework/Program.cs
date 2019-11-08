using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XFramework
{
    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin = new FrmLogin();
            Application.Run(frmLogin);
        }

        public static FrmLogin frmLogin;
        public static FrmMain frmMain;
    }
}
