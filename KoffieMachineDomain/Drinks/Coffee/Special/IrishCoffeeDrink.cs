using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks.Coffee.Special
{
    public class IrishCoffeeDrink : BaseDrink
    {
        public IrishCoffeeDrink() : base("Irish Coffee")
        {
        }

        public override void LogDrinkMaking(ObservableCollection<string> log)
        {
        }
    }
}
