using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIS.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void 采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAdd = new frmAdd();
            frmAdd.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void 班级管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmClass = new frmClass();
            frmClass.Show();
        }

        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmList = new frmList();
            frmList.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
