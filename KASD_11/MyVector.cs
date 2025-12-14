using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASD_11
{
    public class MyVector<T>
    {
        private T[] elementData;
        private int elementCount;
        private int capacityIncrement;
        private Dictionary<T, List<int>> indexMap; //Для быстрого поиска
        public MyVector()
        {
            elementCount = 0;
            elementData = new T[10];
        }
        public MyVector(T[] array)
        {
            elementData = new T[array.Length];
            if (array.Length == 0) throw new ArgumentNullException(nameof(array));
            elementCount = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                elementData[i] = array[i];
            }
        }
        public MyVector(int initialCapacity)
        {
            if (initialCapacity < 1) throw new ArgumentException("Начальная емкость должна быть положительной!");
            elementCount = 0;
            elementData = new T[initialCapacity];
            capacityIncrement = 0;
        }
        public MyVector(int initialCapacity, int capacityincrement)
        {
            if (initialCapacity < 1) throw new ArgumentException("Начальная емкость должна быть положительной!");
            elementCount = 0;
            elementData = new T[initialCapacity];
            capacityIncrement = capacityincrement;
        }
        public void Add(T el)
        {
            if (el == null) throw new ArgumentNullException(nameof(el));
            if (elementCount == elementData.Length)
            {
                Resize();
            }
            elementData[elementCount] = el;
            elementCount++;
        }
        public void AddAll(T[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            for (int i = 0; i < a.Length; i++)
            {
                Add(a[i]);
            }
        }
        public void Clear()
        {
            Array.Clear(elementData, 0, elementCount);
            elementCount = 0;
        }
        public bool Contains(object o)
        {
            if (o == null) return false;
            if (o is T el)
            {
                for (int i = 0; i < elementCount; i++)
                {
                    if (EqualityComparer<T>.Default.Equals(elementData[i], el)) return true;
                }
            }
            return false;
        }
        public bool ContainsAll(T[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            for (int i = 0; i < a.Length; i++)
            {
                if (!Contains(a[i])) return false;
            }
            return true;
        }
        public bool isEmpty()
        {
            return elementCount == 0;
        }
        public void Remove(object o)
        {
            if (o == null) throw new ArgumentNullException(nameof(o));
            if (Contains(o))
            {
                int i = 0;
                if (o is T el)
                {
                    for (i = 0; i < elementCount; i++)
                    {
                        if (Comparer<T>.Default.Compare(el, elementData[i]) == 0) break;
                    }

                }
                for (int j = i; j < elementCount; j++)
                {
                    elementData[j] = elementData[j + 1];
                }
                elementCount--;
            }
        }
        public void RemoveAll(T[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            for (int i = 0; i < a.Length; i++)
            {
                Remove(a[i]);
            }
        }
        public void RetainAll(T[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            T[] arr = new T[elementCount];
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (Contains(a[i]))
                {
                    for (i = 0; i < elementCount; i++)
                    {
                        if (Comparer<T>.Default.Compare(a[i], elementData[i]) == 0)
                        {
                            arr[index] = elementData[i];
                            index++;
                        }
                    }

                }
            }
            for (int i = 0; i < elementCount; i++)
            {
                elementData[i] = arr[i];
            }
            Array.Resize(ref elementData, index);
        }
        public int Size()
        { return elementCount; }
        public T[] toArray()
        {
            T[] a = new T[elementCount];
            for (int i = 0; i < elementCount; i++)
                a[i] = elementData[i];
            return a;
        }
        public T[] toArray(T[] a)
        {
            if (a == null || a.Length < elementCount)
            {
                T[] new_array = new T[elementCount];
                for (int i = 0; i < elementCount; i++)
                {
                    new_array[i] = elementData[i];
                }
                return new_array;
            }
            else
            {
                for (int i = 0; i < elementCount; i++)
                {
                    a[i] = elementData[i];
                }
                if (a.Length > elementCount)
                {
                    Array.Resize(ref a, elementCount);
                }
                return a;
            }
        }
        public void Add(int index, T e)
        {
            if (index < 0 || index > elementCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (elementCount == elementData.Length)
            {
                Resize();
            }
            for (int i = elementCount; i > index; i--)
            {
                elementData[i] = elementData[i - 1];
            }
            elementData[index] = e;
            elementCount++;
        }
        public void AddAll(int index, T[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (index >= elementCount) throw new IndexOutOfRangeException();
            T[] new_array = new T[elementCount + a.Length];
            Array.Copy(elementData, 0, new_array, 0, index);
            for (int i = 0; i < a.Length; i++)
            {
                new_array[i + index] = a[i];
            }
            Array.Copy(elementData, index, new_array, index + a.Length, elementCount - index);

        }
        public T Get(int index)
        {
            if (index < 0 || index >= elementCount) throw new IndexOutOfRangeException();
            T el = elementData[index];
            return el;
        }
        private void Zapoln()
        {
            indexMap = new Dictionary<T, List<int>>();
            for (int i = 0; i < elementCount; i++)
            {
                if (!indexMap.ContainsKey(elementData[i]))
                {
                    indexMap[elementData[i]] = new List<int>();
                }
                indexMap[elementData[i]].Add(i);
            }
        }
        public int IndexOf(object o)
        {
            if (o == null) throw new ArgumentNullException(nameof(o));
            Zapoln();
            if (o == null)
            {
                for (int i = 0; i < elementCount; i++)
                {
                    if (elementData[i] == null)
                        return i;
                }
                return -1;
            }
            if (o is T item)
            {
                if (indexMap.TryGetValue(item, out List<int> indexes) && indexes.Count > 0)
                {
                    return indexes[0]; // Первый индекс в списке
                }
            }
            return -1;
        }
        public int LastIndexOf(object o)
        {
            if (o == null) throw new ArgumentNullException("o");
            Zapoln();
            if (o == null)
            {
                for (int i = elementCount - 1; i >= 0; i--)
                {
                    if (elementData[i] == null)
                        return i;
                }
                return -1;
            }
            if (o is T item)
            {
                if (indexMap.TryGetValue(item, out List<int> indexes) && indexes.Count > 0)
                {
                    return indexes[indexes.Count]; // Последний индекс в списке
                }
            }
            return -1;
        }
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1) return false;

            RemoveAt(index);
            return true;
        }
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= elementCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            T removedItem = elementData[index];
            for (int i = index; i < elementCount - 1; i++)
            {
                elementData[i] = elementData[i + 1];
            }
            elementData[elementCount - 1] = default(T);
            elementCount--;

            return removedItem;
        }
        public void Set(int index, T e)
        {
            if (index < 0 || index >= elementCount) throw new ArgumentOutOfRangeException("index");
            elementData[index] = e;
        }
        public T[] Sublist(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || toIndex < fromIndex || toIndex > elementCount)
                throw new ArgumentOutOfRangeException();
            int length = toIndex - fromIndex;
            if (length <= 0)
                return new T[0];
            if (length < 0 || length > int.MaxValue - 100)
                throw new ArgumentException("Диапазон слишком велик");
            T[] result = new T[length];
            for (int i = 0; i < length && (fromIndex + i) < elementCount; i++)
            {
                result[i] = elementData[fromIndex + i];
            }
            return result;
        }
        public T firstElement()
        {
            return elementData[0];
        }
        public T lastEleent()
        {
            return elementData[elementCount - 1];
        }
        private void Resize()
        {
            int capasity;
            if (elementCount > 0)
            {
                capasity = elementCount + capacityIncrement;
            }
            else
            {
                capasity = 2 * elementCount;
            }
            T[] array = new T[capasity];
            for (int i = 0; i < elementCount; i++)
                array[i] = elementData[i];
            Array.Resize(ref elementData, capasity);
            for (int i = 0; i < elementCount; i++)
                elementData[i] = array[i];
        }
        public bool RemoveElement(T item)
        {
            int index = IndexOf(item);
            if (index == -1) return false;
            RemoveElementAt(index);
            return true;
        }
        public void RemoveElementAt(int index)
        {
            if (index < 0 || index >= elementCount)
                throw new ArgumentOutOfRangeException(nameof(index));
            T removedItem = elementData[index];
            for (int i = index; i < elementCount - 1; i++)
            {
                elementData[i] = elementData[i + 1];
            }
            elementData[elementCount - 1] = default(T);
            elementCount--;
        }
        public void RemoveRange(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                RemoveElementAt(i);
            }
        }
        public void Print()
        {
            for (int i = 0; i < elementCount; i++)
            {
                Console.WriteLine($"vector[{i}] = {elementData[i]} ");
            }
            Console.WriteLine();
        }
    }
}
