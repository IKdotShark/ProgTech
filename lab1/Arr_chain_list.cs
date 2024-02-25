namespace lab1
{
public class Arr_chain_list
    {
        private Node head;
        private int count;

        private class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        public Arr_chain_list()
        {
            head = null;
            count = 0;
        }

        // private int Count
        public int Count
        {
            get { return count; }
        }

        private Node NodeFinder(int pos)
        {
            if (pos >= count) return null;
            int i = 0;
            Node Checker = head;
            while (Checker != null && i < pos)
            {
                Checker = Checker.Next;
                i++;
            }
            if (i == pos) return Checker;
            else return null;
        }

        public void Add(int item)
        {
            if (head == null)
            {
                head = new Node(item);
            }
            else
            {
                Node lastNode = NodeFinder(count - 1);
                lastNode.Next = new Node(item);
            }
            count++;
        }

        public void Insert(int pos, int item)
        {
            if (pos < 0 || pos > count)
            {
                return;
            }

            if (pos == 0)
            {
                Node newNode = new Node(item);
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node prevNode = NodeFinder(pos - 1);
                Node newNode = new Node(item);
                newNode.Next = prevNode.Next;
                prevNode.Next = newNode;
            }
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

                Node current = NodeFinder(index);
                return current.Data;
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    return;
                }

                Node current = NodeFinder(index);
                current.Data = value;
            }
        }

        public void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                return;
            }

            if (pos == 0)
            {
                head = head.Next;
            }
            else
            {
                Node prevNode = NodeFinder(pos - 1);
                prevNode.Next = prevNode.Next.Next;
            }
            count--;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}