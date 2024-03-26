namespace lab2
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
                        //Console.WriteLine("Operation add for list successful");
                        break;
                    case 1:
                        array.Delete(pos);
                        chain.Delete(pos);
                        //Console.WriteLine("Operation delete for list successful");
                        break;
                    case 2:
                        array.Insert(pos, item);
                        chain.Insert(pos, item);
                        //Console.WriteLine("Operation insert for list successful");
                        break;
                    case 3:
                        array.Clear();
                        chain.Clear();
                        //Console.WriteLine("Operation clear for list successful");
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
            //Array list
            array.Add(1);
            array.Add(5);
            array.Add(2);
            array.Add(3);
            array.Add(2);
            array.Print();
            array.Sort();
            array.Print();
            array.Clear();
            //Chain list
            chain.Add(1);
            chain.Add(5);
            chain.Add(2);
            chain.Add(3);
            chain.Add(2);
            chain.Print();
            chain.Sort();
            chain.Print();
            chain.Clear();


        }
    }
}