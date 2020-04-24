using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DBScript
{
    struct DBScript
    {
        public static string GetAllClass =　"select * from Class order by id desc";
        public static string GetAllStudent = "select s.*, IFNULL(c.Name,'') as 'ClassName' from Student s left join ClassStudent cs on s.ID = cs.StudentID inner join Class c on c.ID = cs.ClassID order by s.id desc";
        public static string GetStudentByName = "select s.*, IFNULL(c.Name,'') as 'ClassName' from Student s left join ClassStudent cs on s.ID = cs.StudentID inner join Class c on c.ID = cs.ClassID where s.name='{0}' COLLATE NOCASE order by id desc";
        public static string GetStudentByStudentNo = "select s.*, IFNULL(c.Name,'') as 'ClassName' from Student s left join ClassStudent cs on s.ID = cs.StudentID inner join Class c on c.ID = cs.ClassID where s.StudentNo = '{0}' COLLATE NOCASE order by s.id desc";
        public static string GetStudentByStudentNoForInsert = "select * from student where StudentNo = '{0}'";
        public static string GetStudentByClassID = "select s.*, IFNULL(c.Name,'') as 'ClassName' from Student s left join ClassStudent cs on s.ID = cs.StudentID inner join Class c on c.ID = cs.ClassID where cs.ClassID = {0} COLLATE NOCASE order by s.id desc";
        public static string GetStudentAndClassByStudentID = "select s.*,c.id as 'ClassID',c.Name as 'ClassName',cs.id as 'StudentClassID',sf.ID as 'StudentFeatureID',sf.PictureName from Student s inner join ClassStudent cs on s.id = cs.StudentID inner join class c on c.id = cs.ClassID inner join StudentFeatures sf on sf.StudentID = s.ID where s.id = {0}";
    }
}
