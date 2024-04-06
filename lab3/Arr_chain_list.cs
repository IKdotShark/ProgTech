namespace lab3
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

        public override void Insert(int pos, int data)
        {
            if (pos < 0 || pos > count)
            {
                return;
            }

            if (pos == 0)
            {
                head = new Node(data, head);
            }
            else
            {
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
            }
        }
    }
}