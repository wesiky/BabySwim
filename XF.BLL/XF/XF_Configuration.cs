using System;
using System.Data;
using System.Collections.Generic;

using XF.Lib;
using XF.Model;
using XF.DALFactory;
using XF.IDAL;

namespace XF.BLL
{
    public class XF_Configuration
    {
        private readonly IXF_Configuration dal = DataAccess.CreateXF_Configuration();

        public XF_Configuration() { }

        #region BaseMethod
        /// <summary>
        /// 判断配置项是否存在
        /// </summary>
        /// <param name="ItemName">配置项名称</param>
        /// <returns></returns>
        public bool Exists(string ItemName)
        {
            return dal.Exists(ItemName);
        }

        /// <summary>
        /// 创建新配置
        /// </summary>
        /// <param name="ItemName">配置名称</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        public int CreateItem(string ItemName, string ItemValue,string ItemDescription,string LoginName)
        {
            if (dal.Exists(ItemName))
            {
                return -1;
            }
            else
            {
                return dal.CreateItem(ItemName, ItemValue, ItemDescription, LoginName);
            }
        }

        /// <summary>
        /// 更新配置
        /// </summary>
        /// <param name="id">配置项ID</param>
        /// <param name="ItemName">配置名称</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        public bool UpdateItem(int id, string ItemName, string ItemValue, string ItemDescription,string LoginName)
        {
            return dal.UpdateItem(id, ItemName, ItemValue, ItemDescription,LoginName);
        }

        /// <summary>
        /// 更新配置值
        /// </summary>
        /// <param name="id">配置项ID</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        public bool UpdateItem(int id, string ItemValue,string LoginName)
        {
            return dal.UpdateItem(id, ItemValue,LoginName);
        }

        /// <summary>
        /// 更新配置值并存入缓存
        /// </summary>
        /// <param name="id">配置项ID</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        public bool UpdateItem(string ItemName, string ItemValue, string LoginName)
        {
            if (dal.UpdateItem(ItemName, ItemValue, LoginName))
            {
                try
                {
                    string CacheKey = "XF_Configuration-" + ItemName;
                    int ModelCache = XF.Common.ConfigHelper.GetConfigInt("ModelCache");
                    XF.Common.DataCache.SetCache(CacheKey, ItemValue, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除配置项
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool DeleteItem(int id)
        {
            return dal.DeleteItem(id);
        }

        /// <summary>
        /// 获取配置项的址
        /// </summary>
        /// <param name="ItemName">配置项名称</param>
        /// <returns></returns>
        public string GetItemValue(string ItemName)
        {
            return dal.GetItemValue(ItemName);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public string GetItemValueByCache(string ItemName)
        {

            string CacheKey = "XF_Configuration-" + ItemName;
            object value = XF.Common.DataCache.GetCache(CacheKey);
            if (value == null)
            {
                try
                {
                    value = dal.GetItemValue(ItemName);
                    if (!value.Equals(string.Empty))
                    {
                        int ModelCache = XF.Common.ConfigHelper.GetConfigInt("ModelCache");
                        XF.Common.DataCache.SetCache(CacheKey, value, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return value.ToString();
        }

        /// <summary>
        /// 获取配置的列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetItemList(string strWhere)
        {
            return dal.GetItemList(strWhere);
        }
        #endregion

        #region ExtendMethod
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataTable GetItemListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            return dal.GetItemListByPage(strWhere, strOrder, pageIndex, pageSize, ref count);
        }
        public bool DeleteItems(string IDs)
        {
            return dal.DeleteItems(IDs);
        }
        #endregion
    }
}
