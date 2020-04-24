using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIS.DBScript;

namespace MIS.Business
{
    class Class
    {

        public DataTable GetAll() {
            var result = new DataTable();
            var Sql = string.Empty;
            try
            {
                Sql = DBScript.DBScript.GetAllClass;
                var Classes  = InitSettings.GetDBManager().ExecuteRow(Sql, null, null);

                result.Columns.Add("ID",Type.GetType("System.Int32"));
                result.Columns.Add("Name", Type.GetType("System.String"));

                foreach (object c in Classes) {
                    var d = (Dictionary<string, object>)c;
                    result.Rows.Add(new Object[] {Convert.ToInt16(d["ID"]), d["Name"].ToString() });
                }

            }
            finally {

            }
            return result;
        }

        public bool Insert(string Name) {

            var Result = false;
            try
            {
                Dictionary<string, object> entity = new Dictionary<string, object>();
                entity.Add("Name", Name);
                InitSettings.GetDBManager().Save("Class", entity);
                Result = true;
            }
            finally {

            }
            return Result;
        }

        public bool Update(int ID, string Name) {
            var Result = false;
            try
            {
                Dictionary<string, object> entity = new Dictionary<string, object>();
                entity.Add("Name", Name);
                if (InitSettings.GetDBManager().Update("Class", entity, "ID=@ID", new System.Data.SQLite.SQLiteParameter[] {new System.Data.SQLite.SQLiteParameter("ID",ID)}) > 0) {
                    Result = true;
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
                if (InitSettings.GetDBManager().Delete("Class", "ID=@ID", new System.Data.SQLite.SQLiteParameter[] { new System.Data.SQLite.SQLiteParameter("ID", ID) }) > 0)
                {
                    Result = true;
                }

            }
            finally
            {

            }
            return Result;
        }


    }
}
