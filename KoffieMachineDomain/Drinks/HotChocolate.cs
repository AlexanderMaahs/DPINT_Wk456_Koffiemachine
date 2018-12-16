using System.Collections.ObjectModel;

namespace KoffieMachineDomain.Drinks
{
    public class HotChocolate : IDrink
    {
        private bool _isDeluxe;
        public string Name { get; set; }
        public double Price { get; set; }

        protected const double BaseDrinkPrice = 1;

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