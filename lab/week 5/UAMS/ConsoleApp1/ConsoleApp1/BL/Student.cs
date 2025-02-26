using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.UI;

namespace UAMS.BL
{
    internal class StudentBL
    {
        public string name;
        public int age;
        public double fscMarks;
        public double ecatMarks;
        public double merit;
        public List<DegreeProgramBL> Preferences;
        public List<SubjectBL> regSubject;
        public DegreeProgramBL regDegree;

        public StudentBL(string name, int age, double fscMarks, double ecatMarks, List<DegreeProgramBL> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.Preferences = preferences;
            regSubject = new List<SubjectBL>();

        }

        public void CalculateMerit()
        {
            this.merit = (((fscMarks / 1100) * 0.45F) + ((ecatMarks / 400) * 0.55f)) * 100;
        }

        public bool RegStudentSubject(SubjectBL s)
        {
            int stCH = GetCreditHours();
            if (regDegree != null && regDegree.IsSubjectExists(s) && stCH + s.creditHours <= 9)
            {
                regSubject.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }



        public int GetCreditHours()
        {
            int count = 0;
            foreach (SubjectBL sub in regSubject)
            {
                count = count + sub.creditHours;
            }
            return count;
        }

        public float CalculateFee()
        {
            float fee = 0;
            if (regDegree != null)
            {
                foreach (SubjectBL sub in regSubject)
                {
                    fee = fee + sub.subjectFees;
                }
            }
            return fee;
        }

        public static void GiveAdmission(List<BL.StudentBL> sortedStudentList)
        {
            foreach (BL.StudentBL s in sortedStudentList)
            {
                foreach (BL.DegreeProgramBL d in s.Preferences)
                {
                    if (d.seats > 0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }


        public static BL.StudentBL StudentPresent(string name)
        {
            foreach (BL.StudentBL s in DL.StudentDL.StudentList)
            {
                if (name == s.name && s.regDegree != null)
                {
                    return s;
                }
            }

            return null;
        }


    }
}