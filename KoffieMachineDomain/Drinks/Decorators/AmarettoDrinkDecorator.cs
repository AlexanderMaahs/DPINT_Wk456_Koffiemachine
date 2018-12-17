using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class AmarettoDrinkDecorator : BaseDrinkDecorator
    {
        private const double AMARETTO_PRICE = 0.5;
        public AmarettoDrinkDecorator(BaseDrink drink) : base(drink)
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice()+AMARETTO_PRICE;
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add("Adding amaretto...");
            base.LogDrinkMaking(logText);
        }
    }
}
