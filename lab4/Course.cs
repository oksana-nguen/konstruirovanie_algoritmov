using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Course: IIdentifiable
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
        public string GetInfo()
        {
            return $"Курс: {Number} (ID: {Id}), Групп: {Groups.Count}";
        }
    }
}
