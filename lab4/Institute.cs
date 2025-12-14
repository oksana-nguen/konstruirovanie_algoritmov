using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Institute: IIdentifiable, IManageable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public string GetInfo()
        {
            return $"Институт: {Name} (ID: {Id}), Курсов: {Courses.Count}";
        }
        public void AddStudent(Student student)
        {
            Console.WriteLine($"Студент {student.Name} зачислен в институт {Name}");
        }

        public void RemoveStudent(Student student)
        {
            Console.WriteLine($"Студент {student.Name} отчислен из института {Name}");
        }
        public void DisplayStudents()
        {
            Console.WriteLine($"\n--- Все студенты института {Name} ---");
            foreach (var course in Courses)
            {
                foreach (var group in course.Groups)
                {
                    foreach (var student in group.Students)
                    {
                        Console.WriteLine($"  {student.Name} (Группа: {group.Name}, Курс: {course.Number})");
                    }
                }
            }
        }
    }
}
