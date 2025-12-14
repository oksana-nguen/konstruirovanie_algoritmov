using System;
using KASD_10;
int[] a = { 1, 6, 8, 2, 4, 1, 9, 3 };
var vector = new MyVector<int>();
var vector1 = new MyVector<int>(a);

Console.WriteLine($"Вектор arr пуст? {vector.isEmpty()}");
Console.WriteLine($"Вектор arr1: ");
vector1.Print();

vector.Add(3);
vector.Add(6);
vector.Add(2);
vector.Add(10);
Console.WriteLine("Вектор после добавления: ");
vector.Print();
vector1.Clear();

Console.WriteLine($" Вектор arr1 после Clear пуст? {vector1.isEmpty()}");

Console.WriteLine($"Есть ли элемент 3 в векторе arr? {vector.Contains(3)}");

Console.WriteLine($"Есть ли элемент 100 в векторе arr? {vector.Contains(100)}");

int[] b = { 2, 3 };
Console.WriteLine($"Есть ли все элементы вектора b в векторе arr? {vector.ContainsAll(b)}");

int[] c = { 2, 100 };
Console.WriteLine($"Есть ли все элементы вектора c в вектора arr? {vector.ContainsAll(c)}");

Console.WriteLine($"\nРазмер arr: { vector.Size()}");

Console.WriteLine($"Первый индекс элемента 6: {vector.IndexOf(6)}");

Console.WriteLine($"Последний индекс элемента 1 в arr1: {vector1.IndexOf(1)}");

int[] arrCopy = vector.toArray();
Console.WriteLine($"\nКопия массива arr: [{string.Join(", ", arrCopy)}]");

Console.WriteLine($"\nУдаляем элемент 2: {vector.Remove(2)}");
Console.WriteLine($"После удаления: ");
vector.Print();

vector.Add(1, 99);
Console.WriteLine($"После Add(1, 99): ");
vector.Print();

vector.Set(0, 1000);
Console.WriteLine($"После Set(0, 1000): ");
vector.Print();

if (vector.Size() >= 3)
{
    int[] sublist = vector.Sublist(1, 3);
    Console.WriteLine($"Sublist(1, 3): [{string.Join(", ", sublist)}]");
}
vector.RemoveRange(1, 3);
Console.WriteLine("Вектор после удаления с 1 по 3 число");
vector.Print();


