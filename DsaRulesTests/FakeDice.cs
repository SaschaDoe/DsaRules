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
        public FakeDice()
        {
            NumberOfSites = 20;
        }
        private int _count;
        private List<int> _diceRoles;

        public int FirstRoleResult { get; set; }
        public int SecondRoleResult { get; set; }

        public int ThirdRoleResult { get; set; }
        public override int Role()
        {
            if(_diceRoles == null)
            {
                _count++;
                if (_count == 1)
                {
                    return FirstRoleResult;
                }

                if (_count == 2)
                {
                    return SecondRoleResult;
                }
                else
                {
                    return ThirdRoleResult;
                }
            }
            else
            {
                var roleResult = 0;
                if (_diceRoles.Count >= _count)
                {
                    roleResult = _diceRoles[_count];
                    _count++;
                }
                else
                {
                    roleResult = _diceRoles.Last();
                }
                return roleResult;
            }
           
        }

        internal void DiceRoles(List<int> diceRoles)
        {
            _diceRoles = diceRoles;
        }
    }
}
