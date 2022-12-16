using System;
using System.Diagnostics.CodeAnalysis;
using DataStructures;
using static DataStructures.DoubleLinkList<Models.NodLinkeLiset>;
namespace Models
{
    public class Shoe
    {
        public BST<SizeAndAmount> bstSizeAndAmount;
        public Node MyNode { get; set; }
        public NodLinkeLiset liset { get; set; }
        string brand { get; set; }
        string model { get; set; }
        public CycleTruncateQueue<DateTime> lastPur;

        public Shoe(string brand, string model)
        {
            this.brand = brand;
            this.model = model;
            bstSizeAndAmount = new BST<SizeAndAmount>();
            lastPur = new CycleTruncateQueue<DateTime>();
            liset = new NodLinkeLiset(brand, model);
            MyNode = new Node(liset);
        }
    }
}
