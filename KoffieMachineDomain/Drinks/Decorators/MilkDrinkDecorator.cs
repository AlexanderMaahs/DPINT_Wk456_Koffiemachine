using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public class MilkDrinkDecorator : BaseDrinkDecorator
    {
        public static readonly double MILK_PRICE = 0.15;

        private ContainmentLevel _milkAmount;
        public ContainmentLevel MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; }
        }

        public MilkDrinkDecorator(IDrink drink, ContainmentLevel milk):base(drink)
        {
            MilkAmount = milk;
        }

        public override double GetPrice()
        {
            Price += MILK_PRICE;
            return base.GetPrice();
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add($"Setting milk amount to {MilkAmount}");
            logText.Add("Adding milk...");
            base.LogDrinkMaking(logText);
        }

    }
}
