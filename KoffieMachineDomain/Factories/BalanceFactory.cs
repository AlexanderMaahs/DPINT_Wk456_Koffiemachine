using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class BalanceFactory
    {
        private Dictionary<string, double> _cards;

        public IEnumerable<string> Users
        {
            get { return _cards.Keys; }
        }

        public BalanceFactory()
        {
            _cards = new Dictionary<string, double>();
            _cards["Arjen"] = 5.0;
            _cards["Bert"] = 3.5;
            _cards["Chris"] = 7.0;
            _cards["Daan"] = 6.0;
        }

        public double GetBalance(string name)
        {
            double balance = 0;
            _cards.TryGetValue(name, out balance);
            return balance;
        }

        public void UpdateBalance(string name, double newValue)
        {
            if (!Users.Contains(name)) throw new InvalidOperationException("Provided user does not exist");
            _cards[name] = newValue;
        }
    }
}
