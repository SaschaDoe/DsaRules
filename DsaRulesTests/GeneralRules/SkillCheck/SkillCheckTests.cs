using DsaRules;
using DsaRules.GeneralRules;
using DsaRules.GeneralRules.AttributeCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRulesTests.GeneralRules.SkillCheck
{
    [TestClass]
    public class SkillCheckTests
    {
        [DataTestMethod]
        [DynamicData(nameof(SkillCheckTestInput), DynamicDataSourceType.Property)]
        public void RoleFor_Skill_ZeroResult(
            List<int> diceRoles,
            int skillValue,
            Tuple<int, int, int> attributes,
            int expectedResultValue,
            RoleResultType expectedCheckResultType,
            int modificator = 0)
        {
            var fakeDice = new FakeDice();
            fakeDice.DiceRoles(diceRoles);

            var skillCheck = SkillCheckRule.SkillCheck(skillValue, attributes, fakeDice, modificator);

            Assert.AreEqual(expectedResultValue, skillCheck.ResultValue);
            Assert.AreEqual(expectedCheckResultType, skillCheck.CheckResultType);
        }


       
        public static IEnumerable<object[]> SkillCheckTestInput
        {
            get
            {
//List of dice roles, Tuple of three attributes, expected result, expected type, modification
                yield return new object[] { new List<int> { 7, 7, 7 }, 0,new Tuple<int, int, int>(7,7,7), 0, RoleResultType.Success };
                yield return new object[] { new List<int> { 7, 7, 8 }, 0, new Tuple<int, int, int>(7, 7, 7), -1, RoleResultType.Fail };
                yield return new object[] { new List<int> { 7, 8, 8 }, 0, new Tuple<int, int, int>(7, 7, 7), -2, RoleResultType.Fail };
                yield return new object[] { new List<int> { 7, 8, 20 }, 0, new Tuple<int, int, int>(7, 7, 7), -14, RoleResultType.Fail };
                yield return new object[] { new List<int> { 7, 20, 20 }, 0, new Tuple<int, int, int>(7, 7, 7), -26, RoleResultType.EpicFail };
                yield return new object[] { new List<int> { 20, 7, 20 }, 0, new Tuple<int, int, int>(7, 7, 7), -26, RoleResultType.EpicFail };
                yield return new object[] { new List<int> { 1, 7, 1 }, 0, new Tuple<int, int, int>(7, 7, 7), 0, RoleResultType.EpicSuccess };
            }
        }


    }
}
