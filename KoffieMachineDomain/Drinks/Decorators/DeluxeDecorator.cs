using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class DeluxeDecorator : BaseDrinkDecorator
    {
        public static readonly double DELUXE_PRICE = 0.5;

        public DeluxeDecorator(IDrink drink) : base(drink)
        {
            _nextDrink.Name += " Deluxe";
        }

        public override double GetPrice()
        {
            return base.GetPrice() + DELUXE_PRICE;
        }
    }
}
