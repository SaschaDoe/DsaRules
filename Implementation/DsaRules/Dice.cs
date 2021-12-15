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

        public int NumberOfSites
        {
            get { return _numberOfSites; }
            protected set { _numberOfSites = value; }
        }

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

        public Dice D20()
        {
            var dice = new Dice();
            dice._numberOfSites = 20;
            return dice;
        }

        public Dice D6()
        {
            var dice = new Dice();
            dice._numberOfSites = 6;
            return dice;
        }

        public virtual int Role()
        {
            return _random.Next(1, _numberOfSites);
        }
    }
}
