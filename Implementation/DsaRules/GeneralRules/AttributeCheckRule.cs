using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRules.GeneralRules
{
    public static class AttributeCheckRule
    {
        internal static RoleResult Check(Attribute attribute, Character character, int diceResult, int modificator = 0)
        {
            var resultedValue = 0;
            if (attribute == Attribute.Courage)
            {
                resultedValue = character.Courage - diceResult + modificator;
            }

            var resultType = RoleType.Success;
            if (resultedValue < 0)
            {
                resultType = RoleType.Fail;
            }
            
            if (diceResult == 1)
            {
                resultType = RoleType.EpicSuccess;
            }
            
            if (diceResult == 20)
            {
                resultType = RoleType.EpicFail;
            }

            var roleResult = new RoleResult(resultedValue, resultType);

            return roleResult;
        }
    }
}
