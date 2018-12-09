using System.Collections.ObjectModel;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public abstract class BaseDrinkDecorator : IDrink
    {
        private IDrink _nextDrink;

        public double Price
        {
            get { return _nextDrink.Price; }
            set { _nextDrink.Price = value; }
        }

        public string Name
        {
            get { return _nextDrink.Name; }
            set { _nextDrink.Name = value; }
        }
        public ContainmentLevel SugarAmount
        {
            get { return _nextDrink.SugarAmount; }
            set { _nextDrink.SugarAmount = value; }
        }
        public ContainmentLevel MilkAmount
        {
            get { return _nextDrink.MilkAmount; }
            set { _nextDrink.MilkAmount = value; }
        }
        public ContainmentLevel DrinkStrength
        {
            get { return _nextDrink.DrinkStrength; }
            set { _nextDrink.DrinkStrength = value; }
        }

        public virtual double GetPrice()
        {
            return _nextDrink.GetPrice();
        }

        public void LogDrinkMaking(ObservableCollection<string> logText)
        {
            _nextDrink.LogDrinkMaking(logText);
        }
    }
}