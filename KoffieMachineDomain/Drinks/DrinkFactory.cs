using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    class DrinkFactory
    {
        public IEnumerable<string> DrinkNames
        {
            get { return _drinks.Keys; }
        }

        private Dictionary<string, IDrink> _drinks;

        public DrinkFactory()
        {
            _drinks = new Dictionary<string, IDrink>();
            _drinks["Cafe Au Lait"] = new CafeAuLaitDrink();
            _drinks["Capuccino"] = new CapuccinoDrink();
            _drinks["Coffee"] = new CoffeeDrink();
            _drinks["Espresso"] = new EspressoDrink();
            _drinks["Wiener Melange"] = new WienerMelangeDrink();
        }

        public IDrink GetDrink(string name)
        {
            IDrink drink = null;
            _drinks.TryGetValue(name, out drink);
            if (drink == null)
                throw new InvalidOperationException("Provided drink name does not exist");
            return drink;
        }
    }
}
