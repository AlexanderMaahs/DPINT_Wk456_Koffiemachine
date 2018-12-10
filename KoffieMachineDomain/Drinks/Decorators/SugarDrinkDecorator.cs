using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class SugarDrinkDecorator : BaseDrinkDecorator
    {
        private const double SUGAR_PRICE = 0.1;

        public SugarDrinkDecorator(IDrink drink, ContainmentLevel sugar) : base(drink)
        {
            SugarAmount = sugar;
        }

        public override double GetPrice()
        {
            Price += SUGAR_PRICE;
            return base.GetPrice();
        }
    }
}
