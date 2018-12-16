using System.Collections.ObjectModel;

namespace KoffieMachineDomain.Drinks
{
    public class HotChocolateAdapter : BaseDrink
    {
        private HotChocolate _adaptee;

        public HotChocolateAdapter()
        {
            _adaptee = new HotChocolate();
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