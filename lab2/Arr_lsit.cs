namespace lab2
{
   public class Arr_list : Base_list
    {
        public override int Count => count;

        public Arr_list()
        {
            fuller = 2;
            buffer = new int[fuller];
            count = 0;
        }

        private void Expand()
        {
            fuller *= 2;
            int[] newBuffer = new int[fuller];
            Array.Copy(buffer, newBuffer, count);
            buffer = newBuffer;
        }

        public override void Add(int item)
        {
            if (count == fuller)
            {
                Expand();
            }

            buffer[count] = item;
            count++;
        }

        public override void Insert(int pos, int item)
        {
            if (pos < 0 || pos > count)
            {
                return;
            }

            if (count == fuller)
            {
                Expand();
            }

            for (int i = count; i > pos; i--)
            {
                buffer[i] = buffer[i - 1];
            }

            buffer[pos] = item;
            count++;
        }

        public override void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                return;
            }

            for (int i = pos; i < count - 1; i++)
            {
                buffer[i] = buffer[i + 1];
            }

            count--;
        }

        public override void Clear()
        {
            buffer = new int[fuller];
            count = 0;
        }

        public override int this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    return 0;
                }
                return buffer[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    return;
                }
                buffer[index] = value;
            }
        }

        public override void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(buffer[i] + " ");
            }
            Console.WriteLine();
        }

        public override void Assign(Base_list source)
        {
            Arr_list arrSource = source as Arr_list;
            if (arrSource != null)
            {
                Array.Copy(arrSource.buffer, buffer, arrSource.count);
                count = arrSource.count;
            }
        }

        public override void AssignTo(Base_list dest)
        {
            Arr_list arrDest = dest as Arr_list;
            if (arrDest != null)
            {
                Array.Copy(buffer, arrDest.buffer, count);
                arrDest.count = count;
            }
        }

        public override Base_list Clone()
        {
            Arr_list cloneList = new Arr_list();
            Array.Copy(buffer, cloneList.buffer, count);
            cloneList.count = count;
            return cloneList;
        }

        public override Base_list EmptyClone()
        {
            return new Arr_list();
        }

        public override bool IsEqual(Base_list other)
        {
            Arr_list arrOther = other as Arr_list;
            if (arrOther == null || arrOther.count != count)
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                if (buffer[i] != arrOther.buffer[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}