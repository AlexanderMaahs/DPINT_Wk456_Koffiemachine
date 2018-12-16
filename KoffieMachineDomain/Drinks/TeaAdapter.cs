using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class TeaAdapter : BaseDrink
    {
        private Tea _adaptee;

        public TeaAdapter(TeaBlend teaBlend)
        {
            _adaptee = new Tea();
            _adaptee.Blend = teaBlend;
        }

        public override string Name
        {
            get { return _adaptee.Blend.Name; }
            set { _adaptee.Blend.Name = value; }
        }

        public override double Price
        {
            get { return _adaptee.Price; }
            set { _adaptee.Price = (float)value; }
        }

        public override double GetPrice()
        {
            return Price;
        }

        public override void LogDrinkMaking(ObservableCollection<string> logText)
        {
            base.LogDrinkMaking(logText);
        }
    }
}
