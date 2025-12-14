using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public interface IManageable
    {
        void AddStudent(Student student);
        void RemoveStudent(Student student);
        void DisplayStudents();
    }
}
