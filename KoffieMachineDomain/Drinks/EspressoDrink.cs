using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class EspressoDrink : CaffeineDrink
    {

        private const double ESPRESSO_PRICE_MODIFIER = 0.7;

        public EspressoDrink()
        {
            Name = "Espresso";
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice + ESPRESSO_PRICE_MODIFIER;
        }
    }
}
