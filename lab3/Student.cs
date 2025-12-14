using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Student
    {
        public string Name { get; set; }
        public Dictionary<Subject, int> Grades { get; set; } = new Dictionary<Subject, int>();
    }
}
