using System;
using System.Collections;

namespace lab3
{
        class Program
    {
        static void Main(string[] args)
        {
            int arr_count_except = 0;
            int chain_count_except = 0;
            Base_list<char> array = new Arr_list<char>();
            Base_list<char> chain = new Arr_chain_list<char>();
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int operation = rnd.Next(5);
                char item = (char)('a' + rnd.Next(0, 26));
                int pos = rnd.Next(50);
                switch (operation)
                {
                    case 0:
                        array.Add(item);
                        chain.Add(item);
                        break;
                    case 1:
                        try
                        {
                            array.Delete(pos);
                        }
                        catch (BadIndexException)
                        {
                            arr_count_except++;
                            Console.WriteLine("Delete array exception caught");
                        }
                        try
                        {
                            chain.Delete(pos);
                        }
                        catch (BadIndexException)
                        {
                            chain_count_except++;
                            Console.WriteLine("Delete chain exception caught");
                        }
                        break;
                    case 2:
                        try
                        {
                            array.Insert(pos, item);
                        }
                        catch (BadIndexException)
                        {
                            arr_count_except++;
                            Console.WriteLine("Insert array exception caught");
                        }
                        try
                        {
                            chain.Insert(pos, item);
                        }
                        catch (BadIndexException)
                        {
                            chain_count_except++;
                            Console.WriteLine("Insert chain exception caught");
                        }
                        break;
                    case 3:
                        array.Clear();
                        chain.Clear();
                        break;
                    case 4:
                        try
                        {
                            array[pos] = item;
                        }
                        catch (BadIndexException)
                        {
                            arr_count_except++;
                            Console.WriteLine("Set array exception caught");
                        }
                        try
                        {
                            chain[pos] = item;
                        }
                        catch (BadIndexException)
                        {
                            chain_count_except++;
                            Console.WriteLine("Set chain exception caught");
                        }
                        break;
                }
            }

           /*
            bool flag = true;
            if (array.Count == chain.Count)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    if (array[i] != chain[i])
                    {
                        Console.WriteLine("Test error");
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Test error");
                flag = false;
            }
            if (flag == true)
            {
                Console.WriteLine("Test successfull");
            }
            Console.WriteLine(arr_count_except);
            Console.WriteLine(chain_count_except);   */
            /*if (array.IsEqual(chain))
            {
                Console.WriteLine("Test successfull lists are equal\n");
            }
            else
            {
                Console.WriteLine("Test error lists are not equal\n");
            }*/

            //File test
            array.Clear();
            array.Add('1');
            array.Add('2');
            array.Add('6');
            array.Add('4');
            array.Add('5');
            array.Sort();
            Console.WriteLine("Элементы ArrayList: ");
            array.Print();
            string filename = "test_lab3.txt";
            array.SaveToFile(filename);
            Base_list<char> clone = array.Clone();
            Console.WriteLine($"From file {filename}: ");
            clone.Print();
            clone.LoadFromFile(filename);

            /*
            // == != + test
            Console.WriteLine("== != + test");
            if (array == chain){Console.WriteLine("ArrayList == ChainList\n");}
            else{Console.WriteLine("ArrayList != ChainList\n");}
            
            if (array != chain){Console.WriteLine("ArrayList != ChainList\n");}
            else{Console.WriteLine("ArrayList == ChainList\n");}
            */

            clone.Clear();
            array.Print();
            chain.Print();
            clone = array + chain;
            clone.Print();

            Console.WriteLine($"Exception Array: {arr_count_except}");
            Console.WriteLine($"Exception Chain: {chain_count_except}");
            
    }
}        

}
