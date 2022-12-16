using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class DoubleLinkList<T> where T : IComparable<T>
    {
        public Node Start = null;
        public Node End = null;

        public void AddFirst(T val) // O(1)
        {
            Node n = new Node(val);
            if (Start == null)
            {
                End = n;
            }
            else
            {
                Start.Previous = n;
            }
            n.Next = Start;
            Start = n;
        }
        public void AddLast(T val)
        {
            if (Start == null)
            {
                AddFirst(val);
                return;
            }
            Node n = new Node(val);
            End.Next = n;
            n.Previous = End;
            End = End.Next;
        } // O(1)
        public bool RemoveFirst(out T saveRemoveValue)
        {
            saveRemoveValue = default;
            if (Start == null) return false;
            saveRemoveValue = Start.Value;
            Start = Start.Next;
            if (Start == null)
            {
                End = null;

            }
            else Start.Previous = null;

            return true;
        } // O(1)
        public bool RemoveLast(out T saveRemoveValue)
        {
            saveRemoveValue = default;    // O(1)
            if (Start == null) return false;
            saveRemoveValue = End.Value;
            Node tmp = new Node(End.Value);
            if (End.Previous != null)
            {
                tmp.Previous = End.Previous;
                End.Previous = null;
                End = tmp.Previous;
                End.Next = null;
            }
            else
            {
                Start = null;
                End = null;
            }
            return true;

        } // O(1)
        public bool Remove(T valu)
        {
            Node tmp = Start;
            T OutValu;
            while (tmp != null)
            {
                if (tmp.Value.CompareTo(valu) == 0)
                {
                    if (tmp.Previous == null)
                    {
                        RemoveFirst(out OutValu);
                        return true;
                    }
                    if (tmp.Next == null)
                    {
                        RemoveLast(out OutValu);
                        return true;
                    }
                    tmp.Next.Previous = tmp.Previous;
                    tmp.Previous.Next = tmp.Next;
                    tmp.Next = null;
                    tmp.Previous = null;
                    return true;
                }
                tmp = tmp.Next;
            }
            return false;
        } //O(n)
        public T this[int index]
        {
            get
            {
                Node tmp = Start;
                int count = 0;
                if (tmp == null) return default;
                while (count != index)
                {
                    tmp = tmp.Next;
                    count++;
                    if (tmp == null) return default;

                }
                return tmp.Value;
            }

        } // GET(place) FUNC    O(n)
        public bool AddAt(int index, T value)
        {
            Node tmpStart = Start;
            int count = 0;
            if (tmpStart == null)
            {
                AddFirst(value);
                return true;
            } //list is empty
            if (index == 0)
            {
                AddFirst(value);
                return true;
            } //enter first num when there is one num
            while (count < index - 1)
            {
                tmpStart = tmpStart.Next;
                count++;
                if (tmpStart == null) return false;

            }
            Node addNode = new Node(value);
            if (tmpStart.Next == null)
            {
                AddLast(value);
                return true;
            } //if it is the last number
            tmpStart.Next.Previous = addNode;
            addNode.Next = tmpStart.Next;
            tmpStart.Next = addNode;
            addNode.Previous = tmpStart;
            return true;

        } //set(place) 

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node tmp = Start;

            while (tmp != null)
            {
                sb.Append(tmp.Value.ToString() + " ");
                tmp = tmp.Next;
            }

            return sb.ToString();
        }
      
        public void MoveToEndByNode(Node MoveLoser)
        {
            if (MoveLoser == null) 
            {
                AddLast(MoveLoser.Value);
                return;
            }
            
            if (MoveLoser.Next == null) return;
            if (MoveLoser.Previous == null)
            {
                Start = Start.Next;
                MoveLoser.Next.Previous = null;
                MoveLoser.Next = null;
                AddLast(MoveLoser.Value);
                return;
            }
            MoveLoser.Next.Previous = MoveLoser.Previous;
            MoveLoser.Previous.Next = MoveLoser.Next;
            MoveLoser.Next = null;
            MoveLoser.Previous = null;
            AddLast(MoveLoser.Value);
        }
       
        public class Node
        {
            public T Value;
            public Node Next;
            public Node Previous;

            public Node(T value)
            {
                this.Value = value;
                Next = null;
            }
        }
    }
}

