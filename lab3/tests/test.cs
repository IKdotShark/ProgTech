// In base list
using System;
using System.Collections;
using System.Collections.Generic;

    // Обобщенный класс BaseList<T>, параметризованный типом T, где T должен реализовывать интерфейс IComparable
    public class BaseList<T> : IEnumerable<T> where T : IComparable
    {
        protected int count; // Количество элементов в списке
        protected T[] buffer; // Внутренний массив для хранения элементов

        // Свойство для доступа к количеству элементов
        public int Count
        {
            get { return count; }
        }

        // Конструктор без параметров для инициализации пустого списка
        public BaseList()
        {
            buffer = new T[0];
            count = 0;
        }

        // Реализация методов Add, Insert, Delete, Clear и индексатора для доступа к элементам списка

        // Реализация интерфейса IEnumerable для поддержки перечисления элементов списка через foreach
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Другие методы, такие как Sort, IsEqual и т. д.
    }






using System;
using System.IO;

    // Класс для обработки файловых операций
    public static class FileHandler
    {
        // Метод для сохранения списка в файл
        public static void SaveToFile<T>(string fileName, BaseList<T> list)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (T item in list)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new BadFileException("Ошибка при сохранении в файл.", ex);
            }
        }

        // Метод для загрузки списка из файла
        public static BaseList<T> LoadFromFile<T>(string fileName) where T : IComparable
        {
            try
            {
                BaseList<T> list = new BaseList<T>();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        T item = (T)Convert.ChangeType(line, typeof(T));
                        list.Add(item);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new BadFileException("Ошибка при загрузке из файла.", ex);
            }
        }
    }

    // Исключение, возникающее при ошибке файловых операций
    public class BadFileException : Exception
    {
        public BadFileException(string message) : base(message) { }
        public BadFileException(string message, Exception innerException) : base(message, innerException) { }
    }



    // Класс исключения для некорректного индекса
    public class BadIndexException : Exception
    {
        public BadIndexException(string message) : base(message) { }
    }



    public delegate void ListChangeHandler(object sender, EventArgs e);

    // Аргументы события изменения списка
    public class ListChangedEventArgs : EventArgs
    {
        public ListChangedEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    // Добавление обработки событий к классу BaseList<T>
    public class BaseList<T>
    {
        public event ListChangeHandler ListChanged; // Событие изменения списка

        // Метод для вызова события изменения списка
        protected virtual void OnListChanged(string message)
        {
            ListChanged?.Invoke(this, new ListChangedEventArgs(message));
        }
    }



    public class BaseList<T>
    {
        // Перегрузка оператора == для сравнения списков
        public static bool operator ==(BaseList<T> list1, BaseList<T> list2)
        {
            if (ReferenceEquals(list1, list2))
                return true;
            if (list1 is null || list2 is null)
                return false;

            return list1.SequenceEqual(list2);
        }

        // Перегрузка оператора != для сравнения списков
        public static bool operator !=(BaseList<T> list1, BaseList<T> list2)
        {
            return !(list1 == list2);
        }

        // Перегрузка оператора + для объединения списков
        public static BaseList<T> operator +(BaseList<T> list1, BaseList<T> list2)
        {
            BaseList<T> mergedList = new BaseList<T>();
            foreach (T item in list1)
                mergedList.Add(item);
            foreach (T item in list2)
                mergedList.Add(item);
            return mergedList;
        }
    }