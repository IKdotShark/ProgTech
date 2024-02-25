namespace lab1
{
   public class Arr_list
    {
        private int[] buffer;
        private int count; 
        private int fuller;

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
            /*for (int i = 0; i < count; i++)
            {
                newBuffer[i] = buffer[i];
            */
            buffer = newBuffer;
        }

        // private int Count
        public int Count
        {
            get { return count; }
        }
        
        public void Add(int item)
        {
            if (count == fuller)
            {
                Expand();
            }

            buffer[count] = item;
            count++;
        }

        public void Insert(int pos, int item)
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

        public int this[int index]
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

        public void Delete(int  pos)
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

        public void Clear()
        {
            buffer = new int[fuller]; 
            count = 0;
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(buffer[i] + " ");
            }
        }
    }
}

