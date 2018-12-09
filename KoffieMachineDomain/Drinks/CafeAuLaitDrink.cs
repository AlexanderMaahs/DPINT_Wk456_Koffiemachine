using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class CafeAuLaitDrink : Drink
    {
        public CafeAuLaitDrink()
        {
            Name = "Café au Lait";
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice + 0.5;
        }

        public override void LogDrinkMaking(ObservableCollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Filling half with coffee...");
            log.Add("Filling other half with milk...");
            log.Add($"Finished making {Name}");
        }
    }
}
