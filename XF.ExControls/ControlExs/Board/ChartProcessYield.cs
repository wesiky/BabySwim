using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace XF.ExControls
{
    public partial class ChartProcessYield : UserControl
    {
        #region 自定义变量
        #region 图表
        //图表
        private Chart Chart1 = new Chart();
        //图表的区域
        private ChartArea chartArea1 = new ChartArea();
        //图表的标题
        private Title title1 = new Title();
        #endregion
        #region 轴的标签
        private CustomLabel customLabel1 = new CustomLabel();
        private CustomLabel customLabel2 = new CustomLabel();
        private CustomLabel customLabel3 = new CustomLabel();
        private CustomLabel customLabel4 = new CustomLabel();
        private CustomLabel customLabel5 = new CustomLabel();
        private CustomLabel customLabel6 = new CustomLabel();
        #endregion
        #region 图像的图例 Legend
        private Legend legend1 = new Legend();
        #endregion
        #region 数据点和序列
        List<List<DataPoint>> listlistDataPoint = new List<List<DataPoint>>();
        //private List<Series> listSeries = new List<Series>();
        //private List<Series> listSignSeries = new List<Series>();
        System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
        System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
        //private Series fanSeries = new Series();
        //private Series lineSeries = new Series();
        #endregion
        #endregion
        #region 构造函数
        public ChartProcessYield()
        {
            InitializeComponent();
            InitChart();
            this.Controls.Add(Chart1);
            Chart1.Dock = System.Windows.Forms.DockStyle.Fill;
        }
        #endregion
        #region 初始化图表
        public void InitChart()
        {
            #region 基本属性
            Chart1.BackColor = Color.White; //Color.WhiteSmoke;
            Chart1.BackSecondaryColor = Color.White;
            Chart1.Location = new System.Drawing.Point(16, 50);
            Chart1.Name = "Chart1";
            Chart1.Palette = ChartColorPalette.Pastel;
            Chart1.Size = new System.Drawing.Size(400, 296);
            Chart1.TabIndex = 1;
            #endregion
            #region 显示边框
            //Chart1.BackGradientStyle = GradientStyle.TopBottom;
            //Chart1.BorderlineColor = Color.FromArgb(26, 59, 105);
            //Chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            //Chart1.BorderlineWidth = 2;
            //Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            #endregion
            #region 三维效果
            //chartArea1.Area3DStyle.Enable3D = false;
            //chartArea1.Area3DStyle.Inclination = 15;
            //chartArea1.Area3DStyle.IsClustered = true;
            //chartArea1.Area3DStyle.IsRightAngleAxes = false;
            //chartArea1.Area3DStyle.Perspective = 10;
            ////chartArea1.Area3DStyle.PointGapDepth = 0;
            //chartArea1.Area3DStyle.Rotation = 10;//0;//5;
            //chartArea1.Area3DStyle.WallWidth = 0;
            #endregion
            #region 坐标
            #region 坐标轴标签
            customLabel1.FromPosition = 0.5D;
            customLabel1.Text = "8:00-10:00";
            customLabel1.ToPosition = 1.5D;
            customLabel2.FromPosition = 1.5D;
            customLabel2.Text = "10:00-12:00";
            customLabel2.ToPosition = 2.5D;
            customLabel3.FromPosition = 2.5D;
            customLabel3.Text = "12:00-14:00";
            customLabel3.ToPosition = 3.5D;
            customLabel4.FromPosition = 3.5D;
            customLabel4.Text = "14:00-16:00";
            customLabel4.ToPosition = 4.5D;
            customLabel5.FromPosition = 4.5D;
            customLabel5.Text = "16:00-18:00";
            customLabel5.ToPosition = 5.5D;
            customLabel6.FromPosition = 5.5D;
            customLabel6.Text = "18:00-20:00";
            customLabel6.ToPosition = 6.5D;

            

            chartArea1.AxisX.CustomLabels.Clear();
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.CustomLabels.Add(customLabel2);
            chartArea1.AxisX.CustomLabels.Add(customLabel3);
            chartArea1.AxisX.CustomLabels.Add(customLabel4);
            chartArea1.AxisX.CustomLabels.Add(customLabel5);
            chartArea1.AxisX.CustomLabels.Add(customLabel6);

            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            #endregion
            //chartArea1.AxisX.MajorTickMark.Size = 2F;
            //只设置本项，纵坐标自动最优化显示——从0显示
            chartArea1.AxisY.IsStartedFromZero = true;
            //可以手动设置想显示的最小坐标
            chartArea1.AxisY.Minimum = 0;

            //自动调整轴标签
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisY.IsLabelAutoFit = false;
            //横纵坐标字体
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            //线颜色
            chartArea1.AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea1.AxisY.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea1.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea1.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            //刻度线长度
            chartArea1.AxisX.MajorTickMark.Size = 0.5F;
            chartArea1.AxisY.MajorTickMark.Size = 0.5F;
            //坐标轴标题
            chartArea1.AxisX.Title = "时间段";
            chartArea1.AxisY.Title = "产量";
            //坐标轴标题对齐方式
            chartArea1.AxisX.TitleAlignment = StringAlignment.Far;
            chartArea1.AxisY.TitleAlignment = StringAlignment.Far;
            #endregion
            #region 图表区域
            chartArea1.BackColor = Color.White;//Color.OldLace;
            chartArea1.BackSecondaryColor = Color.White;
            chartArea1.BorderColor = Color.FromArgb(64, 64, 64, 64);
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = Color.Transparent;
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 85F;
            chartArea1.Position.Width = 92F;
            chartArea1.Position.Y = 8F;
            chartArea1.Position.X = 2F;

            Chart1.ChartAreas.Clear();
            Chart1.ChartAreas.Add(chartArea1);
            #endregion
            #region 图例
            legend1.BackColor = Color.Transparent;
            legend1.Enabled = true;
            legend1.IsTextAutoFit = true;
            legend1.Name = "Default";
            legend1.TableStyle = LegendTableStyle.Auto;
            legend1.Alignment = StringAlignment.Near;
            legend1.Docking = Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 16F, System.Drawing.FontStyle.Bold);
            Chart1.Legends.Clear();
            Chart1.Legends.Add(legend1);
            #endregion
            #region 2条产线的数据点和序列
            #region 数据点和Series初始化
            //listSeries.Add(new Series());
            //listSeries.Add(new Series());
            //listSignSeries.Add(new Series());
            //listSignSeries.Add(new Series());
            List<DataPoint> list1 = new List<DataPoint>();
            listlistDataPoint.Add(list1);
            List<DataPoint> list2 = new List<DataPoint>();
            listlistDataPoint.Add(list2);
            listlistDataPoint[0].Add(new DataPoint(1, 440));
            listlistDataPoint[0].Add(new DataPoint(2, 360));
            listlistDataPoint[0].Add(new DataPoint(3, 410));
            listlistDataPoint[0].Add(new DataPoint(4, 460));
            listlistDataPoint[0].Add(new DataPoint(5, 340));
            listlistDataPoint[0].Add(new DataPoint(6, 420));
            listlistDataPoint[1].Add(new DataPoint(1, 470));
            listlistDataPoint[1].Add(new DataPoint(2, 330));
            listlistDataPoint[1].Add(new DataPoint(3, 460));
            listlistDataPoint[1].Add(new DataPoint(4, 480));
            listlistDataPoint[1].Add(new DataPoint(5, 380));
            listlistDataPoint[1].Add(new DataPoint(6, 480));
            #endregion
            #region 各个Series属性定义——线
            #region 自动1线
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.BorderWidth = 5;
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = Color.FromArgb(255, 91, 155, 213);//Color.Red;//System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.Legend = "Default";
            series1.MarkerSize = 8;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "自动1线";
            //series1.ShadowColor = System.Drawing.Color.Black;
            //series1.ShadowOffset = 2;
            //线上显示值
            series1.IsValueShownAsLabel = true;
            //线上显示值字体大小
            series1.Font = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.Points.Clear();
            series1.Points.Add(listlistDataPoint[0][0]);
            series1.Points.Add(listlistDataPoint[0][1]);
            series1.Points.Add(listlistDataPoint[0][2]);
            series1.Points.Add(listlistDataPoint[0][3]);
            series1.Points.Add(listlistDataPoint[0][4]);
            series1.Points.Add(listlistDataPoint[0][5]);
            #endregion
            #region 自动2线
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.BorderWidth = 5;
            series2.ChartArea = "Default";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = Color.FromArgb(255, 237, 125, 49);//Color.Blue;//System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series2.Legend = "Default";
            series2.MarkerSize = 8;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "自动2线";
            //series2.ShadowColor = System.Drawing.Color.Black;
            //series2.ShadowOffset = 2;
            //线上显示值
            series2.IsValueShownAsLabel = true;
            //线上显示值字体大小
            series2.Font = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.Points.Clear();
            series2.Points.Add(listlistDataPoint[1][0]);
            series2.Points.Add(listlistDataPoint[1][1]);
            series2.Points.Add(listlistDataPoint[1][2]);
            series2.Points.Add(listlistDataPoint[1][3]);
            series2.Points.Add(listlistDataPoint[1][4]);
            series2.Points.Add(listlistDataPoint[1][5]);
            #endregion
            #endregion
            #region 添加Series到图表
            Chart1.Series.Clear();
            //Chart1.Series.Add(series1);
            //Chart1.Series.Add(series2);
            Chart1.Series.Add(series1);
            Chart1.Series.Add(series2);
            //Chart1.Series.Add(listSignSeries[0]);
            //Chart1.Series.Add(listSignSeries[1]);
            #endregion
            #endregion
            #region 图表标题
            title1.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title1.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = Color.FromArgb(26, 59, 105);
            title1.Name = "Title1";
            title1.Position.Auto = false;
            title1.Position.Height = 8.738057F;
            title1.Position.Width = 80F;
            title1.Position.X = 10F;
            title1.Position.Y = 1F;
            title1.ShadowColor = Color.FromArgb(32, 0, 0, 0);
            title1.ShadowOffset = 3;
            title1.Text = "数字化车间自动产线包装工序各时段产量";
            Chart1.Titles.Clear();
            Chart1.Titles.Add(title1);
            #endregion
        }
        #endregion
        #region 是否显示图例
        /// <summary>
        /// 是否显示图例
        /// </summary>
        /// <param name="bShow"></param>
        public void ShowLegend(bool bShow)
        {
            if (bShow)
            {
                Chart1.Legends.Clear();
                Chart1.Legends.Add(legend1);
            }
            else
            {
                Chart1.Legends.Clear();
            }
        }
        #endregion
        #region 2条产线的产量显示
        /// <summary>
        /// 2条产线的产量显示
        /// </summary>
        /// <param name="bShowLine"></param>
        public void Show2Line(bool bShowLine1 = true, bool bShowLine2 = true)
        {
            Chart1.Series.Clear();
            if (bShowLine1)
            {
                Chart1.Series.Add(series1);
            }
            if (bShowLine2)
            {
                Chart1.Series.Add(series2);
            }
        }
        #endregion
        #region 六个时段的产量显示
        /// <summary>
        /// 六个时段的产量显示
        /// </summary>
        /// <param name="bShowTime1">8:00-10:00</param>
        /// <param name="bShowTime2">10:00-12:00</param>
        /// <param name="bShowTime3">12:00-14:00</param>
        /// <param name="bShowTime4">14:00-16:00</param>
        /// <param name="bShowTime5">16:00-18:00</param>
        /// <param name="bShowTime6">18:00-20:00</param>
        public void Show6Time(bool bShowTime1 = true, bool bShowTime2 = true, bool bShowTime3 = true, bool bShowTime4 = true, bool bShowTime5 = true, bool bShowTime6 = true)
        {
            //chartArea1.AxisX.CustomLabels.Clear();
            series1.Points.Clear();
            series2.Points.Clear();
            if (bShowTime1)
            {
                series1.Points.Add(listlistDataPoint[0][0]);
                series2.Points.Add(listlistDataPoint[1][0]);
            }
            if (bShowTime2)
            {
                series1.Points.Add(listlistDataPoint[0][1]);
                series2.Points.Add(listlistDataPoint[1][1]);
            }
            if (bShowTime3)
            {
                series1.Points.Add(listlistDataPoint[0][2]);
                series2.Points.Add(listlistDataPoint[1][2]);
            }
            if (bShowTime4)
            {
                series1.Points.Add(listlistDataPoint[0][3]);
                series2.Points.Add(listlistDataPoint[1][3]);
            }
            if (bShowTime5)
            {
                series1.Points.Add(listlistDataPoint[0][4]);
                series2.Points.Add(listlistDataPoint[1][4]);
            }
            if (bShowTime6)
            {
                series1.Points.Add(listlistDataPoint[0][5]);
                series2.Points.Add(listlistDataPoint[1][5]);
            }
        }
        #endregion
        #region 更改某一个时段某一条产线的产量
        /// <summary>
        /// 更改某一个时段某一条产线的产量
        /// </summary>
        /// <param name="iTime">时段序号：0到5</param>
        /// <param name="iLine">月份序号：0到11</param>
        /// <param name="dValue">产量</param>
        public void ChangeTimeLineYield(int iTime, int iLine, decimal dValue)
        {
            listlistDataPoint[iLine][iTime].SetValueXY(iTime + 1, dValue);
        }
        #endregion
        #region 更改某一个时段2条产线的产量
        /// <summary>
        /// 更改某一个时段2条产线的产量
        /// </summary>
        /// <param name="iTime">时段序号：0到5</param>
        /// <param name="dValue1">自动1线的产量</param>
        /// <param name="dValue2">自动2线的产量</param>
        public void ChangeTimeYield(int iTime, decimal dValue1, decimal dValue2)
        {
            ChangeTimeLineYield(iTime, 0, dValue1);
            ChangeTimeLineYield(iTime, 1, dValue2);
        }
        #endregion
        #region 更改某一条产线所有时段的产量
        /// <summary>
        /// 更改某一条产线所有时段的产量
        /// </summary>
        /// <param name="iLine">月份序号：0到11</param>
        /// <param name="dValue1">时段1的产量</param>
        /// <param name="dValue2">时段2的产量</param>
        /// <param name="dValue3">时段3的产量</param>
        /// <param name="dValue4">时段4的产量</param>
        /// <param name="dValue5">时段5的产量</param>
        /// <param name="dValue6">时段6的产量</param>
        public void ChangeLineYield(int iLine, decimal dValue1, decimal dValue2, decimal dValue3, decimal dValue4, decimal dValue5, decimal dValue6)
        {
            ChangeTimeLineYield(0, iLine, dValue1);
            ChangeTimeLineYield(1, iLine, dValue2);
            ChangeTimeLineYield(2, iLine, dValue3);
            ChangeTimeLineYield(3, iLine, dValue4);
            ChangeTimeLineYield(4, iLine, dValue5);
            ChangeTimeLineYield(5, iLine, dValue6);
        }
        #endregion
        #region 更改所有时段所有的产量
        /// <summary>
        /// 更改所有时段所有的产量
        /// </summary>
        public void ChangeYield(decimal dValue11, decimal dValue12, decimal dValue13, decimal dValue14, decimal dValue15, decimal dValue16,
            decimal dValue21, decimal dValue22, decimal dValue23, decimal dValue24, decimal dValue25, decimal dValue26)
        {
            ChangeLineYield(0, dValue11, dValue12, dValue13, dValue14, dValue15, dValue16);
            ChangeLineYield(1, dValue21, dValue22, dValue23, dValue24, dValue25, dValue26);
        }
        #endregion

        private void ChartProcessYield_Load(object sender, EventArgs e)
        {
            //series1.BorderWidth = 50;
            //SetPosition(Chart1.ChartAreas[0].AxisX, Chart1.ChartAreas[0].CursorX.Position);
            //SetPosition(Chart1.ChartAreas[0].AxisY, Chart1.ChartAreas[0].CursorY.Position);
        }

    }
}