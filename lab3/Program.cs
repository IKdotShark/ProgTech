namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Arr_list array = new Arr_list();
            Arr_chain_list chain = new Arr_chain_list();
            Random rnd = new Random();
            for (int i = 0; i < 15000; i++)
            {
                int operation = rnd.Next(5);
                int item = rnd.Next(100);
                int pos = rnd.Next(1000);
                switch (operation)
                {
                    case 0:
                        array.Add(item);
                        chain.Add(item);
                        break;
                    case 1:
                        array.Delete(pos);
                        chain.Delete(pos);
                        break;
                    case 2:
                        array.Insert(pos, item);
                        chain.Insert(pos, item);
                        break;
                    case 3:
                        array.Clear();
                        chain.Clear();
                        break;
                    case 4:
                        array[pos] = item;
                        chain[pos] = item;
                        break;
                }
            }
            
            if (!array.IsEqual(chain))
                Console.WriteLine("Error");
            else
                Console.WriteLine("Successful");

            array.Clear();
            chain.Clear();
        }
       
    }
}