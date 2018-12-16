using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class TeaBlendRepository
    {
        public IEnumerable<string> BlendNames
        {
            get { return _blends.Keys; }
        }

        private Dictionary<string, TeaBlend> _blends;

        public TeaBlendRepository()
        {
            _blends = new Dictionary<string, TeaBlend>();
            _blends["Earl Grey"] = new EarlGreyTeaBlend();
            _blends["Chai"] = new ChaiTeaBlend();
            _blends["Gold"] = new GoldTeaBlend();
        }

        public TeaBlend GetTeaBlend(string blend)
        {
            TeaBlend teaBlend = null;
            _blends.TryGetValue(blend, out teaBlend);
            if (teaBlend == null)
                throw new InvalidOperationException("Provided drink name does not exist");
            return teaBlend;
        }
    }
}
