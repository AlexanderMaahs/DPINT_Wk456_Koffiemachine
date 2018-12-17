using KoffieMachineDomain.Drinks.Coffee.Special;
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
        public TeaBlendRepository BlendRepo { get; set; }

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
        public const string IRISH_COFFEE = "Irish Coffee";
        public const string SPANISH_COFFEE = "Spanish Coffee";
        public const string ITALIAN_COFFEE = "Italian Coffee";

        private Dictionary<string, BaseDrink> _drinks;

        public DrinkFactory()
        {
            BlendRepo = new TeaBlendRepository();

            _drinks = new Dictionary<string, BaseDrink>();
            _drinks[CAFE_AU_LAIT] = new CafeAuLaitDrink();
            _drinks[CAPUCCINO] = new CapuccinoDrink();
            _drinks[COFFEE] = new CoffeeDrink();
            _drinks[ESPRESSO] = new EspressoDrink();
            _drinks[WIENER_MELANGE] = new WienerMelangeDrink();
            _drinks[CHOCOLATE] = new HotChocolateAdapter();
            _drinks[CHOCOLATE_DELUXE] = new HotChocolateDeluxeAdapter();
            _drinks[IRISH_COFFEE] = GenerateSpecialDrink(IRISH_COFFEE);
            _drinks[SPANISH_COFFEE] = GenerateSpecialDrink(SPANISH_COFFEE);
            _drinks[ITALIAN_COFFEE] = GenerateSpecialDrink(ITALIAN_COFFEE);

        }

        private BaseDrink GenerateSpecialDrink(string name)
        {
            BaseDrink drink = null;
            switch (name)
            {
                case IRISH_COFFEE:
                    drink = new IrishCoffeeDrink();
                    drink = new WhiskyDrinkDecorator(drink);
                        break;
                case SPANISH_COFFEE:
                    drink = new SpanishCoffeeDrink();
                    drink = new CointreauDrinkDecorator(drink);
                    drink = new CognacDrinkDecorator(drink);
                    break;
                case ITALIAN_COFFEE:
                    drink = new ItalianCoffeeDrink();
                    drink = new AmarettoDrinkDecorator(drink);
                    break;
                default:
                    throw new InvalidOperationException("Provided drink name does not exist");
            }
            drink = new WhipCreamDrinkDecorator(drink);
            return drink;
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
            {
                if (baseDrink == null)
                {
                    TeaBlend teaBlend = GetTeaBlend(name);
                    if (teaBlend == null)
                        throw new InvalidOperationException("Provided drink does not exist");
                    baseDrink = new TeaAdapter(teaBlend);
                }
            }
            return baseDrink;
        }

        private TeaBlend GetTeaBlend(string name)
        {
            return BlendRepo.GetTeaBlend(name);
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
