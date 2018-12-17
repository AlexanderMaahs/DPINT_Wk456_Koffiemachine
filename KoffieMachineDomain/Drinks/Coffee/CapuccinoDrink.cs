using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class CapuccinoDrink : BaseDrink
    {
        private const double CAPUCCINO_PRICE = 0.8;

        public CapuccinoDrink() : base("Capuccino")
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice() + CAPUCCINO_PRICE;
        }
    }
}
