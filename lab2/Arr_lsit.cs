namespace lab2
{
   public class Arr_list : Base_list
    {
        // public override int Count => count;
        
        private int[] buffer;

        public Arr_list()
        {
            buffer = new int[0];
            count = 0;
        }

        // need testing
        private void Expand()
        {
            if (count == buffer.Length)
            {
                int[] newBuffer;
                if (buffer.Length == 0)
                {
                    newBuffer = new int[2];
                }
                else
                {
                    newBuffer = new int[buffer.Length * 2];
                }
                for (int i = 0; i < buffer.Length; i++)
                {
                    newBuffer[i] = buffer[i];
                }
                buffer = newBuffer;
            }
        }

        public override void Add(int item)
        {
            Expand();
            buffer[count] = item;
            count++;
        }

        public override void Insert(int pos, int item)
        {
            if (pos < 0 || pos > count)
            {
                return;
            }

            Expand();

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

        // WARNING: need testing
        public override void Clear()
        {
            buffer = new int[0];
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

        protected override Base_list EmptyClone()
        {
            return new Arr_list();
        }
    }
}