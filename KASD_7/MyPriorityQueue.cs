using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KASD_7
{
    public class MyPriorityQueue<T>
    {
        private T[] queue;
        public T[] Queue { get => queue; }
        private int size;
        private IComparer<T> comparator;

        //пустая очередь с ёмкостьью 11. Приоритет - порядок сортировки
        public MyPriorityQueue()
        {
            queue = new T[11];
            size = 0;
            comparator = Comparer<T>.Default;
        }
        //
        public MyPriorityQueue(T[] a)
        {
            for (int i = size / 2; i >= 0; i--)
            {
                SiftDown(i);
            }
        }
        public MyPriorityQueue(int capacity)
        {
            queue = new T[capacity];
            size = 0;
            comparator = Comparer<T>.Default;
        }
        public MyPriorityQueue(int capacity, IComparer<T> comparator)
        {
            if (capacity < 1) throw new ArgumentException("Начальная емкость должна быть положительной");
            queue = new T[capacity];
            size = 0;
            this.comparator = comparator;
        }
        public MyPriorityQueue(MyPriorityQueue<T> other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            queue = new T[other.queue.Length];
            Array.Copy(other.queue, queue, other.queue.Length);
            size = other.size;
            comparator = other.comparator;
        }
        //Добавление элемента
        public void Add(T el)
        {
            if (el == null) throw new ArgumentNullException(nameof(el));
            Resize(size + 1);
            queue[size] = el;
            SiftUp(size);
            size++;
        }
        //Вспомогательная функция для Add для увеличения size
        private void Resize(int capacity)
        {
            if (capacity > queue.Length)
            {
                int newcapacity = queue.Length < 64 ? queue.Length * 2 : queue.Length + (queue.Length / 2);
                Array.Resize(ref queue, Math.Max(newcapacity, capacity));
            }
        }
        //Добавление элементов из массива
        public void AddAll(T[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            for (int i = 0; i < a.Length; i++)
                Add(a[i]);
        }
        public bool Contains(object o)
        {
            if (o == null) return false;
            if (o is T el)
            {
                for (int i = 0; i < size; i++)
                {
                    if (EqualityComparer<T>.Default.Equals(queue[i], el)) return true;
                }
            }
            return false;
        }

        //Содержатся ли элементы массива в очереди?
        public void containsAll(T[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            foreach (T item in a)
            {

                if (!Contains(item))
                {
                    Console.WriteLine($"{item} не содержится в очереди");
                }

            }
        }
        //Проверка на пустоту
        public bool isEmpty()
        {
            return size == 0;
        }
        //Удалить из очереди все элементы
        public void Clear()
        {
            Array.Clear(queue, 0, size);
            size = 0;
        }
        public bool Remove(object o)
        {
            if (o == null) return false;
            if (o is T element)
            {
                for (int i = 0; i < size; i++)
                {
                    if (EqualityComparer<T>.Default.Equals(queue[i], element))
                    {
                        RemoveAt(i);
                        return true;
                    }
                }
            }
            return false;
        }
        public bool RemoveAll(T[] a)
        {
            if (a == null)
                throw new ArgumentNullException(nameof(a));

            bool modified = false;
            foreach (T element in a)
            {
                if (element == null) continue;
                bool removed;
                do
                {
                    removed = Remove(element);
                    if (removed) modified = true;
                } while (removed);
            }
            return modified;
        }
        public bool RetainAll(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            var retainSet = new HashSet<T>(array, EqualityComparer<T>.Default);
            bool modified = false;
            for (int i = size - 1; i >= 0; i--)
            {
                if (!retainSet.Contains(queue[i]))
                {
                    RemoveAt(i);
                    modified = true;
                }
            }
            if (modified)
                buildHeap();

            return modified;
        }
        //Удаляет элемент по индексу
        private void RemoveAt(int idx)
        {
            size--;
            if (size > 0)
            {
                queue[idx] = queue[size];
                SiftDown(idx);
                if (idx > 0 && comparator.Compare(queue[idx], queue[(idx - 1) / 2]) < 0)
                {
                    SiftUp(idx);
                }
            }
            queue[size] = default(T);
        }
        public T Peek()
        {
            if (size == 0) throw new ArgumentNullException(nameof(queue));
            return queue[0];
        }
        public T Poll()
        {
            if (size == 0) throw new ArgumentNullException(nameof(queue));
            T result = queue[0];
            RemoveAt(0);
            return result;
        }
        public int Size()
        {
            return size;
        }
        public T[] ToArray()
        {
            T[] res = new T[size];
            Array.Copy(queue, res, size);
            return res;
        }
        public T[] ToArray(T[] a)
        {
            if (a.Length < size) return ToArray();
            Array.Copy(queue, a, size);
            if (a.Length > size) a[size] = default(T);
            return a;
        }
        private void SiftDown(int i)
        {
            while (2 * i + 1 < size)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                int j = left;
                if (right < size && comparator.Compare(queue[right], queue[left]) < 0)
                    j = right;
                if (comparator.Compare(queue[i], queue[j]) <= 0) break;
                (queue[i], queue[j]) = (queue[j], queue[i]);
                i = j;
            }
        }
        private void SiftUp(int i)
        {
            while (i > 0 && comparator.Compare(queue[i], queue[(i - 1) / 2]) < 0)
            {
                (queue[i], queue[(i - 1) / 2]) = (queue[(i - 1) / 2], queue[i]);
                i = (i - 1) / 2;
            }
        }
        private void buildHeap()
        {
            for (int i = size / 2; i >= 0; i--)
            {
                SiftDown(i);
            }
        }

    }
}
