using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASD_5
{
    public class Heap<T>
    {
        private T[] arr;
        public T[] Arr { get => arr; }
        public Heap()
        {
            arr= Array.Empty<T>();
        }
       public Heap(T[] array)
       {
         arr= array;   
       }
        public void SiftDown(int i)
        {
            while (2 * i + 1 < arr.Length)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                int j = left;
                if (right < arr.Length && Comparer<T>.Default.Compare(arr[right], arr[left])<0)
                    j = right;
                if (Comparer<T>.Default.Compare(arr[i], arr[j])<=0) break;
                (arr[i], arr[j]) = (arr[j], arr[i]);
                i = j;
            }
        }
        public void SiftUp(int i)
        {
            while (i>0 && Comparer<T>.Default.Compare(arr[i], arr[(i-1)/2]) < 0)
            {
                (arr[i], arr[(i - 1) / 2]) = (arr[(i - 1) / 2], arr[i]);
                i = (i - 1) / 2;
            }
        }
        public void buildHeap()
        {
            for(int i=arr.Length/2;i>=0;i--)
            {
                SiftDown(i); 
            }
        }
        public void GetMin()
        {
            if (arr.Length == 0) throw new ArgumentException("Куча пуста"); 
            Console.WriteLine($"Минимальный элемент без удаления из кучи: {arr[0]}");
        }
        public T ExtractMin()
        {
            if (arr.Length == 0) throw new ArgumentException("Куча пуста");
            T min = arr[0];
            arr[0] = arr[arr.Length - 1];
            Array.Resize(ref arr, arr.Length-1);
            SiftDown(0);
            return min;
        }
        public void Insert(T value)
        {
            if (arr.Length == 0) throw new ArgumentException("Куча пуста");
            Array.Resize(ref arr,arr.Length + 1);
            arr[arr.Length - 1] = value;
            SiftUp(arr.Length - 1);

        }
        public void Merge(Heap<T> b, int m)
        {
            for(int i=0;i<m;i++)
            {
                Insert(b.Arr[i]);
            }
            
        }
        public void DecreaseKey(int index, T value)
        {
            if (index < 0 || index >= arr.Length)
                throw new ArgumentOutOfRangeException("Индекс вне границ");
            if (Comparer<T>.Default.Compare(value, arr[index]) > 0)
                throw new ArgumentException("Новое значение должно быть меньше текущего");
            arr[index] = value;
            SiftUp(index);
        }
        public void IncreaseKey(int index, T newValue)
        {
            if (index < 0 || index >= arr.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне границ кучи");
            if (Comparer<T>.Default.Compare(newValue, arr[index]) < 0)
                throw new ArgumentException("Новое значение должно быть больше текущего");
            arr[index] = newValue;
            SiftDown(index);
        }
        public void UpdateKey(int index, T newValue)
        {
            if (index < 0 || index >= arr.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс вне границ кучи");
            int comparison = Comparer<T>.Default.Compare(newValue, arr[index]);
            arr[index] = newValue;
            if (comparison < 0)
            {
                SiftUp(index);
            }
            else if (comparison > 0)
            {
                SiftDown(index);
            }
        }
        public void PrintHeap()
        {
            for(int i=0;i<arr.Length;i++)
            {
                Console.Write($"[{i}]={arr[i]} ");
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                if (left < arr.Length)
                    Console.Write($"L[{left}]:{arr[left]} ");
                if (right < arr.Length)
                    Console.Write($"L[{right}]:{arr[right]} ");
                Console.WriteLine();
            }
        }
    }
}
