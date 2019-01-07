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

        public TeaAdapter(TeaBlend teaBlend) : base(teaBlend.Name)
        {
            _adaptee = new Tea();
            _adaptee.Blend = teaBlend;
        }

        public override string Name
        {
            get { return _adaptee.Blend.Name; }
        }

        public override double GetPrice()
        {
            return base.GetPrice() + _adaptee.Price;
        }

        public override void LogDrinkMaking(ObservableCollection<string> log)
        {
        }
    }
}
