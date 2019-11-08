using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XF.IDAL;
using XF.DALFactory;
using System.Collections;

namespace XF.BLL
{
    public class SysManage
    {
        private readonly ISysManage dal = DataAccess.CreateSysManage();
        public bool ExecuteSqlTran(ArrayList listSql)
        {
            return dal.ExecuteSqlTran(listSql);
        }
    }
}
