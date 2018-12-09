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

        public virtual double GetPrice()
        {
            return _nextDrink.GetPrice();
        }
    }
}