using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XF.DBUtility;
using System.Collections;
using XF.IDAL;

namespace XF.SQLServerDAL
{
    public class SysManage:ISysManage
    {
        public bool ExecuteSqlTran(ArrayList listSql)
        {
            try
            {
                SqlServerHelper.ExecuteSqlTran(listSql);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
