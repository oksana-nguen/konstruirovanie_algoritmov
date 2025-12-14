using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASD_8
{
    public class MyArrayList<T>
    {
        private T[] elementData;
        private int size;
        private Dictionary<T, List<int>> indexMap; //Для быстрого поиска
        public MyArrayList()
        {
            size = 0;
            elementData = new T[0];
        }
        public MyArrayList(T[] array)
        {
            elementData= new T[array.Length];
            if(array.Length==0) throw new ArgumentNullException(nameof(array));
            size=array.Length;
            for(int i=0;i<array.Length;i++)
            {
                elementData[i]=array[i];
            }
        }
        public MyArrayList(int capacity)
        {
            if (capacity < 1) throw new ArgumentException("Начальная емкость должна быть положительной!");
            size =0;
            elementData = new T[capacity];
        }
        public void Add(T el)
        {
            if(el==null) throw new ArgumentNullException(nameof(el));
            if(size==elementData.Length)
            {
                Resize();
            }
            elementData[size] = el;
            size++;
        }
        public void AddAll(T[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            for(int i=0;i<a.Length;i++)
            {
                Add(a[i]);
            }
        }
        public void Clear()
        {
            Array.Clear(elementData, 0, size);
            size = 0;
        }
        public bool Contains(object o)
        {
            if (o == null) return false;
            if (o is T el)
            {
                for (int i = 0; i < size; i++)
                {
                    if (EqualityComparer<T>.Default.Equals(elementData[i], el)) return true;
                }
            }
            return false;
        }
        public bool ContainsAll(T[] a)
        {
            if(a == null) throw new ArgumentNullException(nameof (a));
            for(int i=0;i<a.Length;i++)
            {
                if (!Contains(a[i])) return false;
            }
            return true;
        }
        public bool isEmpty()
        {
            return size == 0;
        }
        public void Remove(object o)
        {
            if (o == null) throw new ArgumentNullException(nameof (o));
            if (Contains(o))
            {
                int i = 0;
                if (o is T el)
                {
                    for (i = 0; i < size; i++)
                    {
                        if (Comparer<T>.Default.Compare(el, elementData[i]) == 0) break;
                    }
                    
                }
                for(int j=i;j<size;j++)
                {
                    elementData[j] = elementData[j + 1];
                }
                size--;
            }
        }
        public void RemoveAll(T[] a)
        {
            if(a==null) throw new ArgumentNullException(nameof (a));
            for(int i=0;i<a.Length;i++)
            {
                Remove(a[i]);
            }
        }
        public void RetainAll(T[] a)
        {
            if (a==null) throw new ArgumentNullException(nameof (a));
            T[] arr= new T[size];
            int index = 0;
            for(int i=0;i<a.Length;i++)
            {
                if (Contains(a[i]))
                {
                    for (i = 0; i < size; i++)
                    {
                        if (Comparer<T>.Default.Compare(a[i], elementData[i]) == 0)
                        {
                            arr[index] = elementData[i];
                            index++;
                        }
                    }

                }
            }
            for(int i=0;i<size;i++)
            {
                elementData[i] = arr[i];
            }
            Array.Resize(ref elementData, index);
        }
        public int Size()
        { return size; }
        public T[] toArray()
        {
            T[] a= new T[size];
            for(int i=0;i<size;i++)
                a[i]= elementData[i];
            return a;
        }
        public T[] toArray(T[] a)
        {
            if(a==null ||a.Length<size)
            {
                T[] new_array= new T[size];
                for(int i=0;i<size;i++)
                {
                    new_array[i]= elementData[i];
                }
                return new_array;
            }
            else 
            {
                for(int i=0;i<size;i++)
                {
                    a[i]= elementData[i];
                }
                if(a.Length>size)
                {
                    Array.Resize(ref a,size);
                }
                return a;
            }
        }
        public void Add(int index, T e)
        {
            if (index < 0 || index > size)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (size == elementData.Length)
            {
                Resize();
            }
            for (int i = size; i > index; i--)
            {
                elementData[i] = elementData[i - 1];
            }
            elementData[index] = e;
            size++;
        }
        public void AddAll(int index, T[] a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (index >= size) throw new IndexOutOfRangeException();
            T[] new_array= new T[size+a.Length];
            Array.Copy(elementData, 0, new_array,0, index);
            for(int i=0;i<a.Length;i++)
            {
                new_array[i+index]= a[i];
            }
            Array.Copy(elementData, index, new_array, index + a.Length, size - index);

        }
        public T Get(int index)
        {
            if(index<0||index>=size) throw new IndexOutOfRangeException();
            T el= elementData[index];
            return el;
        }
        private void Zapoln()
        {
            indexMap = new Dictionary<T, List<int>>();
            for(int i=0;i<size;i++)
            {
                if(!indexMap.ContainsKey(elementData[i]))
                {
                    indexMap[elementData[i]]=new List<int>();
                   
                }
                indexMap[elementData[i]].Add(i);
            }
        }
        public int IndexOf(object o)
        {
            if(o==null) throw new ArgumentNullException(nameof(o));
            Zapoln();
            if (o == null)
            {
                for (int i = 0; i < size; i++)
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
                for (int i = size-1; i>=0; i--)
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
            if (index < 0 || index >= size)
                throw new ArgumentOutOfRangeException(nameof(index));
            T removedItem = elementData[index];
            for (int i = index; i < size - 1; i++)
            {
                elementData[i] = elementData[i + 1];
            }
            elementData[size - 1] = default(T);
            size--;

            return removedItem;
        }
        public void Set(int index, T e)
        {
            if(index < 0 || index >= size) throw new ArgumentOutOfRangeException("index");
            elementData[index] = e;
        }
        public T[] Sublist(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || toIndex < fromIndex || toIndex > size)
                throw new ArgumentOutOfRangeException();
            int length = toIndex - fromIndex;
            if (length <= 0)
                return new T[0];
            if (length < 0 || length > int.MaxValue - 100) 
                throw new ArgumentException("Диапазон слишком велик");
            T[] result = new T[length];
            for (int i = 0; i < length && (fromIndex + i) < size; i++)
            {
                result[i] = elementData[fromIndex + i];
            }
            return result;
        }
        private void Resize()
        {
            int capasity = Convert.ToInt32(size * 1.5) + 1;
            T[] array = new T[capasity];
            for (int i = 0; i < size; i++)
                array[i] = elementData[i];
            Array.Resize(ref elementData, capasity);
            for (int i = 0; i < size; i++)
                elementData[i] = array[i];
        }
        public void Print()
        {
            for(int i=0;i<size;i++)
            {
                Console.Write($"{elementData[i]} ");
            }
            Console.WriteLine();
        }
    }
}
