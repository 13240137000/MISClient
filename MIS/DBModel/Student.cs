using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DBModel
{
    class Student
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string StudentNo { get; set; }
        public string ParentName { get; set; }
        public string ParentMobile { get; set; }
        public string Note { get; set; }
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string PictureName { get; set; }
        public int StudentFeatureID { get; set; }
        public int StudentClassID { get; set; }
    }
}
