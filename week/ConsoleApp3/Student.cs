using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public  class Student
    {
        public string Name;
        public float matricmarks;
        public float fscmarks;
        public float ecatmarks;
        public float aggregate;
        public Student(string name,float matric,float fsc,float ecat) 
        { 
        Name = name;
            matricmarks = matric;
            fscmarks = fsc;
            ecatmarks = ecat;
            aggregate = 0.0f;
        }
        public float Aggregates()
        {
            return ((matricmarks/1100.0f )*25) + (fscmarks/1100.0f * 45) + (ecatmarks/400.0f * 30f);
        }
        
    }
}
