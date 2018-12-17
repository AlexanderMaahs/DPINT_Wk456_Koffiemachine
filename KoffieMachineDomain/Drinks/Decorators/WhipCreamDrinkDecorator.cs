using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class WhipCreamDrinkDecorator : BaseDrinkDecorator
    {
        private const double WHIPCREAM_PRICE = 0.5;

        public WhipCreamDrinkDecorator(BaseDrink drink) : base(drink)
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice() + WHIPCREAM_PRICE;
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add("Adding Whipped Cream");
            base.LogDrinkMaking(logText);
        }
    }
}
