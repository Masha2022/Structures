using System;
using System.Collections.Generic;

namespace DeadPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var circularArray = new CircularArray<int>(3); //Стуктура которая запомнит последние 3 значения
            circularArray.Add(10);
            circularArray.Add(12);
            circularArray.Add(14);
            circularArray.Add(10);
            circularArray.Add(11);
            circularArray.Add(12);

            for (var i = 0; i < circularArray.Count; i++)
            {
                Console.WriteLine(circularArray.Get(i));
            }
        }
    }
}

public class CircularArray<T> //циклический массив
{
    //public int Count
    //{
    //    get
    //    {
    //        if (_nextIndex > _elements.Length)
    //        {
    //            return  _elements.Length;
    //        }

    //        return _nextIndex;
    //    }
    //}
    public int Count => _nextIndex > _elements.Length ? _elements.Length : _nextIndex;
    private T[] _elements;
    private int _nextIndex;

    public CircularArray(int count)
    {
        _elements = new T[count];
    }

    public void Add(T value)
    {
        // в currentIndex храним индекс, в который будем добавлять элемент
        // в данном случае от 0 до 3х
        var currentIndex = _nextIndex % _elements.Length;
        //добавляем элемент
        _elements[currentIndex] = value;
        //увеличиваем индекс на 1
        ++_nextIndex;
    }

    public T Get(int index)
    {
        if (_nextIndex < _elements.Length) // если индекс < длины массива - возвращаем элемент с этим индексом
        {
            return _elements[index];
        }

        // иначе возвращаем элемент с индексом по модулю
        return _elements[(_nextIndex + index) % _elements.Length];
    }
}
