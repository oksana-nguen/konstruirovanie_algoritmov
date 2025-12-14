using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASD_7
{
    
    public class RequestComparer : IComparer<Request>
    {
        public int Compare(Request x, Request y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

           
            int priorityCompare = y.Priority.CompareTo(x.Priority);
            if (priorityCompare != 0) return priorityCompare;

           
            return x.StepAdded.CompareTo(y.StepAdded);
        }
    }
}
