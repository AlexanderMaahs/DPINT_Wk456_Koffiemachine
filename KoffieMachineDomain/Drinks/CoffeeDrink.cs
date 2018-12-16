using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class CoffeeDrink : CaffeineDrink
    {

        public virtual bool HasSugar { get; set; }
        public virtual bool HasMilk { get; set; }

        public CoffeeDrink():base()
        {
            Name = "Koffie";
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice;
        }

    }
}
