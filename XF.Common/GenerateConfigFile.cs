using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace XF.Common
{
    public class GenerateConfigFile
    {
        public static void CreateXFDataGrideViewConfig()
        {
            if (!File.Exists(Application.StartupPath + @"/XFDataGridViewConfig.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement root = xmlDoc.CreateElement("XFDataGridView");
                XmlElement columnOrderNames = xmlDoc.CreateElement("ColumnOrderNames");
                root.AppendChild(columnOrderNames);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(Application.StartupPath + @"/XFDataGridViewConfig.xml");
            }
        }
    }
}
