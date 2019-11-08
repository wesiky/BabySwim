using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace XF.Common
{
    public class AutoReporting
    {
        /// <summary>
        /// 单零部件报料数量计算
        /// </summary>
        public static bool Reporting(decimal sum, List<Model.Base_PurchasingRatio> lstPurchasingRatio, ref string result)
        {
            bool isSuccess = false;
            if (lstPurchasingRatio.Count == 0)
            {
                result = "采购关系记录为空";
                return false;
            }
            else
            {
                if (AnalysisByOwningCount(sum, ref lstPurchasingRatio, ref result))
                {
                    isSuccess = true;
                }
                else
                {
                    if (AnalysisByMinPurchaseCount(sum, ref lstPurchasingRatio, ref result))
                    {
                        isSuccess = true;
                    }
                    else
                    {
                        isSuccess = false;
                        //采购数量过低
                        result = lstPurchasingRatio[0].ComponentCode + "采购数量过低，分解失败";
                    }
                }
            }
            return isSuccess;
        }

        private static bool AnalysisByMinPurchaseCount(decimal sum, ref List<Model.Base_PurchasingRatio> lstPurchasingRatio, ref string result)
        {
            //不考虑欠货量，根据最低采购量、采购比例进行分配
            //按步数降序排序  
            lstPurchasingRatio = SortPurchasingRatioByMinPurchaseing(lstPurchasingRatio);

            //计算满足最低采购量的步数
            for (int i = 0; i < lstPurchasingRatio.Count; i++)
            {
                //计算剩余最低采购总量之和
                decimal sumReporting = 0;
                for (int j = i; j < lstPurchasingRatio.Count; j++)
                {
                    sumReporting += lstPurchasingRatio[j].MinPurchaseCount;
                }
                
                if (sumReporting <= sum)
                {
                    decimal tempSum = sum;
                    //计算最终采购量 最终采购量=未排除供应商的采购之和*步数
                    for (int j = i; j < lstPurchasingRatio.Count-1; j++)
                    {
                        if (tempSum >= lstPurchasingRatio[j].MinPurchaseCount && tempSum < (lstPurchasingRatio[j].MinPurchaseCount + lstPurchasingRatio[j + 1].MinPurchaseCount))
                        {
                            lstPurchasingRatio[j].PurchasingCount = tempSum;
                            tempSum = 0;
                        }
                        else
                        {
                            lstPurchasingRatio[j].PurchasingCount = lstPurchasingRatio[j].MinPurchaseCount;
                            tempSum -= lstPurchasingRatio[j].MinPurchaseCount;
                        }
                    }
                    //最后项使用剩余量，避免采购总量超量
                    if (tempSum >= lstPurchasingRatio[lstPurchasingRatio.Count - 1].MinPurchaseCount)
                    {
                        lstPurchasingRatio[lstPurchasingRatio.Count - 1].PurchasingCount = tempSum;
                    }
                    //更新欠货量 欠货量=采购数量-报料数量*采购比例+上一次欠货量
                    for (int j = 0; j < lstPurchasingRatio.Count; j++)
                    {
                        lstPurchasingRatio[j].OwningCount = lstPurchasingRatio[j].PurchasingCount - sum * lstPurchasingRatio[j].Share + lstPurchasingRatio[j].OwningCount;
                    }
                    result += "成功";
                    return true;
                }
            }
            return false;
        }

        private static bool AnalysisByOwningCount(decimal sum, ref List<Model.Base_PurchasingRatio> lstPurchasingRatio, ref string result)
        {
            //按步数降序排序  
            lstPurchasingRatio = SortPurchasingRatioByStep(lstPurchasingRatio);

            //计算满足最低采购量的步数
            for (int i = 0; i < lstPurchasingRatio.Count; i++)
            {
                //计算剩余采购比例之和
                decimal sumShare = 0;
                decimal owningCount = 0;
                for (int j = i; j < lstPurchasingRatio.Count; j++)
                {
                    sumShare += lstPurchasingRatio[j].Share;
                    if (lstPurchasingRatio[j].OwningCount < 0)
                    {
                        owningCount += lstPurchasingRatio[j].OwningCount * -1;
                    }
                }
                //判断按步数计算出的总采购量是否小于等于报料总量，是则表示分配成功
                decimal sumReporting = sumShare * lstPurchasingRatio[i].Step;

                if (sumReporting + owningCount <= sum)
                {
                    decimal tempSum = sum;
                    //计算最终采购量 最终采购量=未排除供应商的采购之和*步数
                    for (int j = i; j < lstPurchasingRatio.Count - 1; j++)
                    {
                        lstPurchasingRatio[j].PurchasingCount = Convert.ToInt32(Math.Round(sum * (lstPurchasingRatio[j].Share / sumShare), MidpointRounding.AwayFromZero));
                        tempSum -= lstPurchasingRatio[j].PurchasingCount;
                    }
                    //最后项使用剩余量，避免采购总量超量
                    lstPurchasingRatio[lstPurchasingRatio.Count - 1].PurchasingCount = tempSum;
                    //更新欠货量 欠货量=采购数量-报料数量*采购比例+上一次欠货量
                    for (int j = 0; j < lstPurchasingRatio.Count; j++)
                    {
                        lstPurchasingRatio[j].OwningCount = lstPurchasingRatio[j].PurchasingCount - sum * lstPurchasingRatio[j].Share + lstPurchasingRatio[j].OwningCount;
                    }
                    result += "成功";
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 零部件公斤报料数量计算RebellionPackage值为3
        /// </summary>
        public static bool Reporting(decimal sum, int count, List<Model.Base_PurchasingRatio> lstPurchasingRatio, ref string result)
        {
            bool isSuccess = false;
            if (lstPurchasingRatio.Count == 0)
            {
                result = "采购关系记录为空";
                return false;
            }
            else
            {
                //按步数降序排序  
                lstPurchasingRatio = SortPurchasingRatioByStepUnInt(lstPurchasingRatio);

                //计算满足最低采购量的步数
                for (int i = 0; i < lstPurchasingRatio.Count; i++)
                {
                    //计算剩余采购比例之和
                    decimal sumShare = 0;
                    decimal owningCount = 0;
                    for (int j = i; j < lstPurchasingRatio.Count; j++)
                    {
                        sumShare += lstPurchasingRatio[j].Share;
                        if (lstPurchasingRatio[j].OwningCount < 0)
                        {
                            owningCount += lstPurchasingRatio[j].OwningCount * -1;
                        }
                    }
                    //判断按步数计算出的总采购量是否小于等于报料总量，是则表示分配成功
                    decimal sumReporting = sumShare * lstPurchasingRatio[i].Step;

                    if (sumReporting + owningCount <= sum)
                    {
                        decimal tempSum = sum;
                        int tempCount = count;
                        //计算最终采购量 最终采购量=未排除供应商的采购之和*步数
                        for (int j = i; j < lstPurchasingRatio.Count - 1; j++)
                        {
                            lstPurchasingRatio[j].PurchasingCount = Math.Round(sum * (lstPurchasingRatio[j].Share / sumShare), 3);
                            lstPurchasingRatio[j].Description = Math.Round(count * (lstPurchasingRatio[j].Share / sumShare), 0).ToString();
                            tempCount -= zDataConverter.ToInt(lstPurchasingRatio[j].Description);
                            tempSum -= lstPurchasingRatio[j].PurchasingCount;
                        }
                        //最后项使用剩余量，避免采购总量超量
                        lstPurchasingRatio[lstPurchasingRatio.Count - 1].PurchasingCount = tempSum;
                        lstPurchasingRatio[lstPurchasingRatio.Count - 1].Description = tempCount.ToString();
                        //更新欠货量 欠货量=采购数量-报料数量*采购比例+上一次欠货量
                        for (int j = 0; j < lstPurchasingRatio.Count; j++)
                        {
                            lstPurchasingRatio[j].OwningCount = lstPurchasingRatio[j].PurchasingCount - sum * lstPurchasingRatio[j].Share + lstPurchasingRatio[j].OwningCount;
                        }
                        isSuccess = true;
                        result = "成功";
                        break;
                    }
                }
                if (isSuccess == false)
                {
                    //采购数量过低
                    result = lstPurchasingRatio[0].ComponentCode + "采购数量过低，分解失败";
                }
            }
            return isSuccess;
        }

        /// <summary>
        /// 对采购关系按取整步数降序排序
        /// </summary>
        /// <param name="lstPurchasingRatio"></param>
        /// <returns></returns>
        public static List<Model.Base_PurchasingRatio> SortPurchasingRatioByStep(List<Model.Base_PurchasingRatio> lstPurchasingRatio)
        {
            List<Model.Base_PurchasingRatio> sortPurchasingRatio = new List<Model.Base_PurchasingRatio>();
            sortPurchasingRatio.Add(lstPurchasingRatio[0]);
            for (int i = 1; i < lstPurchasingRatio.Count; i++)
            {
                //标记是否已插入
                bool flag = false;
                //选择排序
                for (int j = 0; j < sortPurchasingRatio.Count; j++)
                {
                    if (lstPurchasingRatio[i].Step > sortPurchasingRatio[j].Step)
                    {
                        sortPurchasingRatio.Insert(j, lstPurchasingRatio[i]);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    sortPurchasingRatio.Add(lstPurchasingRatio[i]);
                }
            }
            return sortPurchasingRatio;
        }

        /// <summary>
        /// 对采购关系按非取整步数降序排序
        /// </summary>
        /// <param name="lstPurchasingRatio"></param>
        /// <returns></returns>
        public static List<Model.Base_PurchasingRatio> SortPurchasingRatioByStepUnInt(List<Model.Base_PurchasingRatio> lstPurchasingRatio)
        {
            List<Model.Base_PurchasingRatio> sortPurchasingRatio = new List<Model.Base_PurchasingRatio>();
            sortPurchasingRatio.Add(lstPurchasingRatio[0]);
            for (int i = 1; i < lstPurchasingRatio.Count; i++)
            {
                //标记是否已插入
                bool flag = false;
                //选择排序
                for (int j = 0; j < sortPurchasingRatio.Count; j++)
                {
                    if (lstPurchasingRatio[i].StepUnInt > sortPurchasingRatio[j].StepUnInt)
                    {
                        sortPurchasingRatio.Insert(j, lstPurchasingRatio[i]);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    sortPurchasingRatio.Add(lstPurchasingRatio[i]);
                }
            }
            return sortPurchasingRatio;
        }

        /// <summary>
        /// 对采购关系按取最低采购量降序排序
        /// </summary>
        /// <param name="lstPurchasingRatio"></param>
        /// <returns></returns>
        public static List<Model.Base_PurchasingRatio> SortPurchasingRatioByMinPurchaseing(List<Model.Base_PurchasingRatio> lstPurchasingRatio)
        {
            List<Model.Base_PurchasingRatio> sortPurchasingRatio = new List<Model.Base_PurchasingRatio>();
            sortPurchasingRatio.Add(lstPurchasingRatio[0]);
            for (int i = 1; i < lstPurchasingRatio.Count; i++)
            {
                //标记是否已插入
                bool flag = false;
                //选择排序
                for (int j = 0; j < sortPurchasingRatio.Count; j++)
                {
                    if (lstPurchasingRatio[i].MinPurchaseCount > sortPurchasingRatio[j].MinPurchaseCount)
                    {
                        sortPurchasingRatio.Insert(j, lstPurchasingRatio[i]);
                        flag = true;
                        break;
                    }
                    else if (lstPurchasingRatio[i].MinPurchaseCount == sortPurchasingRatio[j].MinPurchaseCount && lstPurchasingRatio[i].Share < sortPurchasingRatio[j].Share)
                    {
                        sortPurchasingRatio.Insert(j, lstPurchasingRatio[i]);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    sortPurchasingRatio.Add(lstPurchasingRatio[i]);
                }
            }
            return sortPurchasingRatio;
        }

        public static bool CheckPurchasingRatio(DataTable dtPurchasingRatio)
        {
            if (dtPurchasingRatio.Columns.Contains("SupplierID") && dtPurchasingRatio.Columns.Contains("Share") && dtPurchasingRatio.Columns.Contains("OwningCount") && dtPurchasingRatio.Columns.Contains("MinPurchaseCount") && !dtPurchasingRatio.Columns.Contains("ResultCount"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
