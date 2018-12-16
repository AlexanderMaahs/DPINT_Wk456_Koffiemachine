using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class HotChocolateDeluxeDecorator : BaseDrinkDecorator
    {
        public static readonly double DELUXE_PRICE = 0.5;

        public HotChocolateDeluxeDecorator(IDrink drink) : base(drink)
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice() + DELUXE_PRICE;
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add($"Making {Name} Deluxe...");
            logText.Add($"Heating up...");
        }
    }
}
