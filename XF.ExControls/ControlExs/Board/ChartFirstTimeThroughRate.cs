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
    public partial class ChartFirstTimeThroughRate : UserControl
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
        private CustomLabel customLabel7 = new CustomLabel();
        private CustomLabel customLabel8 = new CustomLabel();
        private CustomLabel customLabel9 = new CustomLabel();
        private CustomLabel customLabel10 = new CustomLabel();
        private CustomLabel customLabel11 = new CustomLabel();
        private CustomLabel customLabel12 = new CustomLabel();
        private CustomLabel customLabel13 = new CustomLabel();
        private CustomLabel customLabel14 = new CustomLabel();
        private CustomLabel customLabel15 = new CustomLabel();
        private CustomLabel customLabel16 = new CustomLabel();
        private CustomLabel customLabel17 = new CustomLabel();
        private CustomLabel customLabel18 = new CustomLabel();
        private CustomLabel customLabel19 = new CustomLabel();
        private CustomLabel customLabel20 = new CustomLabel();
        private CustomLabel customLabel21 = new CustomLabel();
        private CustomLabel customLabel22 = new CustomLabel();
        private CustomLabel customLabel23 = new CustomLabel();
        private CustomLabel customLabel24 = new CustomLabel();
        private CustomLabel customLabel25 = new CustomLabel();
        private CustomLabel customLabel26 = new CustomLabel();
        private CustomLabel customLabel27 = new CustomLabel();
        private CustomLabel customLabel28 = new CustomLabel();
        private CustomLabel customLabel29 = new CustomLabel();
        private CustomLabel customLabel30 = new CustomLabel();
        private CustomLabel customLabel31 = new CustomLabel();
        #endregion
        #region 图像的图例 Legend
        private Legend legend1 = new Legend();
        #endregion
        #region 数据点和序列
        List<List<DataPoint>> listlistDataPoint = new List<List<DataPoint>>();
        System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
        System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
        //System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
        //System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
        bool[] bShowSeries = new bool[2];
        #endregion
        #endregion
        #region 构造函数
        public ChartFirstTimeThroughRate()
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
            Chart1.BackGradientStyle = GradientStyle.TopBottom;
            Chart1.BorderlineColor = Color.FromArgb(26, 59, 105);
            Chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            Chart1.BorderlineWidth = 2;
            Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Raised;
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
            customLabel1.Text = "1";
            customLabel1.ToPosition = 1.5D;
            customLabel2.FromPosition = 1.5D;
            customLabel2.Text = "2";
            customLabel2.ToPosition = 2.5D;
            customLabel3.FromPosition = 2.5D;
            customLabel3.Text = "3";
            customLabel3.ToPosition = 3.5D;
            customLabel4.FromPosition = 3.5D;
            customLabel4.Text = "4";
            customLabel4.ToPosition = 4.5D;
            customLabel5.FromPosition = 4.5D;
            customLabel5.Text = "5";
            customLabel5.ToPosition = 5.5D;
            customLabel6.FromPosition = 5.5D;
            customLabel6.Text = "6";
            customLabel6.ToPosition = 6.5D;
            customLabel7.FromPosition = 6.5D;
            customLabel7.Text = "7";
            customLabel7.ToPosition = 7.5D;
            customLabel8.FromPosition = 7.5D;
            customLabel8.Text = "8";
            customLabel8.ToPosition = 8.5D;
            customLabel9.FromPosition = 8.5D;
            customLabel9.Text = "9";
            customLabel9.ToPosition = 9.5D;
            customLabel10.FromPosition = 9.5D;
            customLabel10.Text = "10";
            customLabel10.ToPosition = 10.5D;
            customLabel11.FromPosition = 10.5D;
            customLabel11.Text = "11";
            customLabel11.ToPosition = 11.5D;
            customLabel12.FromPosition = 11.5D;
            customLabel12.Text = "12";
            customLabel12.ToPosition = 12.5D;
            customLabel13.FromPosition = 12.5D;
            customLabel13.Text = "13";
            customLabel13.ToPosition = 13.5D;
            customLabel14.FromPosition = 13.5D;
            customLabel14.Text = "14";
            customLabel14.ToPosition = 14.5D;
            customLabel15.FromPosition = 14.5D;
            customLabel15.Text = "15";
            customLabel15.ToPosition = 15.5D;
            customLabel16.FromPosition = 15.5D;
            customLabel16.Text = "16";
            customLabel16.ToPosition = 16.5D;
            customLabel17.FromPosition = 16.5D;
            customLabel17.Text = "17";
            customLabel17.ToPosition = 17.5D;
            customLabel18.FromPosition = 17.5D;
            customLabel18.Text = "18";
            customLabel18.ToPosition = 18.5D;
            customLabel19.FromPosition = 18.5D;
            customLabel19.Text = "19";
            customLabel19.ToPosition = 19.5D;
            customLabel20.FromPosition = 19.5D;
            customLabel20.Text = "20";
            customLabel20.ToPosition = 20.5D;
            customLabel21.FromPosition = 20.5D;
            customLabel21.Text = "21";
            customLabel21.ToPosition = 21.5D;
            customLabel22.FromPosition = 21.5D;
            customLabel22.Text = "22";
            customLabel22.ToPosition = 22.5D;
            customLabel23.FromPosition = 22.5D;
            customLabel23.Text = "23";
            customLabel23.ToPosition = 23.5D;
            customLabel24.FromPosition = 23.5D;
            customLabel24.Text = "24";
            customLabel24.ToPosition = 24.5D;
            customLabel25.FromPosition = 24.5D;
            customLabel25.Text = "25";
            customLabel25.ToPosition = 25.5D;
            customLabel26.FromPosition = 25.5D;
            customLabel26.Text = "26";
            customLabel26.ToPosition = 26.5D;
            customLabel27.FromPosition = 26.5D;
            customLabel27.Text = "27";
            customLabel27.ToPosition = 27.5D;
            customLabel28.FromPosition = 27.5D;
            customLabel28.Text = "28";
            customLabel28.ToPosition = 28.5D;
            customLabel29.FromPosition = 28.5D;
            customLabel29.Text = "29";
            customLabel29.ToPosition = 29.5D;
            customLabel30.FromPosition = 29.5D;
            customLabel30.Text = "30";
            customLabel30.ToPosition = 30.5D;
            customLabel31.FromPosition = 30.5D;
            customLabel31.Text = "31";
            customLabel31.ToPosition = 31.5D;




            chartArea1.AxisX.CustomLabels.Clear();
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.CustomLabels.Add(customLabel2);
            chartArea1.AxisX.CustomLabels.Add(customLabel3);
            chartArea1.AxisX.CustomLabels.Add(customLabel4);
            chartArea1.AxisX.CustomLabels.Add(customLabel5);
            chartArea1.AxisX.CustomLabels.Add(customLabel6);
            chartArea1.AxisX.CustomLabels.Add(customLabel7);
            chartArea1.AxisX.CustomLabels.Add(customLabel8);
            chartArea1.AxisX.CustomLabels.Add(customLabel9);
            chartArea1.AxisX.CustomLabels.Add(customLabel10);
            chartArea1.AxisX.CustomLabels.Add(customLabel11);
            chartArea1.AxisX.CustomLabels.Add(customLabel12);
            chartArea1.AxisX.CustomLabels.Add(customLabel13);
            chartArea1.AxisX.CustomLabels.Add(customLabel14);
            chartArea1.AxisX.CustomLabels.Add(customLabel15);
            chartArea1.AxisX.CustomLabels.Add(customLabel16);
            chartArea1.AxisX.CustomLabels.Add(customLabel17);
            chartArea1.AxisX.CustomLabels.Add(customLabel18);
            chartArea1.AxisX.CustomLabels.Add(customLabel19);
            chartArea1.AxisX.CustomLabels.Add(customLabel20);
            chartArea1.AxisX.CustomLabels.Add(customLabel21);
            chartArea1.AxisX.CustomLabels.Add(customLabel22);
            chartArea1.AxisX.CustomLabels.Add(customLabel23);
            chartArea1.AxisX.CustomLabels.Add(customLabel24);
            chartArea1.AxisX.CustomLabels.Add(customLabel25);
            chartArea1.AxisX.CustomLabels.Add(customLabel26);
            chartArea1.AxisX.CustomLabels.Add(customLabel27);
            chartArea1.AxisX.CustomLabels.Add(customLabel28);
            chartArea1.AxisX.CustomLabels.Add(customLabel29);
            chartArea1.AxisX.CustomLabels.Add(customLabel30);
            chartArea1.AxisX.CustomLabels.Add(customLabel31);

            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            #endregion
            //chartArea1.AxisX.MajorTickMark.Size = 2F;
            //只设置本项，纵坐标自动最优化显示——从0显示
            chartArea1.AxisY.IsStartedFromZero = false;
            //可以手动设置想显示的最小坐标
            //chartArea1.AxisY.Minimum = 0;

            //自动调整轴标签
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisY.IsLabelAutoFit = false;
            //横纵坐标字体
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            //线颜色
            chartArea1.AxisX.LineColor = Color.Black;//Color.FromArgb(64, 64, 64, 64);
            chartArea1.AxisY.LineColor = Color.Black;//Color.FromArgb(64, 64, 64, 64);
            //网格线
            chartArea1.AxisX.MajorGrid.Interval = 1;
            chartArea1.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea1.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            //刻度线长度
            chartArea1.AxisX.MajorTickMark.Size = 0.5F;
            chartArea1.AxisY.MajorTickMark.Size = 0.5F;
            //标签显示样式
            chartArea1.AxisY.LabelStyle = new LabelStyle() { Format = "{#}.0%" };
            //坐标轴标题
            chartArea1.AxisX.Title = "日期(日)";
            chartArea1.AxisY.Title = "直通率(%)";
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
            chartArea1.Position.Height = 80F;
            chartArea1.Position.Width = 92F;
            chartArea1.Position.Y = 18F;
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
            #region 2个产线的数据点和序列
            #region 数据点和Series初始化
            List<DataPoint> list1 = new List<DataPoint>();
            listlistDataPoint.Add(list1);
            List<DataPoint> list2 = new List<DataPoint>();
            listlistDataPoint.Add(list2);
            //Random rd = new Random();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    listlistDataPoint[i].Add(new DataPoint(j + 1, 0));
                }
            }
            #endregion
            #region 各个Series属性定义——线
            #region 自动1线
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.BorderWidth = 8;
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = Color.FromArgb(255, 91, 155, 213);//Color.Red;//System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.Legend = "Default";
            series1.MarkerSize = 10;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "自动1线";
            //series1.ShadowColor = System.Drawing.Color.Black;
            //series1.ShadowOffset = 2;
            //线上显示值
            series1.IsValueShownAsLabel = false;
            //线上显示值字体大小
            series1.Font = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.Points.Clear();
            for (int i = 0; i < 31; i++)
            {
                series1.Points.Add(listlistDataPoint[0][i]);
            }
            #endregion
            #region 自动2线
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.BorderWidth = 8;
            series2.ChartArea = "Default";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = Color.FromArgb(255, 237, 125, 49);//Color.Yellow;////Color.Blue;//System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series2.Legend = "Default";
            series2.MarkerSize = 10;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "自动2线";
            //series2.ShadowColor = System.Drawing.Color.Black;
            //series2.ShadowOffset = 2;
            //线上显示值
            series2.IsValueShownAsLabel = false;
            //线上显示值字体大小
            series2.Font = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.Points.Clear();
            for (int i = 0; i < 31; i++)
            {
                series2.Points.Add(listlistDataPoint[1][i]);
            }
            #endregion
            #endregion
            #region 添加Series到图表
            Chart1.Series.Clear();
            Chart1.Series.Add(series1);
            Chart1.Series.Add(series2);
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
            title1.Position.Y = 5.5F;
            title1.ShadowColor = Color.FromArgb(32, 0, 0, 0);
            title1.ShadowOffset = 3;
            title1.Text = "数字化车间自动产线直通率统计";
            Chart1.Titles.Clear();
            Chart1.Titles.Add(title1);
            #endregion
        }
        #endregion
        #region 更改纵坐标最大值最小值
        /// <summary>
        /// 更改纵坐标最大值最小值
        /// </summary>
        public void ChangeAxisYMaxMin(double dMax, double dMin)
        {
            chartArea1.AxisY.Maximum = dMax > 100 ? 100 : dMax;
            chartArea1.AxisY.Minimum = dMin;
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
        #region 2条产线的直通率显示
        public void Show2Line(bool bShowLine1 = true, bool bShowLine2 = true)
        {
            bShowSeries[0] = bShowLine1;
            bShowSeries[1] = bShowLine2;
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
        #region 31天的直通率显示
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShowDays">显示到第几天</param>
        public void Show31Days(int ShowDays)
        {
            series1.Points.Clear();
            series2.Points.Clear();
            for (int i = 0; i < ShowDays; i++)
            {
                series1.Points.Add(listlistDataPoint[0][i]);
                series2.Points.Add(listlistDataPoint[1][i]);
            }
        }
        #endregion
        #region 更改某条线的名字
        public void ChangeLineName(int index, string sName)
        {
            try
            {
                switch (index)
                { 
                    case 0:
                        series1.Name = sName;
                        break;
                    case 1:
                        series2.Name = sName;
                        break;
                }
            }
            catch 
            {
                
            }
        }
        #endregion
        #region 更改坐标属性
        public void ChangeAxisY(bool IsCalcAxisY, int Minimum = -99, int Maximum = -99)
        {
            try
            {
                if (chartArea1.AxisX.Maximum > series1.Points.Count)
                    chartArea1.AxisX.Maximum = series1.Points.Count;
                if (IsCalcAxisY)
                {
                    //计算最优化最大最小值
                    //只设置本项，纵坐标自动最优化显示——从0显示
                    chartArea1.AxisY.IsStartedFromZero = false;
                    double dMax = 1;
                    double dMin = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (!bShowSeries[i]) 
                            continue;
                        List<DataPoint> lst = listlistDataPoint[i];
                        foreach (DataPoint point in lst)
                        {
                            if (point.YValues[0] < dMin)
                                dMin = point.YValues[0];
                            if (point.YValues[0] > dMax)
                                dMax = point.YValues[0];
                        }
                    }
                    //先算出跨度
                    double dDiff = dMax - dMin;
                    double dStep = 10.0;
                    while (dDiff > dStep * 10.0)
                    {
                        dStep *= 10.0;
                    }
                    dMin = Math.Floor(dMin / dStep) * dStep;
                    dMax = Math.Ceiling(dMax / dStep) * dStep;
                    chartArea1.AxisY.Minimum = dMin;
                    chartArea1.AxisY.Maximum = dMax;
                }
                else
                {
                    chartArea1.AxisY.IsStartedFromZero = false;
                    if (Minimum != -99)
                    {
                        //可以手动设置想显示的最小坐标
                        chartArea1.AxisY.Minimum = Minimum;
                    }
                    if (Maximum != -99)
                    {
                        //可以手动设置想显示的最大坐标
                        chartArea1.AxisY.Maximum = Maximum;
                    }
                }
            }
            catch 
            {
                
            }
        }
        #endregion
        #region 更改某一个产线某一天的直通率
        public void ChangeLineDayFTTRate(int iLine, int iDay, decimal dValue)
        {
            listlistDataPoint[iLine][iDay].SetValueXY(iDay + 1, dValue);
        }
        #endregion
        #region 更改某一天2个产线的直通率
        public void ChangeDayFTTRate(int iDay, decimal dValue1, decimal dValue2)
        {
            ChangeLineDayFTTRate(iDay, 0, dValue1);
            ChangeLineDayFTTRate(iDay, 1, dValue2);
        }
        #endregion
        #region 更改某一产线所有天的直通率
        public void ChangeLineFTTRate(int iLine, decimal[] arrValues)
        {
            for (int i = 0; i < (arrValues.Length > 31 ? 31 : arrValues.Length); i++)
                ChangeLineDayFTTRate(iLine, i, arrValues[i]);
        }
        #endregion
        #region 更改2个产线所有天的直通率
        public void ChangeFTTRate(decimal[] arrValues1, decimal[] arrValues2)
        {
            for (int i = 0; i < (arrValues1.Length > 31 ? 31 : arrValues1.Length); i++)
                ChangeLineDayFTTRate(0, i, arrValues1[i]);
            for (int i = 0; i < (arrValues2.Length > 31 ? 31 : arrValues2.Length); i++)
                ChangeLineDayFTTRate(1, i, arrValues2[i]);
        }
        #endregion

        private void ChartFirstTimeThroughRate_Load(object sender, EventArgs e)
        {
            bShowSeries[0] = true;
            bShowSeries[1] = true;
        }

    }
}