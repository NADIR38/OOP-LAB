
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.DL
{
    internal class StudentDL
    {
        public static List<StudentBL> StudentList = new List<StudentBL>();

        public static void AddIntoStudentList(StudentBL s)
        {
            StudentList.Add(s);
        }

        public static List<BL.StudentBL> SortStudentsByMerit()
        {
            List<BL.StudentBL> sortedStudentList = new List<BL.StudentBL>();
            foreach (BL.StudentBL s in DL.StudentDL.StudentList)
            {
                s.CalculateMerit();
            }

            sortedStudentList = StudentList.OrderByDescending(o => o.merit).ToList();
            return sortedStudentList;
        }
    }
}
