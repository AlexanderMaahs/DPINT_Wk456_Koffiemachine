using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class MilkDrinkDecorator : BaseDrinkDecorator
    {
        public override double GetPrice()
        {
            Price += 0.15;
            return base.GetPrice();
        }
    }
}
