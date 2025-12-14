using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Institute
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
