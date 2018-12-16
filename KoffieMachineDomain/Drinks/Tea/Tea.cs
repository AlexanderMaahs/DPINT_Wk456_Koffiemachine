using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class Tea
    {
        public float Price;

        public int AmountOfSugar { get; set; }
        public TeaBlend Blend { get; set; }

        public void AddSugar()
        {
            AmountOfSugar++;
        }

        public void RemoveSugar()
        {
            AmountOfSugar--;
        }
    }
}
