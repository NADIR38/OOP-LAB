using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.UI;

namespace UAMS.DL
{
    internal class DegreeProgramDL
    {
        public static List<DegreeProgramBL> ProgramList = new List<DegreeProgramBL>();
        public static void addIntoDegreeList(BL.DegreeProgramBL d)
        {
            ProgramList.Add(d);
        }
    }
}