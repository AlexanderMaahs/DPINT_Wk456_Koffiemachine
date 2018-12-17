using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class CointreauDrinkDecorator : BaseDrinkDecorator
    {
        private const double COINTREAU_PRICE = 0.5;
        public CointreauDrinkDecorator(BaseDrink drink) : base(drink)
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice() + COINTREAU_PRICE;
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add("Adding cointreau...");
            base.LogDrinkMaking(logText);
        }
    }
}
