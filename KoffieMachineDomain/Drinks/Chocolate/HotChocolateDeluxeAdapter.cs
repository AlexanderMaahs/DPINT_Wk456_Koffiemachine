namespace KoffieMachineDomain.Drinks
{
    internal class HotChocolateDeluxeAdapter : BaseDrink
    {
        private HotChocolate _adaptee;

        public HotChocolateDeluxeAdapter() : base("Chocolate Deluxe")
        {
            _adaptee = new HotChocolate();
            _adaptee.MakeDeluxe();
        }

        public override string Name
        {
            get { return _adaptee.GetNameOfDrink(); }
        }

        public override double GetPrice()
        {
            return _adaptee.Cost();
        }
    }
}