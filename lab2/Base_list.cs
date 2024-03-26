// Should work

namespace lab2{
    public abstract class Base_list
    {
        protected int count;

        public int Count 
        {
            get { return count; }
        }

        public abstract void Add(int item);

        public abstract void Insert(int pos, int item);

        public abstract void Delete(int pos);

        public abstract void Clear();

        public abstract int this[int i] { get; set; }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(this[i] + " ");
            }
            Console.WriteLine();
        }

        public void Assign(Base_list source)
        {
            Clear();
            for (int i = 0; i < source.count; i++)
            {
                Add(source[i]);
            }
        }

        public void AssignTo(Base_list dest)
        {
            dest.Assign(this);
        }
       
        public Base_list Clone()
        {
            Base_list clone_list = EmptyClone();
            clone_list.Assign(this);
            return clone_list;
        }
        protected abstract Base_list EmptyClone();

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

        public bool IsEqual(Base_list AnotherOne)
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
    }
}