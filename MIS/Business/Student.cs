using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIS.DBScript;

namespace MIS.Business
{
    class Student
    {

        public List<object> GetStudentByStudentNo(string StudentNo) {
            var Result = new List<object>();
            var Sql = string.Empty;
            try
            {
                Sql = string.Format(DBScript.DBScript.GetStudentByStudentNoForInsert,StudentNo);
                Result = InitSettings.GetDBManager().ExecuteRow(Sql, null, null);
                
            }
            finally
            {

            }
            return Result;
        }

        public DBModel.Student GetStudentAndClassByStudentID(int ID)
        {
            var Result = new DBModel.Student();
            var Students = new List<object>();
            var Sql = string.Empty;
            try
            {
                Sql = string.Format(DBScript.DBScript.GetStudentAndClassByStudentID, ID);
                Students = InitSettings.GetDBManager().ExecuteRow(Sql, null, null);
                if (Students.Count > 0)
                {
                    var d = (Dictionary<string, object>)Students[0];
                    Result.ID = Convert.ToInt16(d["ID"]);
                    Result.ClassID = Convert.ToInt16(d["ClassID"]);
                    Result.Gender = Convert.ToInt16(d["Gender"]);
                    Result.ParentName = Convert.ToString(d["ParentName"]);
                    Result.ParentMobile = Convert.ToString(d["ParentMobile"]);
                    Result.ClassName = Convert.ToString(d["ClassName"]);
                    Result.Note = Convert.ToString(d["Note"]);
                    Result.PictureName = Convert.ToString(d["PictureName"]);
                    Result.StudentNo = Convert.ToString(d["StudentNo"]);
                    Result.Name = Convert.ToString(d["Name"]);
                    Result.StudentFeatureID = Convert.ToInt16(d["StudentFeatureID"]);
                    Result.StudentClassID = Convert.ToInt16(d["StudentClassID"]);
                }
            }
            finally
            {

            }
            return Result;
        }

        public int Insert(string Name, int Gender, string StudentNo, string ParentName, string ParentMobile, string Note)
        {
            var Result = 0;
            try
            {
                Dictionary<string, object> entity = new Dictionary<string, object>();
                entity.Add("Name", Name);
                entity.Add("Gender", Gender);
                entity.Add("StudentNo", StudentNo);
                entity.Add("ParentName", ParentName);
                entity.Add("ParentMobile", ParentMobile);
                entity.Add("Note", Note);
                if (InitSettings.GetDBManager().Save("Student", entity) > 0) {
                    var Student = this.GetStudentByStudentNo(StudentNo);
                    if (Student.Count > 0) {
                        var d = (Dictionary<string, object>)Student[0];
                        Result = Convert.ToInt16(d["ID"]);
                    }
                }
            }
            finally
            {

            }
            return Result;
        }

        public bool Delete(int ID)
        {
            var Result = false;
            try
            {
                if (InitSettings.GetDBManager().Delete("Student", "ID=@ID", new System.Data.SQLite.SQLiteParameter[] { new System.Data.SQLite.SQLiteParameter("ID", ID) }) > 0)
                {
                    Result = true;
                }

            }
            finally
            {

            }
            return Result;
        }

        public bool FeatureInsert(int StudentID, string PictureName) {
            var Result = false;
            try
            {
                Dictionary<string, object> entity = new Dictionary<string, object>();
                entity.Add("StudentID", StudentID);
                entity.Add("PictureName", PictureName);
                InitSettings.GetDBManager().Save("StudentFeatures", entity);
                Result = true;
            }
            finally
            {

            }
            return Result;
        }

        public bool FeatureUpdate(int ID, string PictureName) {
            var result = false;
            try
            {
                Dictionary<string, object> entity = new Dictionary<string, object>();
                entity.Add("PictureName", PictureName);
                if (InitSettings.GetDBManager().Update("StudentFeatures", entity, "ID=@ID", new System.Data.SQLite.SQLiteParameter[] { new System.Data.SQLite.SQLiteParameter("ID", ID) }) > 0)
                {
                    result = true;
                }
            }
            finally {

            }
            return result;
        }

