using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class EspressoDrink : Drink
    {
        public virtual bool HasSugar { get; set; }
        public virtual bool HasMilk { get; set; }

        public EspressoDrink()
        {
            Name = "Espresso";
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice + 0.7;
        }

        public override void LogDrinkMaking(ObservableCollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {ContainmentLevel.Max}.");
            log.Add($"Setting coffee amount to {ContainmentLevel.Min}.");
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
