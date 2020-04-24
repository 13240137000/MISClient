using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MIS.DBUtility;
using MIS.DBModel;

namespace MIS
{

    public class InitSettings
    {

        #region "Global Vars"

        public static string GetDBPath => ConfigurationManager.AppSettings.Get("DBPath");
        public static string GetDBName => ConfigurationManager.AppSettings.Get("DBName");
        public static string GetPicturePath => ConfigurationManager.AppSettings.Get("PicturePath");
        public static string GetPictureMaxSize => ConfigurationManager.AppSettings.Get("PictureMaxSize");
        public static string GetInitialDirectory => ConfigurationManager.AppSettings.Get("InitialDirectory");
        public static int GetCameraDeviceIndex => int.Parse(ConfigurationManager.AppSettings.Get("CameraDeviceIndex"));


        #endregion

        #region "Global Functions"

        public static bool IsMobileNumber(string Mobile)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(Mobile, @"1[345678]\d{9}$");
        }

        #endregion

        #region "Global DB Manager"

        public static SQLiteHelper GetDBManager() {

            var DBFile = string.Concat(GetDBPath, GetDBName);
            SQLiteHelper Manager = new SQLiteHelper(DBFile);

            try
            {
                Manager.Open();
            }
            finally {

            }

            return Manager;

        }

        #endregion

    }

}
