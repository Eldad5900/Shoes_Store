using Logic;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace projectshoes
{
    class Metods
    {public void AddToManager(Manager manager)
        {
            manager.AddShoes("ASICCS", "FFF", 47, 3);
            manager.AddShoes("ADIDAS", "BOOST", 30, 2);
            manager.AddShoes("ADIDAS", "BOOST", 30, 4);
            manager.AddShoes("ADIDAS", "BOOST", 30, 6);
            manager.AddShoes("ASICCS", "TOY", 40, 3);
            manager.AddShoes("NIKE", "AIR", 47, 1);
            manager.AddShoes("POMA", "YOPO", 38, 1);
            manager.AddShoes("REEBOK", "BOK", 39, 9);
            manager.AddShoes("ASICCS", "ASI", 42, 3);
            //////------ZIP COD--------------------------->
            manager.AddZipCode(new Location("Ashdod", 50));
            manager.AddZipCode(new Location("Bat yam", 7));
            manager.AddZipCode(new Location("Akko", 12));
            manager.AddZipCode(new Location("Arad", 9));
            manager.AddZipCode(new Location("Raanana", 14));
            manager.AddZipCode(new Location("Jerusalm", 23));
            manager.AddZipCode(new Location("Haifa", 19));
            manager.AddZipCode(new Location("Tel Aviv", 72));
            manager.AddZipCode(new Location("hole in the desert", 54));
            manager.AddZipCode(new Location("Ashdod d", 67));
            manager.AddZipCode(new Location("Ashdod d", 76));
        }
        public  void WarehousesAndBuyer(Manager managerShop)
        {
            AddToManager(managerShop);
            bool start = true;
            Console.WriteLine("Hello :) ");
            while (start)
            {
                Console.WriteLine("What do you are ? enter one number (1-Warehouses 2-Buyer)");
                string s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        Console.WriteLine("welcome Warehouses");
                        Console.WriteLine("what you want to do ? (1-Add Shoes. 2-Add postal code. 3-view points submission. " +
                            "4-view shoe stock)");
                        string o = Console.ReadLine();
                        switch (o)
                        {
                            case "1":
                                Console.WriteLine("what a perm ?");
                                string permWarehouses = Console.ReadLine().ToUpper();
                                Console.WriteLine("what a kind ?");
                                string kindWarehouses = Console.ReadLine().ToUpper();
                                Console.WriteLine("what a measure ?");
                                bool meas = float.TryParse(Console.ReadLine(), out float measurWarehouses);
                                Console.WriteLine("amount ?!");
                                bool mche = int.TryParse(Console.ReadLine(), out int amountWarehouses);
                                managerShop.AddShoes(permWarehouses, kindWarehouses, measurWarehouses, amountWarehouses);
                                Console.WriteLine("the shoes is add thanks !!!");
                                break;
                            case "2":
                                Console.WriteLine("what a name of arder");
                                string name = Console.ReadLine();
                                Console.WriteLine("what a zip code?");
                                bool f = int.TryParse(Console.ReadLine(), out int zip);
                                Location loc = new Location(name, zip);
                                managerShop.AddZipCode(loc);
                                break;
                            case "3":
                                Console.WriteLine("1-sort by closest all  2-sort by usage");
                                string st = Console.ReadLine();
                                switch (st)
                                {
                                    case "1":
                                        managerShop.PrintAllZipCod();
                                        break;
                                    default:
                                        managerShop.IncidencesByOreder();
                                        break;
                                }
                                
                                break;
                            default:
                                Console.WriteLine(" 1-see per brend 2-see per brend and model 3-see all");
                                string see= Console.ReadLine();
                                switch (see)
                                {
                                    case "1":
                                        Console.WriteLine("whate a brend ?");
                                        string br = Console.ReadLine().ToUpper();
                                        managerShop.SearchShose(br,1);
                                        break;
                                    case"2":
                                        Console.WriteLine("whate a brend ?");
                                        string br1 = Console.ReadLine().ToUpper();
                                        Console.WriteLine("whate a madel ?");
                                        string md1 = Console.ReadLine().ToUpper();
                                        managerShop.SearchShoseModelAndPerm(br1,md1);
                                        break;
                                    default:
                                        managerShop.PrintShoseOnStok(Print);
                                        break;
                                }
                                break;
                        }
                        Console.WriteLine("You want to finish ? (1-yes 2-no)");
                        string e = Console.ReadLine();
                        switch (e)
                        {
                            case "1":
                                start = false;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("welcome Buyer and successful purchase !!");
                        Console.WriteLine("what you want to do ? (1-buy shoes 2-search.)");
                        string r = Console.ReadLine();
                        managerShop.PrintShoseOnStok(Print);
                        Console.WriteLine("!!!! all sohes in stook !!!!");
                        switch (r)
                        {
                            case "1":
                                Console.WriteLine("1-search by brand  2-search by brand and model?");
                                string num = Console.ReadLine();
                                switch (num)
                                {
                                    case "1":
                                        bool fo = true;
                                        while (fo)
                                        {
                                            Console.WriteLine("waht a name of shoes you want buy ?");
                                            string string1 = Console.ReadLine().ToUpper();
                                            Console.WriteLine("=========");
                                            if (managerShop.SearchShose(string1, 0) == false)
                                            {
                                                fo = false;
                                            }
                                            Console.WriteLine("waht a model you want buy ?");
                                            string model1 = Console.ReadLine().ToUpper();
                                            managerShop.SearchShoseModelAndPerm(string1,model1);
                                            Console.WriteLine("waht a measure ?");
                                            bool bo = float.TryParse(Console.ReadLine(), out float measur1);
                                            
                                            Console.WriteLine("waht a several ?");
                                            bool to = int.TryParse(Console.ReadLine(), out int mace);
                                            Console.WriteLine("you want to buy the shoes ? 1-yes 2-no");
                                            string yesOrNoBuys = Console.ReadLine();
                                            switch (yesOrNoBuys)
                                            {
                                                case "1":
                                                    if ( fo == false)
                                                    {
                                                        fo = true;
                                                        managerShop.PrintShoseOnStok(Print);
                                                        Console.WriteLine("your shoe is not fou . we have these shoes ");
                                                    }
                                                    else
                                                    {
                                                        fo = false;
                                                        managerShop.SellShoes(string1, model1, measur1, mace);
                                                        Console.WriteLine("where you live ? (ctiy)");
                                                        string zip = Console.ReadLine();
                                                        Console.WriteLine("waht a zip ?");
                                                        bool ew = int.TryParse(Console.ReadLine(), out int we);
                                                        Location location1 = new Location();
                                                        Location location2 = new Location();
                                                        managerShop.SearchZipClose(zip, we, out location1, out location2);
                                                        Console.WriteLine("where to send ? 1 or 2");
                                                        string pit = Console.ReadLine();
                                                        switch (pit)
                                                        {
                                                            case "1":
                                                                Console.WriteLine($"send to {location1}");
                                                                managerShop.OrdersAmountplus(location1);
                                                                break;
                                                            default:
                                                                Console.WriteLine($"send to {location2}");
                                                                managerShop.OrdersAmountplus(location2);
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        break;

                                    default:
                                        bool foo = true;
                                        while (foo == true)
                                        {
                                            Console.WriteLine("waht a name of shoes you want buy ?");
                                            string q = Console.ReadLine().ToUpper();
                                            Console.WriteLine("waht a model you want buy ?");
                                            string y = Console.ReadLine().ToUpper();
                                            if( managerShop.SearchShoseModelAndPerm(q, y) == false)
                                            {
                                                foo = false;
                                            }
                                            Console.WriteLine("waht a measure ?");
                                            bool b = float.TryParse(Console.ReadLine(), out float measur);
                                            Console.WriteLine("waht a several ?");
                                            bool t = int.TryParse(Console.ReadLine(), out int mac);
                                            Console.WriteLine("you want to buy the shoes ? 1-yes 2-no");
                                            string yesOrNoBuy = Console.ReadLine();
                                            switch (yesOrNoBuy)
                                            {
                                                case "1":
                                                    if (foo == false)
                                                    {
                                                        foo = true;
                                                        managerShop.PrintShoseOnStok(Print);
                                                        Console.WriteLine("your shoe is not fou . we have these shoes ");
                                                    }
                                                    else
                                                    {
                                                        managerShop.SellShoes(q, y, measur, mac);
                                                        Console.WriteLine("wath whre ctiy you live ?");
                                                        string zip = Console.ReadLine();
                                                        Console.WriteLine("waht a zip ?");
                                                        bool ew = int.TryParse(Console.ReadLine(), out int we);
                                                        Location location1 = new Location();
                                                        Location location2 = new Location();
                                                        foo = false;
                                                        managerShop.SearchZipClose(zip, we, out location1, out location2);
                                                        Console.WriteLine("where to send ? 1 or 2");
                                                        string pit = Console.ReadLine();
                                                        switch (pit)
                                                        {
                                                            case "1":
                                                                Console.WriteLine($"send to {location1}");
                                                                managerShop.OrdersAmountplus(location1);
                                                                break;
                                                            default:
                                                                Console.WriteLine($"send to {location2}");
                                                                managerShop.OrdersAmountplus(location2);
                                                                break;
                                                        }


                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }


                                        }
                                        break;

                                }
                                break;
                            case "2":
                                Console.WriteLine("1-Search as per name. 2-Search as per measure and model.");
                                string i = Console.ReadLine();
                                switch (i)
                                {
                                    case "1":
                                        Console.WriteLine("waht a name ?");
                                        string f = Console.ReadLine().ToUpper();
                                        Console.WriteLine("==============");
                                        managerShop.SearchShose(f,0);
                                        Console.WriteLine("-");
                                        break;
                                    default:
                                        Console.WriteLine("waht a name ?");
                                        string perm = Console.ReadLine().ToUpper();
                                        Console.WriteLine("waht a name model ?");
                                        string mod = Console.ReadLine().ToUpper();
                                        managerShop.SearchShoseModelAndPerm(perm, mod);
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("You want to finish ? (1-yes 2-no)");
                        string z = Console.ReadLine();
                        switch (z)
                        {
                            case "1":
                                start = false;
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }
        
        public  void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}
