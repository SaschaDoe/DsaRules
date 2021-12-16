using DsaRules.GeneralRules;
using DsaRules.GeneralRules.AttributeCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRules
{
    public class GameMaster
    {
        private readonly Dice _twentySited;
        private readonly Dice _sixSited;

        public GameMaster(Dice twentySited, Dice sixSited)
        {
            this._twentySited = twentySited;
            this._sixSited = sixSited;
        }


        public Check RoleFor(Character character, Attributes attribute, int modificator = 0)
        {
            var check = AttributeCheckRule.AttributeCheck(character.GetAttributeValue(attribute), _twentySited, modificator); 

            return check;
        }
    }
}
