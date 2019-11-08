using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XF.ExControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            xfDataGridView1.OrderColumns();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            xfDataGridView1.SaveOrderColumns();
        }
    }
}
