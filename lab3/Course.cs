using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Course
    {
        public int Number { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
