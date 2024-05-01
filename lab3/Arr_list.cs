using System;
using System.Reflection;

namespace lab3
{
   public class Arr_list<T> : Base_list<T> where T : IComparable<T>
    {       
        private T[] buffer;

        public Arr_list()
        {
            buffer = new T[0];
            count = 0;
        }

        private void Expand()
        {
            if (count == buffer.Length)
            {
                T[] newBuffer;
                if (buffer.Length == 0)
                {
                    newBuffer = new T[2];
                }
                else
                {
                    newBuffer = new T[buffer.Length * 2];
                }
                for (int i = 0; i < buffer.Length; i++)
                {
                    newBuffer[i] = buffer[i];
                }
                buffer = newBuffer;
            }
        }

        public override void Add(T item)
        {
            Expand();
            buffer[count] = item;
            count++;
            OnItemChanged();
        }

        public override void Insert(int pos, T item)
        {
                if (pos < 0 || pos > count)
                {
                    throw new BadIndexException();
                }

                Expand();

                for (int i = count; i > pos; i--)
                {
                    buffer[i] = buffer[i - 1];
                }

                buffer[pos] = item;
                count++;
                OnItemChanged();
        }

        public override void Delete(int pos)
        {
                if (pos < 0 || pos >= count)
                {
                    throw new BadIndexException();
                }

                for (int i = pos; i < count - 1; i++)
                {
                    buffer[i] = buffer[i + 1];
                }
                count--;
                OnItemChanged();            
        }

        public override void Clear()
        {
            //Buffer.Clear(ref buffer, 0);
            buffer = new T[0];
            count = 0;
            OnItemChanged();
        }

        public override T this[int index]
        {
            get
            {
                    if (index < 0 || index >= count)
                    {
                        throw new BadIndexException();
                    }
                    return buffer[index];
            }
            set
            {
                    if (index < 0 || index >= count)
                    {
                        throw new BadIndexException();
                    }
                    buffer[index] = value;
            }
        }

        protected override Base_list<T> EmptyClone()
        {
            return new Arr_list<T>();
        }
        public override string ToString()
        {
            /*string str = "";
            for (int i = 0; i < count; i++)
            {
                str += buffer[i] + " ";
            }
            return str; */
            return string.Join(" ", buffer);
        }
    }
}