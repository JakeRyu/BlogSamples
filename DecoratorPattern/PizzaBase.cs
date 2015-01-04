using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public abstract class PizzaBase
    {
        protected decimal price;

        public virtual decimal GetPrice()
        {
            return price;
        }
    }

    public class ThickBase : PizzaBase
    {
        public ThickBase()
        {
            this.price = 5.99M;
        }
    }

    public class ThinBase : PizzaBase
    {
        public ThinBase()
        {
            this.price = 6.99M;
        }
    }

    public class CheeseCrustBase : PizzaBase
    {
        public CheeseCrustBase()
        {
            this.price = 9.99M;
        }
    }
}