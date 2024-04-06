using System;
using System.Collections;
using System.Collections.Generic;

namespace lab3{
    public abstract class Base_list<T> : IEnumerable<T> where T: IComparable<T>
    {    
        protected int count;

        public int Count 
        {
            get { return count; }
        }
        

        public abstract void Add(T item);

        public abstract void Insert(int pos, T item);

        public abstract void Delete(int pos);

        public abstract void Clear();

        public abstract T this[int i] { get; set; }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            //foreach (var item in this)
            {
                //Console.Write(item + " ");
                Console.Write(this[i] + " ");
            }
            Console.WriteLine();
        }

        public void Assign(Base_list<T> source)
        {
            Clear();
            for (int i = 0; i < source.count; i++)
            {
                Add(source[i]);
            }
        }

        public void AssignTo(Base_list<T> dest)
        {
            dest.Assign(this);
        }
       
        public Base_list<T> Clone()
        {
            Base_list<T> clone_list = EmptyClone();
            clone_list.Assign(this);
            return clone_list;
        }
        protected abstract Base_list<T> EmptyClone();

        public virtual void Sort()
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (this[i] > this[j])
                    {
                        int temp = this[i];
                        this[i] = this[j];
                        this[j] = temp;
                    }
                }
            }
        }
        public bool IsEqual(Base_list<T> AnotherOne)
        {
            if (AnotherOne == null)
                return false;

            if (this.Count != AnotherOne.Count)
                return false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] != AnotherOne[i])
                    return false;
            }
            return true;
        }

        public SaveToFile(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (T item in this)
                    {
                        writer.WriteLine(item);
                    }
                    /*
                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteLine(this[i].ToString());
                    }
                    */
                }
            }
            catch (IOException)
            {
                ExceptionCounter.ChainExceptionCounterIncrement();
                return;    
            }
        }

        public LoadFromFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        T item = (T)Convert.ChangeType(line, typeof(T));
                        Add(item);
                    }
                }
            }
            catch (IOException)
            {
                ExceptionCounter.ChainExceptionCounterIncrement();
                return;
            }
        }

        public static bool operator ==(Base_list<T> list1, Base_list<T> list2)
        {
            return list1.IsEqual(list2);
        }

        public static bool operator !=(Base_list<T> list1, Base_list<T> list2)
        {
            return !list1.IsEqual(list2);
        }
        public static bool operator +(Base_list<T> list1, Base_list<T> list2)
        {
            Base_list<T> list3 = new Base_list<T>();
            list3.Assign(list1);
            list3.Assign(list2);
            return list3;
            /*
            Base_list<T> list3 = list1.Clone();
            for (int i = 0; i < list2.Count; i++)
            {
                list3.Add(list2[i]);
            }
            return list3;
            */

        }
        public class BadIndexException : Exception
        {
            public BadIndexException(string message) : base(message) { }
            //public BadIndexException() : base("exception") { }
        }
        public class BadFileException : Exception
        {
            public BadFileException(string message) : base(message) { }
            //public BadFileException() : base("exception") { }
        }
        public class ExceptionCounter
        {
            protected static int ChainExceptionCount = 0;
            protected static int ArrayExceptionCount = 0;
            
            public static void ChainExceptionCounter()
            {
                get { return ChainExceptionCount; }
            }
            public static void ArrayExceptionCounter()
            {
                get { return ArrayExceptionCount; }
            }
            public static void ArrayExceptionCounterIncrement()
            {
                ArrayExceptionCount++;
            }
            public static void ChainExceptionCounterIncrement()
            {
                ChainExceptionCount++;
            }
            public static void ExceptionCounterReset()
            {
                ChainExceptionCount = 0;
                ArrayExceptionCount = 0;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BaseListEnumerator<T>(this);   
        }
        // write IEnumerator<T> GetEnumerator() without yeild
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public class ActionEventArgs : EventArgs
        {
            public string Action { get; set; } //
            
            public ActionEventArgs(string action)
            {
                Action = action;
            }   
        }

        private class BaseListEnumerator<T> : IEnumerator<T>
        {
            private Base_list<T> _list;
            private int _index;
            private T _current;

            public BaseListEnumerator(Base_list<T> list)
            {
                _list = list;
                _index = -1;
                _current = default(T);
            }

            public T Current
            {
                get
                {
                    if (_index == -1 || _index == _list.Count)
                    {
                        throw new InvalidOperationException();
                    }
                    return _current;
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                _list = null;
                _current = default(T);
            }

            public bool MoveNext()
            {
                if (_index < _list.Count - 1)
                {
                    _index++;
                    _current = _list[_index];
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _index = -1;
                _current = default(T);
            }
        }

        /*
        private class BaseListEnumerator : IEnumerator<T>
        {
            private Base_List<T> list;
            private int currentIndex = -1;

            public BaseListEnumerator(Base_List<T> list)
            {
                this.list = list;
            }

            public T Current => list[currentIndex];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < list.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose()
            {
                // Метод Dispose не требуется в этом примере, но интерфейс IDisposable реализуется для соответствия
            }
        }

        */
    }
}