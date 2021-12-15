using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRules.GeneralRules
{
    public static class AttributeCheckRule
    {
        public static Check AttributeCheck(Attributes attribute, Character character, Dice twentySitedDice, int modificator = 0)
        {
            var check = new Check();
            var firstRoleResult = Check(attribute, character, twentySitedDice, modificator);
            check.RoleHistory.Add(firstRoleResult);

            if (firstRoleResult.Type == RoleResultType.BeforeFailConfirmation ||
                firstRoleResult.Type == RoleResultType.BeforeSuccessConfirmation)
            {
                CheckForCriticalRole(attribute, character, twentySitedDice, modificator, check, firstRoleResult);
            }

            return check;
        }

        private static void CheckForCriticalRole(Attributes attribute, Character character, Dice twentySitedDice, int modificator, Check check, RoleResult firstRoleResult)
        {
            var secondRoleResult = Check(attribute, character, twentySitedDice, modificator);
            check.RoleHistory.Add(secondRoleResult);

            if (firstRoleResult.Type == RoleResultType.BeforeSuccessConfirmation)
            {
                if (secondRoleResult.Type == RoleResultType.Success ||
                    secondRoleResult.Type == RoleResultType.BeforeSuccessConfirmation)
                {
                    check.CheckResultType = RoleResultType.EpicSuccess;
                }
                else
                {
                    check.CheckResultType = RoleResultType.Success;
                }
            }

            if (firstRoleResult.Type == RoleResultType.BeforeFailConfirmation ||
                secondRoleResult.Type == RoleResultType.BeforeFailConfirmation)
            {
                if (secondRoleResult.Type == RoleResultType.Fail)
                {
                    check.CheckResultType = RoleResultType.EpicFail;
                }
                else
                {
                    check.CheckResultType = RoleResultType.Fail;
                }
            }
        }

        private static RoleResult Check(Attributes attribute, Character character, Dice twentySitedDice, int modificator = 0)
        {
            var diceResult = twentySitedDice.Role();
            var resultedValue = 0;

            if (attribute == Attributes.Courage)
            {
                resultedValue = character.Courage - diceResult + modificator;
            }

            var resultType = RoleResultType.Success;
            if (resultedValue < 0)
            {
                resultType = RoleResultType.Fail;
            }
            
            if (diceResult == 1)
            {
                resultType = RoleResultType.BeforeSuccessConfirmation;
                
            }
            
            if (diceResult == 20)
            {
                resultType = RoleResultType.BeforeFailConfirmation;
            }

            var roleResult = new RoleResult(resultedValue, resultType);

            return roleResult;
        }
    }
}
