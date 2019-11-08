using System;
using System.Collections.Generic;
using System.Text;

namespace OAUS.Core
{
    /// <summary>
    /// 文件信息
    /// </summary>
    public class FileUnit :IComparable<FileUnit>
    {
        public FileUnit() { }
        public FileUnit(string file, float ver ,int size ,DateTime updateTime)
        {
            this.fileRelativePath = file;
            this.version = ver;
            this.fileSize = size;
            this.lastUpdateTime = updateTime;
        }

        #region 文件相对路径
        private string fileRelativePath;
        public string FileRelativePath
        {
            get { return fileRelativePath; }
            set { fileRelativePath = value; }
        } 
        #endregion

        #region 文件大小
        private int fileSize = 0;
        public int FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        } 
        #endregion

        #region 最后更新时间
        private DateTime lastUpdateTime = DateTime.Now;
        public DateTime LastUpdateTime
        {
            get { return lastUpdateTime; }
            set { lastUpdateTime = value; }
        } 
        #endregion

        #region 版本号
        private float version;
        public float Version
        {
            get { return version; }
            set { version = value; }
        } 
        #endregion

        /// <summary>
        /// 使用相对路径判断文件是否相同
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            FileUnit unit = obj as FileUnit;
            if (unit == null)
            {
                return false;
            }

            return this.fileRelativePath == unit.fileRelativePath;
        }

        /// <summary>
        /// 使用相对路径比较两个文件
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(FileUnit other)
        {
            return this.fileRelativePath.CompareTo(other.fileRelativePath);
        }

        public override int GetHashCode()
        {
            return this.fileRelativePath.GetHashCode();
        }
    }
}
