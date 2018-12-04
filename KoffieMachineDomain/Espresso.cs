using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Espresso : Drink
    {
        public override string Name => "Espresso";
        public virtual bool HasSugar { get; set; }
        public virtual ContaintmentLevel SugarAmount { get; set; }
        public virtual bool HasMilk { get; set; }
        public virtual ContaintmentLevel MilkAmount { get; set; }

        public override double GetPrice()
        {
            return BaseDrinkPrice + 0.7;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {ContaintmentLevel.Max}.");
            log.Add($"Setting coffee amount to {ContaintmentLevel.Min}.");
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
