using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRules
{
    public class Dice
    {
        private int _numberOfSites;
        private Random _random;

        public Dice()
        {
            _random = new Random();
        }

        public Dice WithSites(int numberOfSites)
        {
            var dice = new Dice();
            dice._numberOfSites = numberOfSites;
            return dice;
        }

        public virtual int Role()
        {
            return _random.Next(1, _numberOfSites);
        }
    }
}
