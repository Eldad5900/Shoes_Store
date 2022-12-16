using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Models
{
   public class SizeAndAmount:IComparable<SizeAndAmount>,IComparer<SizeAndAmount>
    {
        public float Size { get; set; }
        public int AmountInStock { get; set; }
        public SizeAndAmount(float size , int amount)
        {
            this.Size = size;
            this.AmountInStock = amount;
        }
        public SizeAndAmount()
            :this(0,0)
        {

        }
        public override string ToString()
        {
            return $"{Size}-{AmountInStock}";
        }
        public int CompareTo(SizeAndAmount other)
        {
            if (other.Size< Size) return -1;
            if (other.Size > Size) return 1;
            return 0;
        }

        public int Compare( SizeAndAmount x, SizeAndAmount y)
        {
           return x.AmountInStock.CompareTo(y.AmountInStock);
        }
    }
}
