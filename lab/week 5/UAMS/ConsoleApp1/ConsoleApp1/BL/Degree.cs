using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.UI;

namespace UAMS.BL
{
    internal class DegreeProgramBL
    {
        public string degreeName;
        public float degreeDuration;
        public List<SubjectBL> subjects;
        public int seats;

        public DegreeProgramBL(string degreeName, float degreeDuration, int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;
            subjects = new List<SubjectBL>();
        }

        public int CalcualateCreditHours()
        {
            int count = 0;
            for (int i = 0; i < subjects.Count; i++)
            {
                count = count + subjects[i].creditHours;
            }
            return count;
        }

        public bool AddSubject(SubjectBL s)
        {
            int creditHours = CalcualateCreditHours();
            if (creditHours + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool IsSubjectExists(SubjectBL sub)
        {
            foreach (SubjectBL s in subjects)
            {
                if (s.code == sub.code)
                {
                    return true;
                }
            }

            return false;
        }
    }
}