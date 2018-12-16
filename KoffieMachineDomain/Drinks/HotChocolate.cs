using System.Collections.Generic;
using System.Collections.ObjectModel;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Drinks
{
    public class HotChocolate
    {
        private bool _isDeluxe;

        public double Cost()
        {
            if (_isDeluxe)
                return 2.5;
            return 2;
        }
        public IEnumerable<string> GetBuildingSteps()
        {
            return null;
        }

        public string GetNameOfDrink()
        {
            if (_isDeluxe)
                return "Chocolate Deluxe";
            return "Chocolate";
        }

        public void MakeDeluxe()
        {
            _isDeluxe = true;
        }
    }
}