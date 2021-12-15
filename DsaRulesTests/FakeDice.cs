using DsaRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRulesTests
{
    public class FakeDice : Dice
    {
        private int _count;
        public int ReturnValue { get; set; }
        public int SecondReturnValue { get; set; }
        public override int Role()
        {
            _count++;
            if(_count == 1)
            {
                return ReturnValue;
            }
            else
            {
                return SecondReturnValue;
            }
        }
    }
}
