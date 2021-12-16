using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRules.GeneralRules.AttributeCheck
{
    public class SkillCheckRule
    {
        public static SkillCheck SkillCheck(
            int skillValue, 
            Tuple<int,int, int> attributes,
            Dice twentySited, 
            int modificator)
        {
            var skillCheck = new SkillCheck();
            skillCheck.SkillValue = skillValue;
            var effectiveSkillValue = skillValue - modificator;

            var firstCheck = CheckWithoutCriticalConfirmation(attributes.Item1, twentySited.Role(), effectiveSkillValue);
            skillCheck.FirstCheck = firstCheck;

            var secondCheck = CheckWithoutCriticalConfirmation(attributes.Item2, twentySited.Role(), effectiveSkillValue);
            skillCheck.SecondCheck = secondCheck;

            var thirdCheck = CheckWithoutCriticalConfirmation(attributes.Item3, twentySited.Role(), effectiveSkillValue);
            skillCheck.ThirdCheck = thirdCheck;

            

            return skillCheck;
        }

        private static Check CheckWithoutCriticalConfirmation(int attributeValue, int diceResult, int effectiveSkillValue)
        {
            var check = new Check();
            var resultedValue = attributeValue - diceResult;
            var roleResultType = RoleResultType.Success;
            if (diceResult == 1)
            {
                roleResultType =  RoleResultType.EpicSuccess;
            }else if (diceResult == 20)
            {
                roleResultType = RoleResultType.EpicFail;
            }else if (resultedValue < 0)
            {
                roleResultType = RoleResultType.Fail;
            }

            var roleResult = new RoleResult(resultedValue, roleResultType);
            check.CheckResultType = roleResultType;
            check.RoleHistory.Add(roleResult);

            return check;
        }
    }
}
