using System;
using Models;
using DataStructures;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Logic
{
    public class Manager
    {
        DoubleLinkList<NodLinkeLiset> LinkTimeBuy;
        Dictionary<string, Dictionary<string, Shoe>> ShoseColloection;
        BST<Location> BnariTree = new BST<Location>();
        Timer Timer;
        public Action<string> Print { get; set; }
        public Manager(Action<string> action, TimeSpan endtime, TimeSpan strattime)
        {
            ShoseColloection = new Dictionary<string, Dictionary<string, Shoe>>();
            Print = action;
            LinkTimeBuy = new DoubleLinkList<NodLinkeLiset>();
            Timer = new Timer(TimerIncedeceModel, null, strattime, endtime);
        }
        public void AddShoes(string brand, string model, float size, int count)
        {
            SizeAndAmount size1 = new SizeAndAmount(size, count);
            if (!ShoseColloection.ContainsKey(brand))
            {
                var NewModel = new Dictionary<string, Shoe>();
                Shoe shoe = new Shoe(brand, model);
                shoe.bstSizeAndAmount.Add(new SizeAndAmount(size, count));
                NewModel.Add(model, shoe);
                ShoseColloection.Add(brand, NewModel);
                //--------------------------------------------------------
                NodLinkeLiset rodLinke = new NodLinkeLiset(brand, model);
                LinkTimeBuy.AddLast(rodLinke);
                ShoseColloection[brand][model].MyNode = LinkTimeBuy.End;
                //---------------------------------------------------------
            }
            else
            {
                if (!ShoseColloection[brand].ContainsKey(model))
                {
                    Shoe s = new Shoe(brand, model);
                    s.bstSizeAndAmount.Add(new SizeAndAmount(size, count));
                    ShoseColloection[brand].Add(model, s);
                    NodLinkeLiset NodLinke = new NodLinkeLiset(brand, model);
                    LinkTimeBuy.AddLast(NodLinke);
                    ShoseColloection[brand][model].MyNode = LinkTimeBuy.End;
                }
                else
                {
                    SizeAndAmount sizes = new SizeAndAmount();
                    if (ShoseColloection[brand][model].bstSizeAndAmount.Search(size1, out sizes))
                    {
                        sizes.AmountInStock += count;
                    }
                    else
                    {
                        ShoseColloection[brand][model].bstSizeAndAmount.Add(size1);
                    }
                }
            }
        }

        public void PrintShoseOnStok(Action<string> action)
        {
            if (ShoseColloection.Count == 0)
            {
                Print("you no have shoe on store");
            }
            else
            {
                foreach (var item in ShoseColloection)
                {
                    Print($"{item.Key}");
                    foreach (var items in item.Value)
                    {
                        Print($"{items.Key}-{items.Value.lastPur}");

                        items.Value.bstSizeAndAmount.PrintInOrder(action);

                        Print("======");
                    }
                }

            }
        }

        public void AddZipCode(Location ZipCode)
        {
            BnariTree.Add(ZipCode);
        }
        public void PrintAllZipCod()
        {
            BnariTree.ScanInOrder(Print);
        }
        public bool SearchShose(string brnd, int num)
        {
            bool d = false;
            foreach (var item in ShoseColloection)
            {
                if (item.Key == brnd)
                {
                    d = true;
                    Print($"Brend- {item.Key}");
                    foreach (var items in item.Value)
                    {
                        Print($"Model-{items.Key}");
                        if (num == 1) Print($"when will we buy - {items.Value.lastPur}");
                        
                    }
                    break;
                }
            }
            if (d == false)
            {
                Print($"your itam {brnd} is no faind in stook");
                return false;
            }
            return true;

        }
        public bool SellShoes(string brand, string modelName, float szie, int amunt)
        {   
            if (!(ShoseColloection.ContainsKey(brand) || ShoseColloection[brand].ContainsKey(modelName))) return false;
            SizeAndAmount d = new SizeAndAmount(szie, amunt);
            SizeAndAmount a = new SizeAndAmount();
            ShoseColloection[brand][modelName].bstSizeAndAmount.Search(d, out a);
            if (a != null && amunt <= a.AmountInStock)
            {
                if (amunt > a.AmountInStock)
                {
                    Print("you buy more than whats in store");
                    return false;
                }
                a.AmountInStock -= amunt;
                ShoseColloection[brand][modelName].lastPur.EnQueue(DateTime.Now);
                //---------------------------------------------------------------------
                string brnLast = LinkTimeBuy.End.Value.Brand;
                string modLast = LinkTimeBuy.End.Value.Model;
                ShoseColloection[brand][modelName].MyNode.Value.TimeOfBuying = DateTime.Now;
                if (brnLast.CompareTo(brand) != 0 && modLast.CompareTo(modelName) != 0)
                {

                    LinkTimeBuy.MoveToEndByNode(ShoseColloection[brand][modelName].MyNode);
                    ShoseColloection[brand][modelName].MyNode = LinkTimeBuy.End;
                }
                //---------------------------------------------------------------------
                if (a.AmountInStock == 0)
                {
                    SizeAndAmount o = new SizeAndAmount();

                    ShoseColloection[brand][modelName].bstSizeAndAmount.Remove(a, out o);
                    if (ShoseColloection[brand][modelName].bstSizeAndAmount.PerRoot() == null)
                    {
                        ShoseColloection[brand].Remove(modelName);
                        LinkTimeBuy.RemoveLast(out NodLinkeLiset nod);
                        if (!ShoseColloection[brand].Any())
                        {
                            ShoseColloection.Remove(brand);

                        }
                    }
                }
            }
            else
            {
                if (a == null)
                {
                    Print("the shoes or size shoes not in store !!!!");
                    return false;
                }
                if (amunt > a.AmountInStock)
                {
                    Print("you buy more than whats in store !!!!");
                    return false;
                }
            }
            return true;

        }
        public bool SearchShoseModelAndPerm(string pirm, string model)
        {
            bool d = false;
            foreach (var item in ShoseColloection)
            {
                if (item.Key == pirm)
                {
                    foreach (var itms in item.Value)
                    {
                        if (itms.Key == model)
                        {
                            d = true;
                            ShoseColloection[pirm][model].bstSizeAndAmount.PrintInOrder(Print);
                        }
                    }
                }
            }
            if (d == false)
            {
                
                Print($"your itam is no faind in stook");
                return false;
            }
            return true;

        }
        public void OrdersAmountplus(Location loc)
        {
            loc.OrdersAmount += 1;
        }
        public void SearchZipClose(string nameorder, int zip, out Location loca1, out Location loca2)
        {
            Location location1 = new Location(nameorder, zip);
            Location location2 = new Location();
            Location location3 = new Location();
            BnariTree.SearchClosePoint(location1, out location2, out location3);
            loca1 = location3;
            loca2 = location2;
            Print($"{location3} , {location2}");
        }
        public void TimerIncedeceModel(Object start)
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            while (LinkTimeBuy.Start != null)
            {
                if (dateTime.Subtract(LinkTimeBuy.Start.Value.TimeOfBuying).TotalSeconds > 60)
                {
                    NodLinkeLiset nodLinkeLiset = new NodLinkeLiset();
                    LinkTimeBuy.RemoveFirst(out nodLinkeLiset);
                    ShoseColloection[nodLinkeLiset.Brand].Remove(nodLinkeLiset.Model);
                    if (!ShoseColloection[nodLinkeLiset.Brand].Any()) 
                    {
                        ShoseColloection.Remove(nodLinkeLiset.Brand);
                    } 
                }
                else break;
            }
        } // timer remove
        public void IncidencesByOreder()
        {
            BST<Location> BstNewLoc = new BST<Location>();
            BnariTree.Incidences(BstNewLoc);
            BstNewLoc.PrintInOrder(Print);
        } // location amunt serch 
    }

}
