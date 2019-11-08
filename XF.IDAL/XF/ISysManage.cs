using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XF.IDAL
{
    /// <summary>
    /// 接口层ISysManage
    /// </summary>
    public interface ISysManage
    {
        #region  成员方法
        bool ExecuteSqlTran(ArrayList listSql);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
