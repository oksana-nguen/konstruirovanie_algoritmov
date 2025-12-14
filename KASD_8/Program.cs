using System;
using KASD_8;
int[] a = { 1, 6, 8, 2, 4, 1, 9, 3 };
var arr = new MyArrayList<int>();
var arr1 = new MyArrayList<int>(a);

Console.WriteLine($"Динамический массив arr пуст? {arr.isEmpty()}");
Console.WriteLine($"Массив arr1: ");
arr1.Print();

arr.Add(3);
arr.Add(6);
arr.Add(2);
arr.Add(10);
Console.WriteLine("Массив после добавления: ");
arr.Print();
arr1.Clear();

Console.WriteLine($"Динамический массив arr1 после Clear пуст? {arr1.isEmpty()}");

Console.WriteLine($"Есть ли элемент 3 в массиве arr? {arr.Contains(3)}");

Console.WriteLine($"Есть ли элемент 100 в массиве arr? {arr.Contains(100)}");

int[] b = { 2, 3 };
Console.WriteLine($"Есть ли все элементы массива b в массиве arr? {arr.ContainsAll(b)}");

int[] c = { 2, 100 };
Console.WriteLine($"Есть ли все элементы массива c в массиве arr? {arr.ContainsAll(c)}");

Console.WriteLine($"\nРазмер arr: {arr.Size()}");

Console.WriteLine($"Первый индекс элемента 6: {arr.IndexOf(6)}");

Console.WriteLine($"Последний индекс элемента 1 в arr1: {arr1.IndexOf(1)}");

int[] arrCopy = arr.toArray();
Console.WriteLine($"\nКопия массива arr: [{string.Join(", ", arrCopy)}]");

Console.WriteLine($"\nУдаляем элемент 2: {arr.Remove(2)}");
Console.WriteLine($"После удаления: ");
arr.Print();

arr.Add(1, 99);
Console.WriteLine($"После Add(1, 99): ");
arr.Print();

arr.Set(0, 1000);
Console.WriteLine($"После Set(0, 1000): ");
arr.Print();

if (arr.Size() >= 3)
{
    int[] sublist = arr.Sublist(1, 3);
    Console.WriteLine($"Sublist(1, 3): [{string.Join(", ", sublist)}]");
}

