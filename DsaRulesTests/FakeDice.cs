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
        public int FirstRoleResult { get; set; }
        public int SecondRoleResult { get; set; }
        public override int Role()
        {
            _count++;
            if(_count == 1)
            {
                return FirstRoleResult;
            }
            else
            {
                return SecondRoleResult;
            }
        }
    }
}
