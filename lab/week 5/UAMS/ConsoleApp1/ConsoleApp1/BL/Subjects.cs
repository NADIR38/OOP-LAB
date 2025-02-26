using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    internal class SubjectBL
    {
        public string code;
        public string type;
        public int creditHours;
        public int subjectFees;

        public SubjectBL(string code, string type, int creditHours, int subjectFees)

        {

            this.code = code;
            this.type = type;
            this.creditHours = creditHours;
            this.subjectFees = subjectFees;

        }
    }
}