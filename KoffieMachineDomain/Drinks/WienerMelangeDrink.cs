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
        public override string Name => "Wiener Melange";

        public WienerMelangeDrink()
        {
            HasSugar = false;
            DrinkStrength = ContaintmentLevel.Min;
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice * 2;
        }
    }
}
