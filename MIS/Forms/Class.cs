using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MIS.DBUtility;
using MIS.DBScript;

namespace MIS.Forms
{
    public partial class frmClass : Form
    {
        public frmClass()
        {
            InitializeComponent();
        }

        public int ClassID { get; set; }

        public bool IsEditMode { get; set; }

        private void BindData() {
            var objClass = new Business.Class();

            try
            {
                dgvClass.DataSource = objClass.GetAll();
            }
            catch
            {

            }
            finally
            {
                objClass = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtClassName.Text.Trim())) {
                MessageBox.Show("请输入班级名称!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClassName.Focus();
                return;
            }

            var Name = txtClassName.Text.Trim();
            var objClass = new Business.Class();

            try
            {

                if (!IsEditMode)
                {
                    if (objClass.Insert(Name))
                    {
                        txtClassName.Text = string.Empty;
                        txtClassName.Focus();
                        lblMessage.Text = string.Concat(Name, " - 班创建成功!");
                        BindData();
                    }
                }
                else {
                    if (objClass.Update(ClassID, Name)) {
                        txtClassName.Text = string.Empty;
                        txtClassName.Focus();
                        lblMessage.Text = string.Concat(Name, " - 班修改成功!");
                        BindData();
                        IsEditMode = false;
                    }
                }

            }
            catch
            {
                MessageBox.Show("抱歉创建遇到错误请重试!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                objClass = null;
            }

            

            

        }

        private void frmClass_Load(object sender, EventArgs e)
        {
            IsEditMode = false;
            BindData();
        }

        private void dgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dgvClass.Columns[e.ColumnIndex].Name == "ClassEdit" && e.RowIndex >= 0)
                {
                    txtClassName.Text = Convert.ToString(dgvClass.CurrentRow.Cells[3].Value);
                    ClassID = int.Parse(dgvClass.CurrentRow.Cells[2].Value.ToString());
                    IsEditMode = true;
                }

                if (dgvClass.Columns[e.ColumnIndex].Name == "ClassDelete" && e.RowIndex >= 0)
                {
                    var ClassName = Convert.ToString(dgvClass.CurrentRow.Cells[3].Value);
                    ClassID = int.Parse(dgvClass.CurrentRow.Cells[2].Value.ToString());


                    if (MessageBox.Show(string.Concat("您确认删除 - ", ClassName, " - 吗?"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var objClass = new Business.Class();
                        try
                        {
                            if (objClass.Delete(ClassID))
                            {
                                IsEditMode = false;
                                txtClassName.Text = string.Empty;
                                txtClassName.Focus();
                                BindData();
                            }
                        }
                        catch
                        {

                        }
                        finally
                        {
                            objClass = null;
                        }

                    }

                }
            }
            catch
            {

            }
            finally {

            }

            

        }







    }
}
