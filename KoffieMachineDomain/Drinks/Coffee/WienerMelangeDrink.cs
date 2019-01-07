using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class WienerMelangeDrink : BaseDrink
    {
        private const double WIENERMELANGE_PRICE_MODIFIER = 2;

        public WienerMelangeDrink():base("Wiener Melange")
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice() * WIENERMELANGE_PRICE_MODIFIER;
        }

        public override void LogDrinkMaking(ObservableCollection<string> log)
        {
        }
    }
}
