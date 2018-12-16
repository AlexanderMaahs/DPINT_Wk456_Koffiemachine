using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class StrengthDrinkDecorator : BaseDrinkDecorator
    {
        private ContainmentLevel _drinkStrength;
        public ContainmentLevel DrinkStrength
        {
            get { return _drinkStrength; }
            set { _drinkStrength = value; }
        }

        public StrengthDrinkDecorator(IDrink drink, ContainmentLevel strength) : base(drink)
        {
            DrinkStrength = strength;
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add($"Setting drink strength to {DrinkStrength}");
            logText.Add("Filling with coffee...");
            base.LogDrinkMaking(logText);
        }
    }
}
