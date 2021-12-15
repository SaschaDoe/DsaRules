using DsaRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DsaRulesTests
{
    [TestClass]
    public class CriticalChecksTests
    {
        /// <summary>
        /// Testing the full attribute check which consists sometimes out of two roles when a critical fail or success is there 
        /// </summary>
        /// <param name="firstDiceRole"></param>
        /// <param name="courageValue"></param>
        /// <param name="secondDiceRole"></param>
        /// <param name="expectedRoleType"></param>
        [DataTestMethod]
        [DynamicData(nameof(DiceRolesTestInput), DynamicDataSourceType.Property)]
        public void RoleFor_CriticalTests(int firstDiceRole, int courageValue, int secondDiceRole, RoleResultType expectedRoleType)
        {
            var fakeDice = new FakeDice();
            fakeDice.FirstRoleResult = firstDiceRole;
            fakeDice.SecondRoleResult = secondDiceRole;
            var gameMaster = new GameMaster(fakeDice, fakeDice);
            var character = new Character().WithCourage(courageValue);

            var check = gameMaster.RoleFor(character, Attributes.Courage);
            
            Assert.AreEqual(expectedRoleType, check.CheckResultType);
        }

        public static IEnumerable<object[]> DiceRolesTestInput
        {
            get
            {
                //DiceRole, CourageValue, Second DiceRole, RoleType of second role
                yield return new object[] { 20, 7, 7,  RoleResultType.Fail };
                yield return new object[] { 20, 7, 8,  RoleResultType.EpicFail };
                yield return new object[] { 1, 7, 7,  RoleResultType.EpicSuccess };
                yield return new object[] { 1, 7, 8, RoleResultType.Success };
            }
        }
    }
}
