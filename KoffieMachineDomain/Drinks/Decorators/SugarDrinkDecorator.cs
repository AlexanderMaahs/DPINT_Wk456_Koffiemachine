using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class SugarDrinkDecorator : BaseDrinkDecorator
    {
        public static readonly double SUGAR_PRICE = 0.1;

        private ContainmentLevel _sugarAmount;
        public ContainmentLevel SugarAmount
        {
            get { return _sugarAmount; }
            set { _sugarAmount = value; }
        }

        public SugarDrinkDecorator(BaseDrink drink, ContainmentLevel sugar) : base(drink)
        {
            SugarAmount = sugar;
        }

        public override double GetPrice()
        {
            Price += SUGAR_PRICE;
            return base.GetPrice();
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add($"Setting sugar amount to {SugarAmount}");
            logText.Add("Adding sugar...");
            base.LogDrinkMaking(logText);
        }
    }
}
