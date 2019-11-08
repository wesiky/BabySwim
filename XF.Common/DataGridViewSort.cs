using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace XF.Common
{
    public static class DataGridViewSort
    {
        public static void Sort(this DataGridView dgv, Comparison<DataGridViewRow> comparison)
        {
            dgv.Sort(new RowCompare(comparison));
        }
        public class RowCompare : IComparer
        {
            Comparison<DataGridViewRow> comparison;
            public RowCompare(Comparison<DataGridViewRow> comparison)
            {
                this.comparison = comparison;
            }

            #region IComparer 成员

            public int Compare(object x, object y)
            {
                return comparison((DataGridViewRow)x, (DataGridViewRow)y);
            }

            #endregion
        }
    }
}
