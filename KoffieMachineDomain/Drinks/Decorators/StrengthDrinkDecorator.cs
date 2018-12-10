using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class StrengthDrinkDecorator : BaseDrinkDecorator
    {
        public override double GetPrice()
        {
            //Price += MILK_PRICE;
            return base.GetPrice();
        }
    }
}
