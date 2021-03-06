using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap heap = new Heap();
            heap.Add(1);
            heap.Add(15);
            heap.Add(10);
            heap.Add(9);
            heap.Add(25);
            heap.Add(6);
            heap.Add(48);
            heap.Add(36);
            for (int i = 0; i < heap.Count; i++)
            {
                Console.WriteLine(heap.Get(i));
            }

            Console.WriteLine();

            Console.WriteLine("Максимальный элемент - " + heap.ExtractMaximum());
            Console.WriteLine("Максимальный элемент - " + heap.ExtractMaximum());
            Console.WriteLine("Максимальный элемент - " + heap.ExtractMaximum());
        }
    }


    public class Heap
    {
        public int Count => _heapData.Count;
        private List<int> _heapData = new List<int>();

        public void Add(int value)
        {
            _heapData.Add(value);
            ShiftUp(_heapData.Count - 1); //индекс последнего элемента
        }

        public int Get(int index)
        {
            return _heapData[index];
        }

        private void ShiftUp(int index)
        {
            //смотрим на родительский элемент(i-1)/2 и обмениваем
            //если обменять не получилось - выходим
            int parentIndex = (index - 1) / 2;
            var currentElement = _heapData[index];
            var parentElement = _heapData[parentIndex];
            if (currentElement > parentElement)
            {
                Swap(_heapData, index, parentIndex);
                ShiftUp(parentIndex);
            }
        }

        private void ShiftDoun(int index)
        {
            //Сравниваем левый и правый
            //Свапаем максимальный с нашим текущим
            //(если мксимальный больше текущего)
            //Повторяем до тех пор, пока инекс не выйдет за границы
            var leftChildInex = index * 2 + 1;
            var rightChildInex = index * 2 + 2;
            if (leftChildInex >= _heapData.Count)
            {
                //заканчиваем просеивание
                return;
            }

            var maxChildIndex = leftChildInex;
            //правый потомок есть и он больше чем левый
            if (rightChildInex < _heapData.Count
                && _heapData[leftChildInex] < _heapData[rightChildInex])
            {
                //тогда пометим правый - как индекс максимального потомка
                maxChildIndex = rightChildInex;
            }

            //если наш элемент оказался УЖЕ больше чем максимальный потомок 
            // то на этом просеивание зжаканчиваем
            if (_heapData[leftChildInex] > _heapData[rightChildInex])
            {
                return;
            }

            Swap(_heapData, index, maxChildIndex);
            ShiftDoun(maxChildIndex);
        }


        private void Swap(List<int> array, int leftIndex, int rightIndex)
        {
            (array[leftIndex], array[rightIndex]) = (array[rightIndex], array[leftIndex]);
        }

        public int ExtractMaximum()
        {
            var result = _heapData[0];
            _heapData[0] = _heapData[^1];
            ShiftDoun(0);
            return result;
        }
    }
}
