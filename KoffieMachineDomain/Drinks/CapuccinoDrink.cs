using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class CapuccinoDrink : CaffeineDrink
    {
        public virtual bool HasSugar { get; set; }


        public CapuccinoDrink()
        {
            Name = "Capuccino";
            DrinkStrength = ContainmentLevel.Normal;
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice + 0.8;
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

            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
            log.Add($"Finished making {Name}");
        }
    }
}
