using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Drinks
{
    public abstract class Drink : IDrink
    {
        protected double _price;

        public static readonly double SugarPrice = 0.1;
        public static readonly double MilkPrice = 0.15;

        protected const double BaseDrinkPrice = 1.0;

        public string Name { get; set; }
        public double Price { get; set; }
        public ContainmentLevel SugarAmount { get; set; }
        public ContainmentLevel MilkAmount { get; set; }
        public ContainmentLevel DrinkStrength { get; set; }

        public virtual double GetPrice()
        {
            return _price;
        }

        public virtual void LogDrinkMaking(ObservableCollection<string> logText)
        {
            logText.Add($"Making {Name}...");
            logText.Add($"Heating up...");
        }
    }
}
