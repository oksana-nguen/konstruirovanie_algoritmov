using KASD_6;
using System;
using System.Runtime.Intrinsics.X86;
var queue = new MyPriorityQueue<int>();
queue.Add(2);
queue.Add(9);
queue.Add(4);
queue.Add(6);
queue.Add(5);
queue.Add(1);
queue.Add(7);

int[] b = new int[3];
b[0] = 2;
b[1] = 11;
b[2] = 1;
queue.AddAll(b);
Console.WriteLine($"Размер очереди: {queue.Size()}");
int a = 4;
Console.WriteLine($"Находится ли {a} в очереди? {queue.Contains(a)}");

Console.WriteLine("Элемент из головы без удаления");
int peek = queue.Peek();
Console.WriteLine(peek);
Console.WriteLine($"Размер очереди: {queue.Size()}");

Console.WriteLine("Элемент из головы с удалением");
int polled = queue.Poll();
Console.WriteLine(polled);
Console.WriteLine($"Размер очереди: {queue.Size()}");

Console.WriteLine("Очистка очереди ");
queue.Clear();
Console.WriteLine($"Очередь пуста? {queue.isEmpty()}");