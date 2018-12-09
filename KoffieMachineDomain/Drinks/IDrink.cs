using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public interface IDrink
    {
        string Name { get; set; }
        double Price { get; set; }

        ContainmentLevel SugarAmount { get; set; }
        ContainmentLevel MilkAmount { get; set; }
        ContainmentLevel DrinkStrength { get; set; }


        double GetPrice();
        void LogDrinkMaking(ObservableCollection<string> logText);
    }
}
