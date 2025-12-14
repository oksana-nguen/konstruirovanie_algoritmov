using System;
using KASD_2;
using System;

Complex current = new Complex(0, 0); 
bool running = true;

Console.WriteLine("Калькулятор комплексных чисел");
Console.WriteLine("Текущее число: " + current);

while (running)
{
    Console.WriteLine("\nМеню:");
    Console.WriteLine("C - Создать новое число");
    Console.WriteLine("+ - Сложить");
    Console.WriteLine("- - Вычесть");
    Console.WriteLine("* - Умножить");
    Console.WriteLine("/ - Разделить");
    Console.WriteLine("M - Модуль");
    Console.WriteLine("A - Аргумент");
    Console.WriteLine("R - Вещественная часть");
    Console.WriteLine("I - Мнимая часть");
    Console.WriteLine("P - Вывести текущее число");
    Console.WriteLine("Q - Выход");
    Console.Write("Выберите команду: ");

    char command = Console.ReadKey().KeyChar;
    Console.WriteLine();

            try
            {
                switch (command)
                {
                    case 'C': 
                        Console.Write("Введите вещественную часть: ");
                        double real = double.Parse(Console.ReadLine());
                        Console.Write("Введите мнимую часть: ");
                        double imaginary = double.Parse(Console.ReadLine());
                        current = Complex.Create(real, imaginary);
                        current.Print();
                        break;

                    case '+': 
                        Console.Write("Введите вещественную часть второго числа: ");
                        double r2 = double.Parse(Console.ReadLine());
                        Console.Write("Введите мнимую часть второго числа: ");
                        double i2 = double.Parse(Console.ReadLine());
                        Complex b1 = new Complex(r2, i2);
                        current = Complex.Add(current.GetReal(),current.GetImaginary(),r2,i2);
                        current.Print();
                        break;

                    case '-': 
                        Console.Write("Введите вещественную часть второго числа: ");
                        double r3 = double.Parse(Console.ReadLine());
                        Console.Write("Введите мнимую часть второго числа: ");
                        double i3 = double.Parse(Console.ReadLine());
                        Complex b2 = new Complex(r3, i3);
                        current = Complex.Subtract(current.GetReal(), current.GetImaginary(), r3, i3);
                        current.Print();
                        break;

                    case '*': 
                        Console.Write("Введите вещественную часть второго числа: ");
                        double r4 = double.Parse(Console.ReadLine());
                        Console.Write("Введите мнимую часть второго числа: ");
                        double i4 = double.Parse(Console.ReadLine());
                        Complex b3 = new Complex(r4, i4);
                        current = Complex.Multiplication(current.GetReal(), current.GetImaginary(), r4, i4);
                        current.Print();
                        break;

                    case '/': 
                        Console.Write("Введите вещественную часть второго числа: ");
                        double r5 = double.Parse(Console.ReadLine());
                        Console.Write("Введите мнимую часть второго числа: ");
                        double i5 = double.Parse(Console.ReadLine());
                        Complex b4 = new Complex(r5, i5);
                        current = Complex.Division(current.GetReal(), current.GetImaginary(), r5, i5);
                        current.Print();
                        break;

                    case 'M': 
                        Console.WriteLine($"Модуль: {current.Abs()}");
                        break;

                    case 'A': 
                        double arg = current.Arg();
                        Console.WriteLine($"Аргумент: {arg:F2} радиан");
                        break;

                    case 'R': 
                        Console.WriteLine($"Вещественная часть: {current.GetReal():F2}");
                        break;

                    case 'I': 
                        Console.WriteLine($"Мнимая часть: {current.GetImaginary():F2}");
                        break;

                    case 'P': 
                        Console.WriteLine("Текущее число: " + current);
                        break;

                    case 'Q':
                        running = false;
                        Console.WriteLine("Конец");
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: неверный формат числа!");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
}