        public bool Update(int ID, string Name, int Gender,string StudentNo, string ParentName, string ParentMobile, string Note) {
            var result = false;
            try
            {
                Dictionary<string, object> entity = new Dictionary<string, object>();
                entity.Add("Name", Name);
                entity.Add("Gender", Gender);
                entity.Add("ParentName", ParentName);
                entity.Add("ParentMobile", ParentMobile);
                entity.Add("StudentNo", StudentNo);
                entity.Add("Note", Note);
                entity.Add("IsExtractFeature", 0);
                if (InitSettings.GetDBManager().Update("Student", entity, "ID=@ID", new System.Data.SQLite.SQLiteParameter[] { new System.Data.SQLite.SQLiteParameter("ID", ID) }) > 0)
                {
                    result = true;
                }
            }
            finally
            {

            }
            return result;
        }

        public bool ClassUpdate(int ID,int StudentClassID)
        {
            var result = false;
            try
            {
                Dictionary<string, object> entity = new Dictionary<string, object>();
                entity.Add("ClassID", StudentClassID);
                if (InitSettings.GetDBManager().Update("ClassStudent", entity, "ID=@ID", new System.Data.SQLite.SQLiteParameter[] { new System.Data.SQLite.SQLiteParameter("ID", ID) }) > 0)
                {
                    result = true;
                }
            }
            finally
            {

            }
            return result;
        }



        public bool ClassStudentInsert(int StudentID, int ClassID)
        {
            var Result = false;
            try
            {
                Dictionary<string, object> entity = new Dictionary<string, object>();
                entity.Add("StudentID", StudentID);
                entity.Add("ClassID", ClassID);
                InitSettings.GetDBManager().Save("ClassStudent", entity);
                Result = true;
            }
            finally
            {

            }
            return Result;
        }

        public DataTable GetAll(string Name = "", string StudentNo = "", int ClassID = 0)
        {
            var result = new DataTable();
            var Sql = string.Empty;
            try
            {

                Sql = DBScript.DBScript.GetAllStudent;

                if (!string.IsNullOrWhiteSpace(Name)) {
                    Sql = string.Format(DBScript.DBScript.GetStudentByName,Name);
                }

                if (!string.IsNullOrWhiteSpace(StudentNo))
                {
                    Sql = string.Format(DBScript.DBScript.GetStudentByStudentNo, StudentNo);
                }

                if (ClassID > 0) {
                    Sql = string.Format(DBScript.DBScript.GetStudentByClassID, ClassID);
                }


                var Students = InitSettings.GetDBManager().ExecuteRow(Sql, null, null);

                result.Columns.Add("ID", Type.GetType("System.Int32"));
                result.Columns.Add("Name", Type.GetType("System.String"));
                result.Columns.Add("Gender", Type.GetType("System.Int32"));
                result.Columns.Add("StudentNo", Type.GetType("System.String"));
                result.Columns.Add("ParentName", Type.GetType("System.String"));
                result.Columns.Add("ParentMobile", Type.GetType("System.String"));
                result.Columns.Add("Note", Type.GetType("System.String"));
                result.Columns.Add("IsExtractFeature", Type.GetType("System.Int32"));
                result.Columns.Add("ClassName", Type.GetType("System.String"));

                // (int.Parse(d["Gender"].ToString()) == 1) ? "男" : "女",

                foreach (object s in Students)
                {
                    var d = (Dictionary<string, object>)s;
                    result.Rows.Add(new Object[] {
                        Convert.ToInt16(d["ID"]),
                        d["Name"].ToString(),
                        d["Gender"].ToString(),
                        d["StudentNo"].ToString(),
                        d["ParentName"].ToString(),
                        d["ParentMobile"].ToString(),
                        d["Note"].ToString(),
                        Convert.ToInt16(d["IsExtractFeature"]),
                        d["ClassName"].ToString()
                    });
                }

            }
            finally
            {

            }
            return result;
        }


    }
}
