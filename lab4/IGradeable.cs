using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public interface IGradeable
    {
        void AddGrade(Subject subject, int grade);
        double CalculateAverageGrade();
        void DisplayGrades();
    }
}
