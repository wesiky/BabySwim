﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Enums;
using XF.Common;
using XF.ExControls;
using System.Drawing;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace BabySwim
{
    public partial class FrmCourseEvaluate : XFFormEx
    {
        int rowIndexOld = -1;
        private XF.BLL.Course_Evaluate bllEvaluate = new XF.BLL.Course_Evaluate();
        private XF.Model.Course_Selection model;

        public XF.Model.Course_Selection Model
        {
            get { return model; }
            set
            {
                model = value;
                LoadFormData();
            }
        }

        public FrmCourseEvaluate()
        {
            InitializeComponent();
            ColSignType.DisplayMember = MessageText.LISTITEM_TEXT;
            ColSignType.ValueMember = MessageText.LISTITEM_VALUE;
            ColSignType.DataSource = GenerateData.GetSignType(false);
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSure_Click(object sender, EventArgs e)
        {
            EndEdit();
            SetModelData();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 设置Model数据
        /// </summary>
        private void SetModelData()
        {
            xfDataGridView1.Rows[rowIndexOld].Cells[ColEvaluate.Name].Value = rtcEvaluate.ContentText;
            model.SelectionStudents.Clear();
            foreach (DataGridViewRow dgvr in xfDataGridView1.Rows)
            {
                XF.Model.Course_SelectionStudent student = dgvr.Tag as XF.Model.Course_SelectionStudent;
                model.SelectionStudents.Add(student);
            }
        }

        /// <summary>
        /// 设置界面数据
        /// </summary>
        private void LoadFormData()
        {
            if (model != null)
            {
                tbCourseDate.Text = model.CourseDate.ToString(MessageText.FORMAT_DATE);
                tbSectionNO.Text = zDataConverter.ToString(model.SectionNO);
                if (model.SelectionID >= 0)
                {
                    tbCourse.Text = model.CourseName;
                    tbSectionNO.Text = zDataConverter.ToString( model.SectionNO);
                    tbTeacher.Text = string.Format("{0}-{1}", model.TeacherCode, model.TeacherName);
                    BindStudentData(model.SelectionStudents);
                }
            }
        }

        /// <summary>
        /// 绑定学员信息
        /// </summary>
        /// <param name="models"></param>
        private void BindStudentData(List<XF.Model.Course_SelectionStudent> models)
        {
            xfDataGridView1.Rows.Clear();
            foreach (XF.Model.Course_SelectionStudent model in models)
            {
                int count = xfDataGridView1.Rows.Count;
                xfDataGridView1.Rows.Add();
                xfDataGridView1.Rows[count].Cells[ColSelectionStudentID.Name].Value = model.SelectionStudentID;
                xfDataGridView1.Rows[count].Cells[ColStudentID.Name].Value = model.StudentID;
                xfDataGridView1.Rows[count].Cells[ColStudentCode.Name].Value = model.StudentCode;
                xfDataGridView1.Rows[count].Cells[ColStudentName.Name].Value = model.StudentName;
                xfDataGridView1.Rows[count].Cells[ColSignType.Name].Value = model.SignType;
                xfDataGridView1.Rows[count].Tag = model;
            }
        }

        private void xfDataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowStudentEvalute();
        }

        /// <summary>
        /// 显示学员评价信息
        /// </summary>
        /// <param name="models"></param>
        private void ShowStudentEvalute()
        {
            if (xfDataGridView1.CurrentCell != null && xfDataGridView1.CurrentCell.RowIndex >= 0)
            {
                if (rowIndexOld != xfDataGridView1.CurrentCell.RowIndex)
                {
                    XF.Model.Course_SelectionStudent model;
                    if (rowIndexOld >= 0)
                    {
                        model = xfDataGridView1.Rows[rowIndexOld].Tag as XF.Model.Course_SelectionStudent;
                        model.Evaluation = rtcEvaluate.ContentText;
                        model.Evaluates.Clear();
                        model.Evaluates.AddRange(new List<XF.Model.Course_Evaluate> 
                        {
                            new XF.Model.Course_Evaluate
                            {
                                SelectionStudentId = model.SelectionStudentID,
                                Item = "Discipline",
                                Score = zDataConverter.ToInt(nudDiscipline.Value),
                                MaxScore = 10
                            }, new XF.Model.Course_Evaluate
                            {
                                SelectionStudentId = model.SelectionStudentID,
                                Item = "Practical",
                                Score = zDataConverter.ToInt(nudPractical.Value),
                                MaxScore = 10
                            }, new XF.Model.Course_Evaluate
                            {
                                SelectionStudentId = model.SelectionStudentID,
                                Item = "Concentration",
                                Score = zDataConverter.ToInt(nudConcentration.Value),
                                MaxScore = 10
                            }, new XF.Model.Course_Evaluate
                            {
                                SelectionStudentId = model.SelectionStudentID,
                                Item = "Logic",
                                Score = zDataConverter.ToInt(nudLogic.Value),
                                MaxScore = 10
                            }, new XF.Model.Course_Evaluate
                            {
                                SelectionStudentId = model.SelectionStudentID,
                                Item = "Communication",
                                Score = zDataConverter.ToInt(nudCommunication.Value),
                                MaxScore = 10
                            }
                        });
                    }
                    rowIndexOld = xfDataGridView1.CurrentCell.RowIndex;
                    model = xfDataGridView1.Rows[xfDataGridView1.CurrentCell.RowIndex].Tag as XF.Model.Course_SelectionStudent;
                    model.Evaluates = bllEvaluate.GetSelectionStudentEvaluates(model.SelectionStudentID);
                    rtcEvaluate.ContentText = model.Evaluation;
                    if (model.Evaluates.Count == 0)
                    {
                        nudDiscipline.Value = 10;
                        nudPractical.Value = 10;
                        nudConcentration.Value = 10;
                        nudLogic.Value = 10;
                        nudCommunication.Value = 10;
                    }
                    else
                    {
                        foreach (XF.Model.Course_Evaluate evaluate in model.Evaluates)
                        {
                            if (evaluate.Item.Equals("Discipline"))
                            {
                                nudDiscipline.Value = evaluate.Score;
                            }
                            else if (evaluate.Item.Equals("Practical"))
                            {
                                nudPractical.Value = evaluate.Score;
                            }
                            else if (evaluate.Item.Equals("Concentration"))
                            {
                                nudConcentration.Value = evaluate.Score;
                            }
                            else if (evaluate.Item.Equals("Logic"))
                            {
                                nudLogic.Value = evaluate.Score;
                            }
                            else if (evaluate.Item.Equals("Communication"))
                            {
                                nudCommunication.Value = evaluate.Score;
                            }
                        }
                    }
                }
            }
        }

        private void EndEdit()
        {
            int rowIndex = xfDataGridView1.CurrentCell.RowIndex;
            XF.Model.Course_SelectionStudent model = xfDataGridView1.Rows[rowIndex].Tag as XF.Model.Course_SelectionStudent;
            model.Evaluation = rtcEvaluate.ContentText;
            model.Evaluates.Clear();
            model.Evaluates.AddRange(new List<XF.Model.Course_Evaluate>
                        {
                            new XF.Model.Course_Evaluate
                            {
                                SelectionStudentId = model.SelectionStudentID,
                                Item = "Discipline",
                                Score = zDataConverter.ToInt(nudDiscipline.Value),
                                MaxScore = 10
                            }, new XF.Model.Course_Evaluate
                            {
                                SelectionStudentId = model.SelectionStudentID,
                                Item = "Practical",
                                Score = zDataConverter.ToInt(nudPractical.Value),
                                MaxScore = 10
                            }, new XF.Model.Course_Evaluate
                            {
                                SelectionStudentId = model.SelectionStudentID,
                                Item = "Concentration",
                                Score = zDataConverter.ToInt(nudConcentration.Value),
                                MaxScore = 10
                            }, new XF.Model.Course_Evaluate
                            {
                                SelectionStudentId = model.SelectionStudentID,
                                Item = "Logic",
                                Score = zDataConverter.ToInt(nudLogic.Value),
                                MaxScore = 10
                            }, new XF.Model.Course_Evaluate
                            {
                                SelectionStudentId = model.SelectionStudentID,
                                Item = "Communication",
                                Score = zDataConverter.ToInt(nudCommunication.Value),
                                MaxScore = 10
                            }
                        });
        }

        private void FrmCourseEvaluate_Load(object sender, EventArgs e)
        {
            this.TextForeColor = ConfigSetting.TextForeColor;
            this.Icon = ConfigSetting.ProjectIcon;
        }
    }
}
