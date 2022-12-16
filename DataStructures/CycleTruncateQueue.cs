using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class CycleTruncateQueue<T>:QueueWithArray<T>
    {
        public override bool EnQueue(T item) // insert
        {
            if (IsEmpty()) base.FirstInd = 0;
            LastInd = (LastInd + 1) % QueueArr.Length;
            QueueArr[LastInd]=item;
            return true;
        }
        
    }
}

