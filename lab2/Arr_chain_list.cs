namespace lab2
{
    public class Arr_chain_list : Base_list
    {
        private Node head = null;

        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        /*
        public Arr_chain_list()
        {
            head = null;
            count = 0;
        }
        */

        private Node NodeFinder(int pos)
        {
            if (pos >= count) {return null;}
            int i = 0;
            Node Checker = head;
            while (Checker != null && i < pos)
            {
                Checker = Checker.Next;
                i++;
            }
            if (i == pos) {return Checker;}
            else {return null;}
        }

        //public override void Add(int item)
        public override void Add(int data)
        {
            if (head == null)
            {
                head = new Node(data, null);
            }
            else
            {
                Node lastNode = NodeFinder(count - 1);
                lastNode.Next = new Node(data, null);
            }
            count++;
        }

        //public override void Insert(int pos, int item)
        public override void Insert(int pos, int data)
        {
            if (pos < 0 || pos > count)
            {
                return;
            }

            if (pos == 0)
            {
                /*
                Node newNode = new Node(item);
                newNode.Next = head;
                head = newNode;
                */
                head = new Node(data, head);
            }
            else
            {
                /*
                Node prevNode = NodeFinder(pos - 1);
                Node newNode = new Node(item);
                newNode.Next = prevNode.Next;
                prevNode.Next = newNode;
                */
                Node prevNode = NodeFinder(pos - 1);
                prevNode.Next = new Node(data, prevNode.Next);
            }
            count++;
        }

        public override void Delete(int pos)
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

        public override void Clear()
        {
            head = null;
            count = 0;
        }

        public override int this[int index]
        {
            get
            {
                //if (index < 0 || index >= count)
                Node current = NodeFinder(index);
                if (current == null)
                {
                    return 0;
                }
                return current.Data;
            }
            set
            {
                Node current = NodeFinder(index);
                //if (index < 0 || index >= count)
                if (current == null)
                {
                    return;
                }
                current.Data = value;
            }
        }

        protected override Base_list EmptyClone()
        {
            return new Arr_chain_list();
        }

        public override void Sort()
        {
            if (count <= 1)
            {
                return;
            }

            int temp;

            for (int i = 0; i < count; i++)
            {
                Node current = head;
            //warning
                while (current != null & current.Next != null)
                {
                    if (current.Data > current.Next.Data)
                    {
                        temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                    }
                    current = current.Next;
                }            
            /*
            Node current = head;
            while (current != null)
            {
                Node min = current;
                Node r = current.Next;
                while (r != null)
                {
                    if (min.Data > r.Data)
                    {
                        min = r;
                    }
                    r = r.Next;
                }
                int temp = current.Data;
                current.Data = min.Data;
                min.Data = temp;
                current = current.Next;
            }*/
            }
        }
    }
}