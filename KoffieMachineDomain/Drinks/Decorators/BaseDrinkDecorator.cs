using System.Collections.ObjectModel;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public abstract class BaseDrinkDecorator : IDrink
    {
        protected IDrink _nextDrink;

        protected BaseDrinkDecorator(IDrink drink)
        {
            _nextDrink = drink;
        }

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

        public virtual double GetPrice()
        {
            return _nextDrink.GetPrice();
        }

        public virtual void LogDrinkMaking(ObservableCollection<string> logText)
        {
            _nextDrink.LogDrinkMaking(logText);
        }
    }
}