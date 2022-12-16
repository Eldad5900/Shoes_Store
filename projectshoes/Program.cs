using Models;
using System;
using Logic;

namespace projectshoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager managerMain = new Manager((s) => Console.WriteLine(s),new TimeSpan (0,30,0),new TimeSpan (0,30,0));
            Metods metods = new Metods();
            metods.WarehousesAndBuyer(managerMain);
        }
    }
}
