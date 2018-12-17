using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators 
{
    public class WhiskyDrinkDecorator : BaseDrinkDecorator
    {
        private const double WHISKY_PRICE = 1;

        public WhiskyDrinkDecorator(BaseDrink drink) : base(drink)
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice() + WHISKY_PRICE;
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add("Adding whisky...");
            base.LogDrinkMaking(logText);
        }
    }
}
