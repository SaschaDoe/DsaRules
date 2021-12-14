using DsaRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DsaRulesTests
{

    public class FakeDice : Dice
    {
        public int ReturnValue { get; set; }
        public override int Role()
        {
            return ReturnValue;
        }
    }

    [TestClass]
    public class GameMasterRoleForTests
    {
        [DataTestMethod]
        [DynamicData(nameof(DiceRolesTestInput), DynamicDataSourceType.Property)]
        public void RoleFor_Zero_WhenCourageIsTen_DiceRoleIsTen(int returnValue, int courage, int result, RoleType expectedRoleType)
        {
            var fakeDice = new FakeDice();
            fakeDice.ReturnValue = returnValue;
            var gameMaster = new GameMaster(fakeDice,fakeDice);
            var character = new Character().WithCourage(courage);

            var checkResult = gameMaster.RoleFor(character, Attribute.Courage);

            Assert.AreEqual(result, checkResult.Result);
            Assert.AreEqual(expectedRoleType, checkResult.Type);
        }

        public static IEnumerable<object[]> DiceRolesTestInput
        {
            get
            {
                yield return new object[] { 20, 7, -13, RoleType.EpicFail};
                yield return new object[] { 20, 21, 1, RoleType.EpicFail };
                yield return new object[] { 1, 7, 6, RoleType.EpicSuccess };
                yield return new object[] { 1, 21, 20, RoleType.EpicSuccess };
                yield return new object[] { 5, 7, 2, RoleType.Success };
                yield return new object[] { 8, 7, -1, RoleType.Fail };
                yield return new object[] { 7, 7, 0, RoleType.Success };
            }
        }


        [DataTestMethod]
        [DynamicData(nameof(DiceRolesWithModificatorsTestInput), DynamicDataSourceType.Property)]
        public void RoleFor_WithModificator(int returnValue, int courage, int result, RoleType expectedRoleType, int modificator)
        {
            var fakeDice = new FakeDice();
            fakeDice.ReturnValue = returnValue;
            var gameMaster = new GameMaster(fakeDice, fakeDice);
            var character = new Character().WithCourage(courage);

            var checkResult = gameMaster.RoleFor(character, Attribute.Courage, modificator);

            Assert.AreEqual(result, checkResult.Result);
            Assert.AreEqual(expectedRoleType, checkResult.Type);
        }

        public static IEnumerable<object[]> DiceRolesWithModificatorsTestInput
        {
            get
            { 
                yield return new object[] { 7, 7, 1, RoleType.Success, 1};
                yield return new object[] { 7, 7, -1, RoleType.Fail, -1};
            }
        }
    }
}