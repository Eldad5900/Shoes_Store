using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Models
{
    public class Location: IComparable<Location>,IComparer<Location>
    {
        //public Incidences MyIncidence { get; set; }
      public int ZipCode { get; set; }
        public int OrdersAmount { get; set; }
       public string Name { get; set; }
        public Location(string name,int zip )
        {
            ZipCode = zip;
            OrdersAmount = 0;
            Name = name;
            //MyIncidence = new Incidences(Name);
        }
        public Location()
            :this("",0)
        {

        }
        public override string ToString()
        {
            return $"{Name}-{ZipCode}-{OrdersAmount}   ";
        }
        public int CompareTo(Location obj)
        {
            if (obj.ZipCode < ZipCode) return -1;
            if (obj.ZipCode > ZipCode) return 1;
            return 0;
        }

        public int Compare( Location x,  Location y)
        {
           return x.OrdersAmount.CompareTo(y.OrdersAmount);
        }
    }
}
