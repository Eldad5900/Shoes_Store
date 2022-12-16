using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    
        public class QueueWithArray<T> : IEnumerable<T>
        {
           public int FirstInd;
           public int LastInd;
           public T[] QueueArr;

            public QueueWithArray(int size = 5)
            {
                QueueArr = new T[size];
                LastInd = FirstInd = -1;
            }

            public virtual bool EnQueue(T item) // insert
            {
                if (IsFull()) return false;
                if (IsEmpty()) FirstInd = 0;

                LastInd = (LastInd + 1) % QueueArr.Length;
                //lastInd = lastInd + 1;
                //if(lastInd == queueArr.Lenght) lastInd = 0;
                QueueArr[LastInd] = item;
                return true;
            }

            public bool DeQueue(out T removedValue)
            {
                removedValue = default;
                if (IsEmpty()) return false;

                removedValue = QueueArr[FirstInd];
                if (FirstInd == LastInd) FirstInd = LastInd = -1;// removing last item
                else FirstInd = (FirstInd + 1) % QueueArr.Length;
                return true;
            }

            public bool IsEmpty() => FirstInd == -1;
            public bool IsFull() => (LastInd + 1) % QueueArr.Length == FirstInd;

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                int tmp = FirstInd;
                while (tmp != LastInd)
                {
                    sb.Append(QueueArr[tmp] + " ");
                    tmp = (tmp + 1) % QueueArr.Length;
                }
                if (!IsEmpty()) sb.Append(QueueArr[tmp] + " ");
                return sb.ToString();
            }

            public IEnumerator<T> GetEnumerator()
            {
                int tmp = FirstInd;
                if (IsEmpty()) yield break;

                while (tmp != LastInd)
                {
                    yield return QueueArr[tmp];
                    tmp = (tmp + 1) % QueueArr.Length;
                }

                yield return QueueArr[tmp];
            }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    
}
