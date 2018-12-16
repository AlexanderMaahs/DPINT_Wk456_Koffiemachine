using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class WienerMelangeDrink : CapuccinoDrink
    {
        private const double WIENERMELANGE_PRICE_MODIFIER = 2;

        public WienerMelangeDrink()
        {
            Name = "Wiener Melange";
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice * WIENERMELANGE_PRICE_MODIFIER;
        }
    }
}
