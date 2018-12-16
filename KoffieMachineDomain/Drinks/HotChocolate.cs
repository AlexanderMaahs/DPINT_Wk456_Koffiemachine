using System.Collections.ObjectModel;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Drinks
{
    public class HotChocolate : IDrink
    {
        public string Name { get; set; }
        public double Price { get; set; }

        protected const double BaseDrinkPrice = 1.5;

        public HotChocolate()
        {
            Name = "Chocolate";
        }

        public double GetPrice()
        {
            return BaseDrinkPrice;
        }

        public virtual void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add($"Making {Name}...");
            logText.Add($"Heating up...");
        }
    }
}