using System.Collections;

namespace lab3{
    public abstract class Base_list<T> : IEnumerable<T> where T: IComparable<T>
    {  
        public delegate void ListChangedEventHandler(object sender, ActionEventArgs e);
        protected int count;
        public event ListChangedEventHandler ItemChanged;

        public int Count 
        {
            get { return count; }
        }
        protected virtual void OnItemChanged()
        {
            ItemChanged?.Invoke(this, new ActionEventArgs("Item Changed"));
        }        
        public abstract void Add(T item);

        public abstract void Insert(int pos, T item);

        public abstract void Delete(int pos);

        public abstract void Clear();

        public abstract T this[int i] { get; set; }

        public void Print()
        {
            foreach (var item in this)
            {
                Console.Write(item + " ");
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
                    if (this[i].CompareTo(this[j]) > 0)
                    {
                        T temp = this[i];
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
                if (this[i].CompareTo(AnotherOne[i]) != 0)
                    return false;
            }
            return true;
        }

        public void SaveToFile(string fileName)
        {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteLine(this[i].ToString());
                    }
                }
        }

        public void LoadFromFile(string fileName)
        {
                Clear();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Trim() == "")
                        {
                            T item = (T)Convert.ChangeType(line, typeof(T));
                            Add(item);
                        }
                    }
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
        
        public static Base_list<T> operator +(Base_list<T> list1, Base_list<T> list2)
        {
            Base_list<T> list3 = list1.Clone();
            for (int i = 0; i < list2.Count; i++)
            {
                list3.Add(list2[i]);
            }
            return list3;
        }

        /*
        public class ExceptionCounter
        {
            protected static int ChainExceptionCount = 0;
            protected static int ArrayExceptionCount = 0;
           
            public static int ChainExceptionCounter
            {
                get { return ChainExceptionCount; }
            }
            public static int ArrayExceptionCounter
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
        }*/

        public void AddArrayListEventHandler()
        {
            ItemChanged += (sender, e) => Console.WriteLine("Array list changed");
        }
        public void AddChainListEventHandler()
        {
            ItemChanged += (sender, e) => Console.WriteLine("Chain list changed");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Base_listEnumerator(this);
        }
        
         IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

         private class Base_listEnumerator : IEnumerator<T>
        {
            private Base_list<T> list;
            private int currentIndex = -1;

            public Base_listEnumerator(Base_list<T> list)
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
            }
        }
        }

public class BadIndexException : Exception
        {
            public BadIndexException() : base("exception")
            {
            }
        }       

        public class BadFileException : Exception
        {
            public BadFileException() : base("exception")
            {
            }
        }

        public class ActionEventArgs : EventArgs
        {
            public string Action { get; private set; }

            public ActionEventArgs(string action)
            {   
                Action = action;
            }
        }        


    }
        

