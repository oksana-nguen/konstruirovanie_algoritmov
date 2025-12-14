using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using lab3;

public class Program
{
    private static List<Institute> institutes = new List<Institute>();
    private static List<Subject> subjects = new List<Subject>();

    public static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== МЕНЮ ПРОГРАММЫ ===");
            Console.WriteLine("1. Добавить институт");
            Console.WriteLine("2. Добавить курс");
            Console.WriteLine("3. Добавить группу");
            Console.WriteLine("4. Добавить предмет");
            Console.WriteLine("5. Добавить студента");
            Console.WriteLine("6. Добавить оценку студенту");
            Console.WriteLine("7. Просмотреть все данные");
            Console.WriteLine("8. Удалить данные");
            Console.WriteLine("9. Редактировать данные");
            Console.WriteLine("10. Выполнить запрос: группы без двоечников");
            Console.WriteLine("11. Выход из программы");
            Console.Write("Выберите пункт меню: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddInstitute();
                    break;
                case "2":
                    AddCourse();
                    break;
                case "3":
                    AddGroup();
                    break;
                case "4":
                    AddSubject();
                    break;
                case "5":
                    AddStudent();
                    break;
                case "6":
                    AddGrade();
                    break;
                case "7":
                    ViewAllData();
                    break;
                case "8":
                    DeleteData();
                    break;
                case "9":
                    EditData();
                    break;
                case "10":
                    ExecuteQuery();
                    break;
                case "11":
                    exit = true;
                    Console.WriteLine("Выход из программы...");
                    break;
                default:
                    Console.WriteLine("Неверный выбор! Попробуйте снова.");
                    break;
            }
        }
    }
    private static void AddInstitute()
    {
        Console.Write("Введите название института: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Название не может быть пустым!");
            return;
        }

        institutes.Add(new Institute { Name = name });
        Console.WriteLine($"Институт '{name}' успешно добавлен!");
    }
    private static void AddCourse()
    {
        if (institutes.Count == 0)
        {
            Console.WriteLine("Сначала добавьте институт!");
            return;
        }

        Console.WriteLine("Выберите институт:");
        for (int i = 0; i < institutes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {institutes[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int instituteIndex) && instituteIndex > 0 && instituteIndex <= institutes.Count)
        {
            Console.Write("Введите номер курса: ");
            if (int.TryParse(Console.ReadLine(), out int courseNumber) && courseNumber > 0)
            {
                institutes[instituteIndex - 1].Courses.Add(new Course { Number = courseNumber });
                Console.WriteLine($"Курс {courseNumber} успешно добавлен!");
            }
            else
            {
                Console.WriteLine("Неверный номер курса!");
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор института!");
        }
    }
    private static void AddGroup()
    {
        var course = SelectCourse();
        if (course == null) return;

        Console.Write("Введите название группы: ");
        string groupName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(groupName))
        {
            Console.WriteLine("Название группы не может быть пустым!");
            return;
        }

        course.Groups.Add(new Group { Name = groupName });
        Console.WriteLine($"Группа '{groupName}' успешно добавлена!");
    }
    private static void AddSubject()
    {
        Console.Write("Введите название предмета: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Название предмета не может быть пустым!");
            return;
        }

        subjects.Add(new Subject { Name = name });
        Console.WriteLine($"Предмет '{name}' успешно добавлен!");
    }
    private static void AddStudent()
    {
        var group = SelectGroup();
        if (group == null) return;

        Console.Write("Введите имя студента: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Имя студента не может быть пустым!");
            return;
        }

        group.Students.Add(new Student { Name = name });
        Console.WriteLine($"Студент '{name}' успешно добавлен в группу '{group.Name}'!");
    }
    private static void AddGrade()
    {
        var student = SelectStudent();
        if (student == null) return;

        if (subjects.Count == 0)
        {
            Console.WriteLine("Сначала добавьте предметы!");
            return;
        }

        Console.WriteLine("Выберите предмет:");
        for (int i = 0; i < subjects.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {subjects[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int subjectIndex) && subjectIndex > 0 && subjectIndex <= subjects.Count)
        {
            Console.Write("Введите оценку (2-5): ");
            if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 2 && grade <= 5)
            {
                student.Grades[subjects[subjectIndex - 1]] = grade;
                Console.WriteLine($"Оценка {grade} по предмету '{subjects[subjectIndex - 1].Name}' успешно добавлена!");
            }
            else
            {
                Console.WriteLine("Неверная оценка! Допустимые значения: 2-5");
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор предмета!");
        }
    }
    private static void ViewAllData()
    {
        if (institutes.Count == 0)
        {
            Console.WriteLine("Данные отсутствуют!");
            return;
        }

        foreach (var institute in institutes)
        {
            Console.WriteLine($"\nИнститут: {institute.Name}");
            foreach (var course in institute.Courses)
            {
                Console.WriteLine($"  Курс {course.Number}:");
                foreach (var group in course.Groups)
                {
                    Console.WriteLine($"    Группа: {group.Name}");
                    foreach (var student in group.Students)
                    {
                        Console.WriteLine($"      Студент: {student.Name}");
                        foreach (var grade in student.Grades)
                        {
                            Console.WriteLine($"        {grade.Key.Name}: {grade.Value}");
                        }
                    }
                }
            }
        }
    }
    private static void DeleteData()
    {
        Console.WriteLine("\n=== УДАЛЕНИЕ ДАННЫХ ===");
        Console.WriteLine("1. Удалить институт");
        Console.WriteLine("2. Удалить курс");
        Console.WriteLine("3. Удалить группу");
        Console.WriteLine("4. Удалить студента");
        Console.WriteLine("5. Удалить предмет");
        Console.Write("Выберите тип данных для удаления: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                DeleteInstitute();
                break;
            case "2":
                DeleteCourse();
                break;
            case "3":
                DeleteGroup();
                break;
            case "4":
                DeleteStudent();
                break;
            case "5":
                DeleteSubject();
                break;
            default:
                Console.WriteLine("Неверный выбор!");
                break;
        }
    }
    private static void EditData()
    {
        Console.WriteLine("\n=== РЕДАКТИРОВАНИЕ ДАННЫХ ===");
        Console.WriteLine("1. Редактировать имя студента");
        Console.WriteLine("2. Редактировать оценку");
        Console.Write("Выберите действие: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                EditStudentName();
                break;
            case "2":
                EditGrade();
                break;
            default:
                Console.WriteLine("Неверный выбор!");
                break;
        }
    }
    private static void ExecuteQuery()
    {
        var groupsWithoutPoorStudents = new List<Group>();

        foreach (var institute in institutes)
        {
            foreach (var course in institute.Courses)
            {
                foreach (var group in course.Groups)
                {
                    bool hasPoorStudents = group.Students.Any(student =>
                        student.Grades.Any(grade => grade.Value == 2));

                    if (!hasPoorStudents && group.Students.Count > 0)
                    {
                        groupsWithoutPoorStudents.Add(group);
                    }
                }
            }
        }
        Console.WriteLine("\n=== ГРУППЫ БЕЗ ДВОЕЧНИКОВ ===");
        if (groupsWithoutPoorStudents.Count == 0)
        {
            Console.WriteLine("Группы без двоечников не найдены.");
        }
        else
        {
            foreach (var group in groupsWithoutPoorStudents)
            {
                Console.WriteLine($"Группа: {group.Name}");
            }
        }
        try
        {
            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                writer.WriteLine("Группы без двоечников:");
                foreach (var group in groupsWithoutPoorStudents)
                {
                    writer.WriteLine($"- {group.Name}");
                }
            }
            Console.WriteLine("\nРезультат записан в файл 'result.txt'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
        }
    }
    private static Course SelectCourse()
    {
        if (institutes.Count == 0)
        {
            Console.WriteLine("Сначала добавьте институт!");
            return null;
        }

        Console.WriteLine("Выберите институт:");
        for (int i = 0; i < institutes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {institutes[i].Name}");
        }

        if (!int.TryParse(Console.ReadLine(), out int instituteIndex) || instituteIndex <= 0 || instituteIndex > institutes.Count)
        {
            Console.WriteLine("Неверный выбор института!");
            return null;
        }

        var selectedInstitute = institutes[instituteIndex - 1];

        if (selectedInstitute.Courses.Count == 0)
        {
            Console.WriteLine("В этом институте нет курсов!");
            return null;
        }

        Console.WriteLine("Выберите курс:");
        for (int i = 0; i < selectedInstitute.Courses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Курс {selectedInstitute.Courses[i].Number}");
        }

        if (!int.TryParse(Console.ReadLine(), out int courseIndex) || courseIndex <= 0 || courseIndex > selectedInstitute.Courses.Count)
        {
            Console.WriteLine("Неверный выбор курса!");
            return null;
        }

        return selectedInstitute.Courses[courseIndex - 1];
    }
    private static Group SelectGroup()
    {
        var course = SelectCourse();
        if (course == null) return null;

        if (course.Groups.Count == 0)
        {
            Console.WriteLine("На этом курсе нет групп");
            return null;
        }

        Console.WriteLine("Выберите группу:");
        for (int i = 0; i < course.Groups.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {course.Groups[i].Name}");
        }

        if (!int.TryParse(Console.ReadLine(), out int groupIndex) || groupIndex <= 0 || groupIndex > course.Groups.Count)
        {
            Console.WriteLine("Неверный выбор группы");
            return null;
        }

        return course.Groups[groupIndex - 1];
    }
    private static Student SelectStudent()
    {
        var group = SelectGroup();
        if (group == null) return null;

        if (group.Students.Count == 0)
        {
            Console.WriteLine("В этой группе нет студентов");
            return null;
        }

        Console.WriteLine("Выберите студента:");
        for (int i = 0; i < group.Students.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {group.Students[i].Name}");
        }

        if (!int.TryParse(Console.ReadLine(), out int studentIndex) || studentIndex <= 0 || studentIndex > group.Students.Count)
        {
            Console.WriteLine("Неверный выбор студента");
            return null;
        }

        return group.Students[studentIndex - 1];
    }
    private static void DeleteInstitute()
    {
        if (institutes.Count == 0)
        {
            Console.WriteLine("Институты отсутствуют");
            return;
        }

        Console.WriteLine("Выберите институт для удаления:");
        for (int i = 0; i < institutes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {institutes[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= institutes.Count)
        {
            string name = institutes[index - 1].Name;
            institutes.RemoveAt(index - 1);
            Console.WriteLine($"Институт '{name}' удален");
        }
        else
        {
            Console.WriteLine("Неверный выбор");
        }
    }
    private static void DeleteCourse()
    {
        var institute = SelectInstitute();
        if (institute == null) return;

        if (institute.Courses.Count == 0)
        {
            Console.WriteLine("Курсы отсутствуют");
            return;
        }

        Console.WriteLine("Выберите курс для удаления");
        for (int i = 0; i < institute.Courses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Курс {institute.Courses[i].Number}");
        }

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= institute.Courses.Count)
        {
            int number = institute.Courses[index - 1].Number;
            institute.Courses.RemoveAt(index - 1);
            Console.WriteLine($"Курс {number} удален");
        }
        else
        {
            Console.WriteLine("Неверный выбор");
        }
    }
    private static void DeleteGroup()
    {
        var course = SelectCourse();
        if (course == null) return;

        if (course.Groups.Count == 0)
        {
            Console.WriteLine("Группы отсутствуют");
            return;
        }

        Console.WriteLine("Выберите группу для удаления:");
        for (int i = 0; i < course.Groups.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {course.Groups[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= course.Groups.Count)
        {
            string name = course.Groups[index - 1].Name;
            course.Groups.RemoveAt(index - 1);
            Console.WriteLine($"Группа '{name}' удалена");
        }
        else
        {
            Console.WriteLine("Неверный выбор");
        }
    }
    private static void DeleteStudent()
    {
        var group = SelectGroup();
        if (group == null) return;

        if (group.Students.Count == 0)
        {
            Console.WriteLine("Студенты отсутствуют");
            return;
        }

        Console.WriteLine("Выберите студента для удаления:");
        for (int i = 0; i < group.Students.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {group.Students[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= group.Students.Count)
        {
            string name = group.Students[index - 1].Name;
            group.Students.RemoveAt(index - 1);
            Console.WriteLine($"Студент '{name}' удален");
        }
        else
        {
            Console.WriteLine("Неверный выбор");
        }
    }
    private static void DeleteSubject()
    {
        if (subjects.Count == 0)
        {
            Console.WriteLine("Предметы отсутствуют");
            return;
        }

        Console.WriteLine("Выберите предмет для удаления:");
        for (int i = 0; i < subjects.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {subjects[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= subjects.Count)
        {
            string name = subjects[index - 1].Name;
            subjects.RemoveAt(index - 1);
            Console.WriteLine($"Предмет '{name}' удален");
        }
        else
        {
            Console.WriteLine("Неверный выбор");
        }
    }
    private static void EditStudentName()
    {
        var student = SelectStudent();
        if (student == null) return;

        Console.Write("Введите новое имя студента: ");
        string newName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newName))
        {
            Console.WriteLine("Имя не может быть пустым");
            return;
        }

        string oldName = student.Name;
        student.Name = newName;
        Console.WriteLine($"Имя студента изменено с '{oldName}' на '{newName}'");
    }
    private static void EditGrade()
    {
        var student = SelectStudent();
        if (student == null) return;

        if (student.Grades.Count == 0)
        {
            Console.WriteLine("У студента нет оценок!");
            return;
        }

        Console.WriteLine("Выберите предмет для изменения оценки:");
        var gradeList = student.Grades.ToList();
        for (int i = 0; i < gradeList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {gradeList[i].Key.Name}: {gradeList[i].Value}");
        }

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= gradeList.Count)
        {
            Console.Write("Введите новую оценку: ");
            if (int.TryParse(Console.ReadLine(), out int newGrade) && newGrade >= 2 && newGrade <= 5)
            {
                var subject = gradeList[index - 1].Key;
                student.Grades[subject] = newGrade;
                Console.WriteLine($"Оценка по предмету '{subject.Name}' изменена на {newGrade}");
            }
            else
            {
                Console.WriteLine("Неверная оценка");
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор");
        }
    }

    private static Institute SelectInstitute()
    {
        if (institutes.Count == 0)
        {
            Console.WriteLine("Институты отсутствуют");
            return null;
        }

        Console.WriteLine("Выберите институт:");
        for (int i = 0; i < institutes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {institutes[i].Name}");
        }

        if (!int.TryParse(Console.ReadLine(), out int index) || index <= 0 || index > institutes.Count)
        {
            Console.WriteLine("Неверный выбор института");
            return null;
        }

        return institutes[index - 1];
    }
}
