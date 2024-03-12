namespace lab2{
    public abstract class Base_list
    {
        protected int[] buffer;
        protected int count;
        protected int fuller;

        public abstract int Count { get; }

        public abstract void Add(int item);

        public abstract void Insert(int pos, int item);

        public abstract void Delete(int pos);

        public abstract void Clear();

        public abstract int this[int i] { get; set; }

        public abstract void Print();

        public abstract void Assign(Base_list source);

        public abstract void AssignTo(Base_list dest);

        public abstract Base_list Clone();

        public abstract Base_list EmptyClone();

        public virtual void Sort()
        {
            // Реализация сортировки по умолчанию
        }

        public abstract bool IsEqual(Base_list other);
    }
}