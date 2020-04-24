using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MIS.DBModel;

namespace MIS.Forms
{
    public partial class frmList : Form
    {
        public frmList()
        {
            InitializeComponent();
        }

        private Business.Class GetClassInstance()
        {
            Business.Class objClass = null;
            if (objClass == null)
            {
                objClass = new Business.Class();
            }
            return objClass;
        }


        private Business.Student GetStudentInstance()
        {
            Business.Student objStudent = null;
            if (objStudent == null)
            {
                objStudent = new Business.Student();
            }
            return objStudent;
        }


        private void frmList_Load(object sender, EventArgs e)
        {
            BindClass();
            BindStudent(string.Empty,string.Empty,0);
        }


        private void BindStudent(string Name = "", string StudentNo = "", int ClassID = 0) {
            dgvStudent.DataSource = GetStudentInstance().GetAll(Name, StudentNo,ClassID);
        }


        private void dgvStudent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (object.Equals(e.Value, 0))
                {
                    e.Value = "女";
                }
                else
                {
                    e.Value = "男";
                }
            }

            if (e.ColumnIndex == 9)
            {
                if (object.Equals(e.Value, 0))
                {
                    e.Value = "否";
                }
                else
                {
                    e.Value = "是";
                }
            }

        }


        private void btnNameSearch_Click(object sender, EventArgs e)
        {
            var Name = txtName.Text.Trim();
            BindStudent(Name, string.Empty);
        }


        private void btnNoSearch_Click(object sender, EventArgs e)
        {
            var StudentNo = txtNo.Text.Trim();
            BindStudent(string.Empty, StudentNo,0);
        }


        private void btnResetNo_Click(object sender, EventArgs e)
        {

            txtName.Text = string.Empty;
            txtNo.Text = string.Empty;
            cbClass.SelectedIndex = 0;
            txtName.Focus();
            BindStudent(string.Empty, string.Empty,0);

        }


        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dgvStudent.Columns[e.ColumnIndex].Name == "StudentEdit" && e.RowIndex >= 0)
                {

                    try
                    {

                        var ID = Convert.ToInt32(dgvStudent.CurrentRow.Cells[2].Value);
                        var frmAdd = new frmAdd();
                        frmAdd.StudentID = ID;
                        frmAdd.IsEditModel = true;
                        frmAdd.Show();
                    }
                    finally {

                    }

                    

                }

                if (dgvStudent.Columns[e.ColumnIndex].Name == "StudentDelete" && e.RowIndex >= 0)
                {
                    var StudentName = Convert.ToString(dgvStudent.CurrentRow.Cells[3].Value);
                    var ID = int.Parse(dgvStudent.CurrentRow.Cells[2].Value.ToString());


                    if (MessageBox.Show(string.Concat("您确认删除 - ", StudentName, " - 吗?"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        try
                        {
                            if (GetStudentInstance().Delete(ID))
                            {

                                BindStudent(string.Empty, string.Empty);
                            }
                        }
                        catch
                        {

                        }
                        finally
                        {
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


        private void BindClass() {
            if (GetClassInstance().GetAll().Rows.Count > 0)
            {
                cbClass.DataSource = GetClassInstance().GetAll();
                cbClass.DisplayMember = "Name";
                cbClass.ValueMember = "ID";
                cbClass.SelectedIndex = 0;
            }
        }


        private void btnClassSearch_Click(object sender, EventArgs e)
        {

            var ClassID = int.Parse(cbClass.SelectedValue.ToString());

            BindStudent(string.Empty, string.Empty, ClassID);
        }

    }
}
