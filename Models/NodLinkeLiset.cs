using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Models
{
    public class NodLinkeLiset:IComparable<NodLinkeLiset>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime TimeOfBuying;
        public NodLinkeLiset(string brand,string model)
        {
            Brand = brand;
            Model = model;
            TimeOfBuying = DateTime.Now;
        }
        public NodLinkeLiset():this("", "")
        {

        }

        public int CompareTo(NodLinkeLiset other)
        {
            throw new NotImplementedException();
        }
    }
}
