using System;

namespace lab2
{
     class Program
    {
        static void Main(string[] args)
        {
            // Проверка Arr_list
            Console.WriteLine("Testing Arr_list:");
            Arr_list arrList = new Arr_list();

            // Добавление элементов
            arrList.Add(5);
            arrList.Add(10);
            arrList.Add(15);

            // Печать списка
            Console.WriteLine("Print List:");
            arrList.Print(); // Ожидаемый вывод: 5 10 15

            // Вставка элемента
            arrList.Insert(1, 7);
            Console.WriteLine("After Insertion:");
            arrList.Print(); // Ожидаемый вывод: 5 7 10 15

            // Удаление элемента
            arrList.Delete(2);
            Console.WriteLine("After Deletion:");
            arrList.Print(); // Ожидаемый вывод: 5 7 15

            // Получение элемента по индексу
            Console.WriteLine("Element at index 1: " + arrList[1]); // Ожидаемый вывод: 7

            // Присвоение списку нового значения
            Arr_list newarrList = new Arr_list();
            newarrList.Add(20);
            newarrList.Add(25);
            newarrList.Add(30);
            Console.WriteLine("Print New List:");
            newarrList.Print(); // Ожидаемый вывод: 20 25 30
            arrList.Assign(newarrList);
            Console.WriteLine("After Assignment:");
            arrList.Print(); // Ожидаемый вывод: 20 25 30


            // TROBLES WTIH CLONE arr_list

            // Клонирование списка
         /*   Arr_list clonedList = (Arr_list)arrList.Clone();
            Console.WriteLine("Cloned List:");
            clonedList.Print(); // Ожидаемый вывод: 20 25 30
        */

            // Проверка на равенство списков
            Console.WriteLine("Are Lists Equal? " + arrList.IsEqual(newarrList)); // Ожидаемый вывод: True

            // Очистка списка
            arrList.Clear();
            Console.WriteLine("After Clearing:");
            arrList.Print(); // Ожидаемый вывод: пустая строка

            Console.WriteLine();

            // Проверка Arr_chain_list
            Console.WriteLine("Testing Arr_chain_list:");
            Arr_chain_list arrChainList = new Arr_chain_list();

            // Добавление элементов
            arrChainList.Add(3);
            arrChainList.Add(6);
            arrChainList.Add(9);

            // Печать списка
            Console.WriteLine("Print List:");
            arrChainList.Print(); // Ожидаемый вывод: 3 6 9

            // Вставка элемента
            arrChainList.Insert(1, 7);
            Console.WriteLine("After Insertion:");
            arrChainList.Print(); // Ожидаемый вывод: 3 7 6 9

            // Удаление элемента
            arrChainList.Delete(2);
            Console.WriteLine("After Deletion:");
            arrChainList.Print(); // Ожидаемый вывод: 3 7 9

            // Получение элемента по индексу
            Console.WriteLine("Element at index 1: " + arrChainList[1]); // Ожидаемый вывод: 7

            // Присвоение списку нового значения
            Arr_chain_list newarrChainList = new Arr_chain_list();
            newarrChainList.Add(20);
            newarrChainList.Add(25);
            newarrChainList.Add(30);
            Console.WriteLine("Print New List:");
            newarrChainList.Print(); // Ожидаемый вывод: 20 25 30
            arrChainList.Assign(newarrChainList);
            Console.WriteLine("After Assignment:");
            arrChainList.Print(); // Ожидаемый вывод: 20 25 30

            // Клонирование списка
            Arr_chain_list clonedChainList = (Arr_chain_list)arrChainList.Clone();
            Console.WriteLine("Cloned List:");
            clonedChainList.Print(); // Ожидаемый вывод: 20 25 30

            // Проверка на равенство списков
            Console.WriteLine("Are Lists Equal? " + arrChainList.IsEqual(newarrChainList)); // Ожидаемый вывод: True

            // Очистка списка
            arrChainList.Clear();
            Console.WriteLine("After Clearing:");
            arrChainList.Print(); // Ожидаемый вывод: пустая строка
        }
    }
}