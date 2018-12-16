using KoffieMachineDomain.Drinks.Decorators;
using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class DrinkFactory
    {
        public IEnumerable<string> DrinkNames
        {
            get { return _drinks.Keys; }
        }

        public const string CAFE_AU_LAIT = "Café au Lait";
        public const string CAPUCCINO = "Capuccino";
        public const string COFFEE = "Coffee";
        public const string ESPRESSO = "Espresso";
        public const string WIENER_MELANGE = "Wiener Melange";
        public const string CHOCOLATE = "Chocolate";
        public const string CHOCOLATE_DELUXE = "Chocolate Deluxe";

        private Dictionary<string, BaseDrink> _drinks;

        public DrinkFactory()
        {
            _drinks = new Dictionary<string, BaseDrink>();
            _drinks[CAFE_AU_LAIT] = new CafeAuLaitDrink();
            _drinks[CAPUCCINO] = new CapuccinoDrink();
            _drinks[COFFEE] = new CoffeeDrink();
            _drinks[ESPRESSO] = new EspressoDrink();
            _drinks[WIENER_MELANGE] = new WienerMelangeDrink();
            _drinks[CHOCOLATE] = new HotChocolateAdapter();
            _drinks[CHOCOLATE_DELUXE] = new HotChocolateDeluxeAdapter();
        }

        public BaseDrink CreateDrink(string name, ContainmentLevel strength, ContainmentLevel milk, ContainmentLevel sugar)
        {
            BaseDrink drink = this.GetDrink(name);
            drink = AddSupplements(strength, milk, sugar, drink);
                return drink;
        }

        private BaseDrink GetDrink(string name)
        {
            BaseDrink baseDrink = null;
            _drinks.TryGetValue(name, out baseDrink);
            if (baseDrink == null)
                throw new InvalidOperationException("Provided drink name does not exist");
            return baseDrink;
        }

        private BaseDrink AddSupplements(ContainmentLevel strength, ContainmentLevel milk, ContainmentLevel sugar, BaseDrink drink)
        {
            if(strength != ContainmentLevel.None)
                drink = new StrengthDrinkDecorator(drink, strength);
            if (milk != ContainmentLevel.None)
                drink = new MilkDrinkDecorator(drink, milk);
            if (sugar != ContainmentLevel.None)
                drink = new SugarDrinkDecorator(drink, sugar);
            return drink;
        }


    }
}
