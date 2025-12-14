using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Group: IIdentifiable, IManageable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public string GetInfo()
        {
            return $"Группа: {Name} (ID: {Id}), Студентов: {Students.Count}";
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine($"Студент {student.Name} добавлен в группу {Name}");
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
            Console.WriteLine($"Студент {student.Name} удален из группы {Name}");
        }

        public void DisplayStudents()
        {
            Console.WriteLine($"\n--- Студенты группы {Name} ---");
            foreach (var student in Students)
            {
                Console.WriteLine($"  {student.Name}");
            }
        }
    }
}
