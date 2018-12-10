using KoffieMachineDomain.Drinks.Decorators;
using KoffieMachineDomain.Enums;
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

        public const string CAFE_AU_LAIT = "Cafe Au Lait";
        public const string CAPUCCINO = "Capuccino";
        public const string COFFEE = "Coffee";
        public const string ESPRESSO = "Espresso";
        public const string WIENER_MELANGE = "Wiener Melange";

        private Dictionary<string, IDrink> _drinks;

        public DrinkFactory()
        {
            _drinks = new Dictionary<string, IDrink>();
            _drinks[CAFE_AU_LAIT] = new CafeAuLaitDrink();
            _drinks[CAPUCCINO] = new CapuccinoDrink();
            _drinks[COFFEE] = new CoffeeDrink();
            _drinks[ESPRESSO] = new EspressoDrink();
            _drinks[WIENER_MELANGE] = new WienerMelangeDrink();
        }

        public IDrink CreateCoffee(string name, ContainmentLevel strength, ContainmentLevel milk, ContainmentLevel sugar)
        {
            IDrink drink = this.GetDrink(name);
            drink = AddSupplements(strength, milk, sugar, drink);
            return drink;
        }


        private IDrink GetDrink(string name)
        {
            IDrink drink = null;
            _drinks.TryGetValue(name, out drink);
            if (drink == null)
                throw new InvalidOperationException("Provided drink name does not exist");
            return drink;
        }

        private IDrink AddSupplements(ContainmentLevel strength, ContainmentLevel milk, ContainmentLevel sugar, IDrink drink)
        {
            drink = new StrengthDrinkDecorator(drink, strength);
            drink = new MilkDrinkDecorator(drink, milk);
            drink = new SugarDrinkDecorator(drink, sugar);
            return drink;
        }


    }
}
