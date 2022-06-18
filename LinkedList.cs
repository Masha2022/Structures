using System;
using System.Security.Cryptography;

namespace ListNode
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();
            // Добавляем элементы в конец.
            list.AddLast(new Person("Вася", 18));
            list.AddLast(new Person("Петя", 20));

            // Выводим все элементы на консоль.
            list.PrintAll();
            //Name: Вася Age: 18
            //Name: Петя Age: 20

            //Добавляем элементы в начало.
            list.AddFirst(new Person("Антон", 25));
            list.AddFirst(new Person("Рома", 10));
            // Выводим все элементы на консоль.
            list.PrintAll();
            // Name: Рома Age: 10
            // Name: Антон Age: 25
            // Name: Вася Age: 18
            // Name: Петя Age: 20


            // Удаляем элемент.
            list.Remove(new Person("Вася", 18));
            list.PrintAll();
            // Name: Рома Age: 10
            // Name: Антон Age: 25
            // Name: Петя Age: 20
        }
    }

    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    /// <summary>
    /// Класс, описывающий элемент связного списка.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Хранимые данные.
        /// </summary>
        public Person Value;

        /// <summary>
        /// Следующий элемент связного списка.
        /// </summary>
        public Node Next;

        /// <summary>
        /// Создание нового экземпляра связного списка.
        /// </summary>
        /// <param name="value"> Сохраняемые данные. </param>
        public Node(Person value)
        {
            Value = value;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Хранимые данные. </returns>
        public void Print()
        {
            Console.WriteLine("Name: " + Value.Name + " Age: " + Value.Age);
        }
    }

    public class LinkedList
    {
        /// <summary>
        /// Первый (головной) элемент списка.
        /// </summary>
        public Node Head = null;

        /// <summary>
        /// Крайний (хвостовой) элемент списка. 
        /// </summary>
        public Node Tail = null;

        /// <summary>
        /// Добавить данные в  связный список.
        /// </summary>
        /// <param name="data"></param>
        public void AddLast(Person data)
        {
            if (Tail != null && Tail.Next == null) //если следующая за последней нодой, нода равна null 
            {
                Tail.Next = new Node(data); //тогда меняем указатель на новую ноду
                Tail = Tail.Next;
                Tail.Next = null; //перекидываем указатель опять на null
            }

            if (Head == null && Tail == null) //если список пуст
            {
                Tail = new Node(data); //тогда первая и последняя нода равны новой ноде
                Head = Tail;
                Tail.Next = null; //указываем последней ноде ссылаться на  null
            }
        }


        /// <summary>
        /// Добавляет ноду в самое начало
        /// </summary>
        /// <param name="data"></param>
        public void AddFirst(Person data)
        {
            var node = Head;
            if (Head == null) //если список пуст
            {
                Head = new Node(data);
            }
            else
            {
                Head = new Node(data); //закидываем в первую ноду новую ноду
                Head.Next = node; //меняем указатели
                Head.Next.Next = node.Next;
            }
        }


        /// <summary>
        /// Удалить данные из связного списка.
        /// Выполняется удаление первого совпадения данных.
        /// </summary>
        /// <param name="data"> Данные, которые будут удалены. </param>
        public void Remove(Person data)
        {
            var current = Head;

            Node previous = null;

            while (current != null) //если список не пустой ищем нужную ноду
            {
                if (current.Value.Name == data.Name && current.Value.Age == data.Age)
                {
                    // Если элемент находится в середине или в конце списка,
                    // выкидываем текущий элемент из списка.
                    // Иначе это первый элемент списка,
                    // выкидываем первый элемент из списка.
                    if (previous != null)
                    {
                        // Устанавливаем у предыдущего элемента указатель на следующий элемент от текущего.
                        previous.Next = current.Next;

                        if (current.Next == null) // Если это был последний элемент списка, 
                            // то изменяем указатель на последний элемент списка.
                        {
                            Tail = previous;
                        }
                    }
                    else
                    {
                        // Устанавливаем головной элемент следующим.
                        Head = Head.Next;

                        if (Head == null) //убедились, что была всего одна нода, скинули все указатели в null
                        {
                            Tail = null;
                        }
                    }

                    break;
                }

                // Переходим к следующему элементу списка.
                previous = current;
                current = current.Next;
            }
        }

        /// <summary>
        /// Вывод всех объектов в консоль
        /// </summary>
        /// <returns></returns>
        public void PrintAll()
        {
            var node = Head;
            while (node != null)
            {
                Console.WriteLine("Name: " + node.Value.Name + " " + " Age: " + node.Value.Age);
                node = node.Next;
            }
        }
    }
}
