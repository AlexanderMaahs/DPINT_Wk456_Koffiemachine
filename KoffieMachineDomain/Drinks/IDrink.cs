using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public interface IDrink
    {
        double Price { get; set; }

        double GetPrice();
    }
}
