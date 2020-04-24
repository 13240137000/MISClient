using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using AForge;
using AForge.Controls;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;


namespace MIS.Forms
{
    public partial class frmAdd : Form
    {

        FilterInfoCollection videoDevices;

        VideoCaptureDevice videoSource;

        public int StudentID { get; set; }

        public int StudentFeatureID { get; set; }

        public int StudentClassID { get; set; }

        private string PicturePath { get; set; }

        private string PictureName { get; set; }

        private FileInfo objFileInfo { get; set; }

        public bool IsEditModel { get; set; }

        public bool IsCameraMode { get; set; }

        private Business.Class GetClassInstance() {
            Business.Class objClass = null;
            if (objClass == null) {
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


        public frmAdd()
        {
            InitializeComponent();
        }


        private void frmAdd_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            VideoPlayer.Visible = false;
            pbPreview.Visible = true;
            BindClass();
            InitData();

        }

        private void InitData() {
            if (IsEditModel) {
                try
                {
                    var StudentInfo = new DBModel.Student();
                    StudentInfo = GetStudentInstance().GetStudentAndClassByStudentID(StudentID);

                    txtName.Text = StudentInfo.Name;
                    txtStudentNo.Text = StudentInfo.StudentNo;
                    txtParentName.Text = StudentInfo.ParentName;
                    txtParentMobileNumber.Text = StudentInfo.ParentMobile;
                    cbClass.SelectedValue = StudentInfo.ClassID;
                    txtNote.Text = StudentInfo.Note;
                    StudentFeatureID = StudentInfo.StudentFeatureID;
                    StudentClassID = StudentInfo.StudentClassID;
                    if (StudentInfo.Gender == 0)
                    {
                        rbGirl.Checked = true;
                    }
                    else {
                        rbBoy.Checked = true;
                    }
                    btnSave.Enabled = true;
                    pbPreview.ImageLocation = string.Concat(InitSettings.GetPicturePath, StudentInfo.PictureName);
                }
                finally {

                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            VideoPlayer.Stop();
            this.Close();
        }


        private bool ValidateField() {

            var result = true;

            var MsgBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
            {
                MsgBuilder.Append("请键入姓名!\r\n");
                result = false;
            }

            if (string.IsNullOrWhiteSpace(txtStudentNo.Text.Trim()))
            {
                MsgBuilder.Append("请键入学号!\r\n");
                result = false;
            }

            if (string.IsNullOrWhiteSpace(txtParentName.Text.Trim()))
            {
                MsgBuilder.Append("请键入监护人姓名!\r\n");
                result = false;
            }

            if (string.IsNullOrWhiteSpace(txtParentMobileNumber.Text.Trim()))
            {
                MsgBuilder.Append("请键入手机号码!\r\n");
                result = false;
            }

            if (!InitSettings.IsMobileNumber(txtParentMobileNumber.Text.Trim()))
            {
                MsgBuilder.Append("请键入正确的手机号码!\r\n");
                result = false;
            }

            if (!result) {
                MessageBox.Show(MsgBuilder.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (ValidateField()) {
                var Name = txtName.Text.Trim();
                var StudentNo = txtStudentNo.Text.Trim();
                var Class = cbClass.SelectedText;
                var ParentName = txtParentName.Text.Trim();
                var ParentMobile = txtParentMobileNumber.Text.Trim();
                var Note = txtNote.Text.Trim();
                var ClassID = 0;
                var Gender = 1;

                if (rbGirl.Checked) Gender = 0;

                if (cbClass.Items.Count > 0)
                {
                    ClassID = int.Parse(cbClass.SelectedValue.ToString());
                }



                try
                {

                    if (IsEditModel)
                    {

                        if (GetStudentInstance().Update(StudentID, Name, Gender, StudentNo, ParentName, ParentMobile, Note) && ClassID > 0)
                        {
                            GetStudentInstance().ClassUpdate(StudentClassID, ClassID);
                        }
                        if (MessageBox.Show("修改成功,确定后将关闭窗口!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        var StudentID = GetStudentInstance().Insert(Name, Gender, StudentNo, ParentName, ParentMobile, Note);

                        if (StudentID > 0 && ClassID > 0)
                        {
                            GetStudentInstance().ClassStudentInsert(StudentID, ClassID);
                        }

                        if (StudentID > 0)
                        {
                            GetStudentInstance().FeatureInsert(StudentID, PictureName);
                        }

                        lblMessage.Text = string.Concat(Name, "添加成功!");

                        txtName.Text = string.Empty;
                        txtName.Focus();
                        rbBoy.Checked = true;
                        txtStudentNo.Text = string.Empty;
                        txtParentMobileNumber.Text = string.Empty;
                        txtParentName.Text = string.Empty;
                        txtNote.Text = string.Empty;
                        cbClass.SelectedIndex = 0;
                        btnRemove_Click(null, null);
                        IsEditModel = false;

                        btnSave.Enabled = false;
                        MessageBox.Show(string.Concat(Name, "信息添加成功!"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                finally
                {

                }
            }


        }


        private void pbUpload_Click(object sender, EventArgs e)
        {

            IsCameraMode = false;
            VideoPlayer.Stop();
            VideoPlayer.Visible = false;

            var PictureMaxSize = InitSettings.GetPictureMaxSize;
            var InitialDirectory = InitSettings.GetInitialDirectory;
            var objUploadPicture = new OpenFileDialog();

            try
            {

                objUploadPicture.Title = "上传图片";
                objUploadPicture.InitialDirectory = InitialDirectory;
                objUploadPicture.Filter = "图片文件|*.jpg;*.jpeg;*.png";
                objUploadPicture.FilterIndex = 1;
                objUploadPicture.RestoreDirectory = true;
                objUploadPicture.Multiselect = false;

                if (objUploadPicture.ShowDialog() == DialogResult.OK)
                {

                    objFileInfo = new FileInfo(objUploadPicture.FileName);

                    if (objFileInfo.Length > int.Parse(PictureMaxSize))
                    {
                        MessageBox.Show(string.Concat("很抱歉, 您上的图片不能大于", (int.Parse(PictureMaxSize) / 10240).ToString(), "M"));
                    }
                    else
                    {
                        PicturePath = objUploadPicture.FileName;
                        pbPreview.ImageLocation = objUploadPicture.FileName;

                    }
                }
            }

            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                objUploadPicture.Dispose();
            }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            pbPreview.ImageLocation = string.Empty;
        }


        private void UpdatePicture(string PictureName) {
            if (IsEditModel)
            {
                GetStudentInstance().FeatureUpdate(StudentFeatureID, PictureName);
            }
        }


        private void btnSaveImage_Click(object sender, EventArgs e)
        {

            if (IsCameraMode) {
                btnSave.Enabled = true;
                MessageBox.Show(string.Concat(txtName.Text.Trim(), "的照片采集成功!"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } 

            try
            {
                if (ValidateField())
                {

                    var DestFilePath = InitSettings.GetPicturePath;
                    var FileExtension = Path.GetExtension(PicturePath);
                    var FileName = txtStudentNo.Text.Trim();

                    PictureName = string.Concat(FileName, FileExtension);

                    var DestFileName = string.Concat(DestFilePath, FileName, FileExtension);


                    if (!File.Exists(DestFileName))
                    {
                        
                        objFileInfo.CopyTo(DestFileName);
                        btnSave.Enabled = true;
                        MessageBox.Show(string.Concat(txtName.Text.Trim(), "的照片采集成功!"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show(string.Concat(txtName.Text.Trim(), "照片已存在，继续操作将覆盖已有照片,是否继续上传？"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            File.Delete(DestFileName);
                            objFileInfo.CopyTo(DestFileName);
                            if (IsEditModel && !string.IsNullOrEmpty(txtStudentNo.Text.Trim())) UpdatePicture(PictureName);
                            MessageBox.Show(string.Concat(txtName.Text.Trim(), "的照片采集成功!"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSave.Enabled = true;
                        }

                    }


                }
            }
            catch (Exception ex) {
                //log ex
            }
            finally
            {

            }
            

        }


        private void BindClass() {
            
            if (GetClassInstance().GetAll().Rows.Count > 0) {
                cbClass.DataSource = GetClassInstance().GetAll();
                cbClass.DisplayMember = "Name";
                cbClass.ValueMember = "ID";
                cbClass.SelectedIndex = 0;
            }
        }


        private void gbImage_Enter(object sender, EventArgs e)
        {

        }


        private void pbCamera_Click(object sender, EventArgs e)
        {
            VideoPlayer.Stop();
            if (ValidateField())
            {

                IsCameraMode = true;
                pbPreview.Visible = false;

                VideoPlayer.Visible = true;

                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                videoSource = new VideoCaptureDevice(videoDevices[InitSettings.GetCameraDeviceIndex].MonikerString);
                videoSource.VideoResolution = videoSource.VideoCapabilities[InitSettings.GetCameraDeviceIndex];
                VideoPlayer.VideoSource = videoSource;
                VideoPlayer.Start();

            }

        }

        private void btnTakePhoto_Click(object sender, EventArgs e)
        {
            if (videoSource == null)
            {
                MessageBox.Show("请先单击下方图标启动摄像头!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                PictureName = string.Concat(txtStudentNo.Text.Trim(), ".jpg");
                Bitmap bitmap = VideoPlayer.GetCurrentVideoFrame();
                bitmap.Save(string.Concat(InitSettings.GetPicturePath, PictureName), ImageFormat.Jpeg);
                bitmap.Dispose();
                VideoPlayer.Stop();
                VideoPlayer.Visible = false;
                pbPreview.Visible = true;
                pbPreview.ImageLocation = string.Concat(InitSettings.GetPicturePath, PictureName);
            }
            
        }

        private void frmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            VideoPlayer.Stop();
        }

    }
}
