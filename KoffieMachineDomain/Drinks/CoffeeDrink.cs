using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class CoffeeDrink : Drink
    {

        public virtual bool HasSugar { get; set; }
        public virtual bool HasMilk { get; set; }

        public override double GetPrice()
        {
            Name = "Koffie";
            return BaseDrinkPrice;
        }

        public override void LogDrinkMaking(ObservableCollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add("Filling with coffee...");

            if (HasSugar)
            {
                log.Add($"Setting sugar amount to {SugarAmount}.");
                log.Add("Adding sugar...");
            }

            if (HasMilk)
            {
                log.Add($"Setting milk amount to {MilkAmount}.");
                log.Add("Adding milk...");
            }

            log.Add($"Finished making {Name}");
        }
    }
}
