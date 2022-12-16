using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
  public class LinkeLiset<T> : IEnumerable<T>
    {
      public Node start;
       public Node end;

        public bool IsEmpty() => start == null;

        public void AddFirst(T val) // O(1)
        {
            Node n = new Node(val);
            n.next = start;
            start = n;
            if (end == null) end = n;
        }

        public void AddLast(T val) // O(1)
        {
            if (start == null)
            {
                AddFirst(val);
                return;
            }

            Node n = new Node(val);
            end.next = n;
            end = n;
        }

        public bool RemoveFirst(out T saveRemovedValue) // O(1)
        {
            saveRemovedValue = default;
            if (start == null) return false; //remove from empty list

            saveRemovedValue = start.value;
            start = start.next;
            if (start == null) end = null; // last (and the only value) is removed
            return true;
        }

        //public bool RemoveLast(out int saveRemovedValue) // O(n)
        //{

        //}


        public void AddLast_badVersion(T val) // O(n)
        {
            Node last = start;
            if (last == null)
            {
                AddFirst(val);
                return;
            }

            while (last.next != null)
            {
                last = last.next;
            }
            Node n = new Node(val);
            last.next = n;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node tmp = start;

            while (tmp != null)
            {
                sb.Append(tmp.value.ToString() + " ");
                tmp = tmp.next;
            }

            return sb.ToString();
        }


        public bool GetAt(out T foundValue, int index = 0) // O(n)
        {
            foundValue = default;

            Node tmp = start;
            for (int i = 0; tmp != null && i < index; i++)
            {
                tmp = tmp.next;
            }

            if (tmp == null) return false;
            foundValue = tmp.value;
            return true;
        }
        public T this[int index]
        {
            get
            {
                T val;
                if (GetAt(out val, index))
                {
                    return val;
                }
                throw new IndexOutOfRangeException($"index {index} not in range!!!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = start;
            while (currentNode != null)
            {
                yield return currentNode.value;
                currentNode = currentNode.next;
            }
        }

        //public IEnumerator<T> GetEnumerator() //old version
        //{
        //    ListEnumerator iterator = new ListEnumerator(start);
        //    return iterator;
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        //class ListEnumerator : IEnumerator<T>
        //{
        //    Node currentNode;
        //    bool isFirstIteration;

        //    public ListEnumerator(Node start)
        //    {
        //        isFirstIteration = true;
        //        currentNode = start;
        //    }

        //    public T Current
        //    {
        //        get { return currentNode.value; }
        //    }

        //    object IEnumerator.Current => throw new NotImplementedException();

        //    public void Dispose()
        //    {

        //    }

        //    public bool MoveNext()
        //    {
        //        if (isFirstIteration)
        //        {
        //            isFirstIteration = false;
        //            return currentNode != null;                  
        //        }

        //        currentNode = currentNode.next;
        //        if (currentNode != null) return true;
        //        else return false;
        //    }

        //    public void Reset()
        //    {

        //    }
        //}
        public  void MoveToEndByNode(Node MoveLoser)
        {
            if (MoveLoser == null) AddLast(MoveLoser.value);
            if (MoveLoser.next == null) return;
            if(MoveLoser.Previous== null)
            {
                start = start.next;
                MoveLoser.next.Previous = null;
                MoveLoser.next = null;
                AddLast(MoveLoser.value);
                return;
            }
            MoveLoser.next.Previous = MoveLoser.Previous; 
            MoveLoser.Previous.next = MoveLoser.next;
            MoveLoser.next =null;
            MoveLoser.Previous = null;
            AddLast(MoveLoser.value);
        }
       

        public class Node
        {
            public T value;
            public Node next;
            public Node Previous;

            public Node(T value)
            {
                this.value = value;
                next = null;
                Previous = null;
            }
        }
    }
}
