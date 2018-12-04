using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Capuccino : Drink
    {
        public override string Name => "Capuccino";
        public virtual bool HasSugar { get; set; }
        public virtual ContaintmentLevel SugarAmount { get; set; }
        protected virtual ContaintmentLevel DrinkStrength { get; set; }

        public Capuccino()
        {
            DrinkStrength = ContaintmentLevel.Normal;
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice + 0.8;
        }
        public override void LogDrinkMaking(ICollection<string> log)
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
