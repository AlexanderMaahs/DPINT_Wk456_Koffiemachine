using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class CafeAuLaitDrink : BaseDrink
    {
        private const double CAFEAULAIT_PRICE = 0.5;

        public CafeAuLaitDrink() : base("Café au Lait")
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice() + CAFEAULAIT_PRICE;
        }

        public override void LogDrinkMaking(ObservableCollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Filling half with coffee...");
            log.Add("Filling other half with milk...");
        }
    }
}
