using System;
using System.Collections.Generic;

namespace DeadPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            DinamicArray<int> list = new DinamicArray<int>();
            list.Add(51);
            list.Add(52);
            list.Add(15);
            list.Add(56);
            list.Add(59);
            list.Add(50);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list.Get(i));
            }
        }
    }
}

public class DinamicArray<T>
{
    private const int DEFAULT_COUNTS_ELEMENTS = 4;

    public int Count => _nextIndex;
    private T[] _elements;
    private int _nextIndex;

    public DinamicArray()
    {
        _elements = new T[DEFAULT_COUNTS_ELEMENTS];
    }

    public void Add(T value)
    {
        if (_nextIndex == _elements.Length)
        {
            //увеличиваем размер массива
            Array.Resize(ref _elements, _elements.Length * 2);
        }

        _elements[_nextIndex] = value;
        _nextIndex++;
    }

    public T Get(int index)
    {
        return _elements[index];
    }
}
