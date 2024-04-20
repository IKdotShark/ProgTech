using System;
using System.Reflection;

namespace lab3
{
    public class Arr_chain_list<T> : Base_list<T> where T: IComparable<T> 
    {
        private Node head = null;

        public class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node(T data, Node next)
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
        public override void Add(T data)
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
            OnItemAdded(data);
        }

        public override void Insert(int pos, T data)
        {
                if (pos < 0 || pos > count)
                {
                    throw new BadIndexException();
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
                OnItemInserted(pos, data);
        }

        public override void Delete(int pos)
        {
                if (pos < 0 || pos >= count)
                {
                    throw new BadIndexException();
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
                OnItemDeleted(pos);
        }

        public override void Clear()
        {
            head = null;
            count = 0;
            OnListCleared();
        }

        public override T this[int index]
        {
            get
            {
                    if (index < 0 || index >= count)
                    {
                        throw new BadIndexException();
                    }
                    Node node = NodeFinder(index);
                    return node.Data;
            }
            set
            {
                    if (index < 0 || index >= count)
                    {
                        throw new BadIndexException();
                    }
                    Node current = NodeFinder(index);
                    current.Data = value;
            }
        }

        protected override Base_list<T> EmptyClone()
        {
            return new Arr_chain_list<T>();
        }

        public override void Sort()
        {
            if (count <= 1)
            {
                return;
            }

            T temp;
            while (true)
            {
                bool t = true;
                Node current = head;

                while (current != null && current.Next != null)
                {
                    if (current.Data.CompareTo(current.Next.Data) > 0)
                    {
                        temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        t = false;
                    }
                    current = current.Next;
                }
                if (t)
                {
                    break;
                }
            }
            /*
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
            }*/
        }
        public override string ToString()
        {
            string str = "";
            Node current = head;
            while (current != null)
            {
                str += current.Data.ToString() + " ";
                current = current.Next;
            }
            return str.Trim();
        }
    }
}