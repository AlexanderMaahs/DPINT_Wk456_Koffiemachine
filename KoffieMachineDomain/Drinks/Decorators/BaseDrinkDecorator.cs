using System.Collections.ObjectModel;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Drinks.Decorators
{
    public abstract class BaseDrinkDecorator : BaseDrink
    {
        protected BaseDrink _nextDrink;

        protected BaseDrinkDecorator(BaseDrink drink) : base(drink.Name)
        {
            _nextDrink = drink;
        }

        public override double Price
        {
            get { return _nextDrink.Price; }
            set { _nextDrink.Price = value; }
        }

        public override string Name
        {
            get { if(_nextDrink != null) return _nextDrink.Name;
                return null;
            }
            set { if (_nextDrink != null) _nextDrink.Name = value; }
        }

        public override double GetPrice()
        {
            return _nextDrink.GetPrice();
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            _nextDrink.LogDrinkMaking(logText);
        }
    }
}