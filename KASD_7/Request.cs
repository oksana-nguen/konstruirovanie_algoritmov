using System;
using System.IO;
using System.Collections.Generic;
using KASD_7;

namespace KASD_7
{
    
    public class Request : IComparable<Request>
    {
        public int Priority { get; set; }      
        public int RequestId { get; set; }     
        public int StepAdded { get; set; }     
        public int? StepRemoved { get; set; }  
       
        public Request(int priority, int requestId, int stepAdded)
        {
            Priority = priority;
            RequestId = requestId;
            StepAdded = stepAdded;
            StepRemoved = null;
        }

        
        public int WaitingTime => (StepRemoved ?? 0) - StepAdded;

        
        public int CompareTo(Request other)
        {
            // Сначала сравниваем по приоритету (по убыванию)
            if (other == null) return 1;
            return other.Priority.CompareTo(this.Priority); 
        }

        public override string ToString()
        {
            return $"Заявка #{RequestId}: приоритет={Priority}, добавлена на шаге {StepAdded}, " +
                   $"удалена на шаге {StepRemoved}, время ожидания={WaitingTime}";
        }
    }

}
