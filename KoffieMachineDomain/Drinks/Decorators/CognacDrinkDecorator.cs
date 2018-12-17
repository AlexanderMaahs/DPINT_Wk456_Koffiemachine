using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class CognacDrinkDecorator : BaseDrinkDecorator
    {
        private const double COGNAC_PRICE = 0.5;

        public CognacDrinkDecorator(BaseDrink drink) : base(drink)
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice()+COGNAC_PRICE;
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add("Adding Cognac...");
            base.LogDrinkMaking(logText);
        }
    }
}
