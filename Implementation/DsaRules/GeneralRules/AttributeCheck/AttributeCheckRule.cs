using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRules.GeneralRules
{
    public static class AttributeCheckRule
    {
        /// <summary>
        /// You always roll one or more D20s for checks. A check succeeds on any result less than or equal to the associated score. A higher result fails.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="character"></param>
        /// <param name="twentySitedDice"></param>
        /// <param name="modificator"></param>
        /// <returns></returns>
        public static Check AttributeCheck(int attributeValue, Dice twentySitedDice, int modificator = 0)
        {
            if(twentySitedDice.NumberOfSites != 20)
            {
                throw new ArgumentException($"Need D20 Dice for {nameof(AttributeCheck)}");
            }
            var check = new Check();
            var effectiveAttributeValue = attributeValue + modificator;

            if(effectiveAttributeValue <= 0)
            {
                return check;
            }

            var firstRoleResult = Check(effectiveAttributeValue, twentySitedDice);
            check.RoleHistory.Add(firstRoleResult);

            if (firstRoleResult.Type == RoleResultType.BeforeFailConfirmation ||
                firstRoleResult.Type == RoleResultType.BeforeSuccessConfirmation)
            {
                CheckForCriticalRole(effectiveAttributeValue, twentySitedDice, check, firstRoleResult);
            }

            return check;
        }

        private static void CheckForCriticalRole(int attributeValue, Dice twentySitedDice, Check check, RoleResult firstRoleResult)
        {
            var secondRoleResult = Check(attributeValue, twentySitedDice);
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

        private static RoleResult Check(int attributeValue, Dice twentySitedDice)
        {
            var diceResult = twentySitedDice.Role();

            var resultedValue = attributeValue - diceResult;


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
