namespace lab2{
    public class Arr_chain_list : Base_list
    {
        private Node head;

        public override int Count => count;

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

        public override void Add(int item)
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

        public override void Insert(int pos, int item)
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

        public override void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public override void Assign(Base_list source)
        {
            Arr_chain_list arrSource = source as Arr_chain_list;
            if (arrSource != null)
            {
                head = null;
                count = 0;
                Node current = arrSource.head;
                while (current != null)
                {
                    Add(current.Data);
                    current = current.Next;
                }
            }
        }

        public override void AssignTo(Base_list dest)
        {
            Arr_chain_list arrDest = dest as Arr_chain_list;
            if (arrDest != null)
            {
                arrDest.head = null;
                arrDest.count = 0;
                Node current = head;
                while (current != null)
                {
                    arrDest.Add(current.Data);
                    current = current.Next;
                }
            }
        }

        public override Base_list Clone()
        {
            Arr_chain_list cloneList = new Arr_chain_list();
            Node current = head;
            while (current != null)
            {
                cloneList.Add(current.Data);
                current = current.Next;
            }
            return cloneList;
        }

        public override Base_list EmptyClone()
        {
            return new Arr_chain_list();
        }

        public override bool IsEqual(Base_list other)
        {
            Arr_chain_list arrOther = other as Arr_chain_list;
            if (arrOther == null || arrOther.count != count)
            {
                return false;
            }

            Node current1 = head;
            Node current2 = arrOther.head;

            while (current1 != null && current2 != null)
            {
                if (current1.Data != current2.Data)
                {
                    return false;
                }
                current1 = current1.Next;
                current2 = current2.Next;
            }

            return true;
        }
    }
}