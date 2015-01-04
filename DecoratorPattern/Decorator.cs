using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public abstract class Decorator : PizzaBase
    {
        private PizzaBase pizzaBase = null;

        public Decorator(PizzaBase b)
        {
            this.pizzaBase = b;
        }

        public override decimal GetPrice()
        {
            return this.pizzaBase.GetPrice() + this.price;
        }
    }

    public class CheeseTopping : Decorator
    {
        public CheeseTopping(PizzaBase b) : base(b)
        {
            this.price = 1M;
        }
    }

    public class PineappleTopping : Decorator
    {
        public PineappleTopping(PizzaBase b) : base(b)
        {
            this.price = 2M;
        }
    }

    public class ShrimpTopping : Decorator
    {
        public ShrimpTopping(PizzaBase b) : base(b)
        {
            this.price = 3M;
        }
    }
}
