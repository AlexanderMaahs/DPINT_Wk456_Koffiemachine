using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public abstract class BaseDrink
    {
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }

        protected const double BASE_PRICE = 1;

        public BaseDrink(string name)
        {
            Name = name;
        }

        public virtual double GetPrice()
        {
            return BASE_PRICE;
        }

        public virtual void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add($"Making {Name}...");
            logText.Add($"Heating up...");
        }
    }
}
