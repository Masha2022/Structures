using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue();
            queue.Enqueue(new Person("Маша", 18));
            queue.Enqueue(new Person("Нина", 10));
            queue.Enqueue(new Person("Алиса", 99));
            queue.Enqueue(new Person("Даша", 11));
            queue.Print();

            Console.WriteLine();
            var firstItem = queue.Dequeue();
            Console.Write($"Извлеченный элемент: ");
            firstItem.Print(); // Извлеченный элемент: Name: Маша Age: 18
            
            var secondItem = queue.Dequeue();
            Console.Write($"Извлеченный элемент: ");
            secondItem.Print(); // Извлеченный элемент: Name: Нина Age: 10
            Console.WriteLine();
            
            Console.WriteLine("Очередь после извлечения первых двух эелементов");
            queue.Print();
            
            queue = new Queue();
            var Item = queue.Peak(); //null
            queue.Print();
            
        }
    }

    /// <summary>
    /// Класс Person
    /// Содержит 2 публичных поля Name и Age
    /// Также должен быть конструктор который принимает Name, Age
    /// </summary>
    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine("Name: " + Name + " Age: " + Age);
        }
    }

    public class Node
    {
        public Person Value;
        public Node Next;

        public Node(Person value)
        {
            Value = value;
        }
    }

    public class Queue
    {
        public Node Head;
        public Node Tail;

        // добавление в очередь
        public void Enqueue(Person data)
        {
            //возможны два варианта
            Node node = new Node(data);
            if (Head != null)//если очередь не пустая-меняем указатель хвоста
            {
                Tail.Next = node;
                Tail = node;
            }
            else
            {
                Tail = node;//если очередь была пустой, тогда голова и хвост указывают на один элемент
                Head = Tail;
            }
        }

        // удаление из очереди
        public Person Dequeue()
        {
            var node = Head;
            if (Head != null)
            {
                Head = Head.Next; // если очередь не пустая-меняем уаазатель головы на следующий
                return node.Value;//возвращаем значение, иначе 0/null
            }

            return null;
        }

        // возвращает первый элемент
        public Person Peak()
        {
            if (Head != null)//если очередь не пустая - возвращаем значение
            {
                return Head.Value;
            }

            return null;
        }
        public void Print()
        {
            var node = Head;
            while (node != null)
            {
                Console.WriteLine("Name: " + node.Value.Name + " Age: " + node.Value.Age);
                node = node.Next;
            }
            
        }
    }
}
