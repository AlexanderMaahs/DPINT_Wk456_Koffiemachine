﻿using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class EspressoDrink : BaseDrink
    {

        private const double ESPRESSO_PRICE_MODIFIER = 0.7;

        public EspressoDrink():base("Espresso")
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice() + ESPRESSO_PRICE_MODIFIER;
        }

        public override void LogDrinkMaking(ObservableCollection<string> log)
        {
        }
    }
}
