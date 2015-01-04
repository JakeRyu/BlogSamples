using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thin base pizza
            ThickBase pizza1 = new ThickBase();
            Console.WriteLine(string.Format("Thin pizza base: {0}", pizza1.GetPrice()));

            CheeseTopping cheese = new CheeseTopping(pizza1);
            Console.WriteLine(string.Format("Cheese ${0} topped: {1}", 1, cheese.GetPrice()));

            ShrimpTopping shrimp = new ShrimpTopping(cheese);
            Console.WriteLine(string.Format("Shrimp ${0} topped: {1}", 3, shrimp.GetPrice()));

            Console.WriteLine("------------------------------------");

            CheeseCrustBase pizza2 = new CheeseCrustBase();
            Console.WriteLine(string.Format("Cheese crust pizza base: {0}", pizza2.GetPrice()));

            PineappleTopping pineapple = new PineappleTopping(pizza2);
            Console.WriteLine(string.Format("Pineapple ${0} topped: {1}", 2, pineapple.GetPrice()));

            ShrimpTopping shrimpTopping = new ShrimpTopping(pineapple);
            Console.WriteLine(string.Format("Shrimp ${0} topped: {1}", 3, shrimpTopping.GetPrice()));

            Console.Read();
        }
    }
}
