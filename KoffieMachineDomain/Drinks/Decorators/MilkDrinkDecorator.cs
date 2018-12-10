using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class MilkDrinkDecorator : BaseDrinkDecorator
    {
        private const double MILK_PRICE = 0.15;

        public MilkDrinkDecorator(IDrink drink, ContainmentLevel milk):base(drink)
        {
            MilkAmount = milk;
        }

        public override double GetPrice()
        {
            Price += MILK_PRICE;
            return base.GetPrice();
        }
    }
}
