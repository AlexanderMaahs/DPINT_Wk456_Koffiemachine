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
        public override double GetPrice()
        {
            Price += SUGAR_PRICE;
            return base.GetPrice();
        }
    }
}
