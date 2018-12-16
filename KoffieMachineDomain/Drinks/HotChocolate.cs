using System.Collections.ObjectModel;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Drinks
{
    public class HotChocolate : BaseDrink
    {

        protected const double BaseDrinkPrice = 1.5;

        public HotChocolate()
        {
            Name = "Chocolate";
        }

        public override double GetPrice()
        {
            return base.GetPrice();
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add($"Making {Name}...");
            logText.Add($"Heating up...");
        }
    }
}