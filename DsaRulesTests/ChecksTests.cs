using DsaRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DsaRulesTests
{
    [TestClass]
    //https://www.ulisses-regelwiki.de/checks.html
    //https://www.ulisses-regelwiki.de/GR_Proben.html
    public class ChecksTests
    {
        /// <summary>
        /// This tests only the first dice role and attribute 
        /// </summary>
        /// <param name="returnValue"></param>
        /// <param name="courage"></param>
        /// <param name="result"></param>
        /// <param name="expectedRoleType"></param>
        [DataTestMethod]
        [DynamicData(nameof(FirstDiceRoleInput), DynamicDataSourceType.Property)]
        public void RoleFor_FirstDiceRole(
            int returnValue, 
            int courage,
            int result, 
            RoleResultType expectedRoleType)
        {
            var fakeDice = new FakeDice();
            fakeDice.FirstRoleResult = returnValue;
            var gameMaster = new GameMaster(fakeDice,fakeDice);
            var character = new Character().WithCourage(courage);

            var check = gameMaster.RoleFor(character, Attributes.Courage);

            Assert.AreEqual(result, check.RoleHistory[0].Result);
            Assert.AreEqual(expectedRoleType, check.RoleHistory[0].Type);
        }

        
        public static IEnumerable<object[]> FirstDiceRoleInput
        {
            get
            {
                yield return new object[] { 20, 7, -13, RoleResultType.BeforeFailConfirmation};
                yield return new object[] { 20, 21, 1, RoleResultType.BeforeFailConfirmation };
                yield return new object[] { 1, 7, 6, RoleResultType.BeforeSuccessConfirmation };
                yield return new object[] { 1, 21, 20, RoleResultType.BeforeSuccessConfirmation };
                yield return new object[] { 5, 7, 2, RoleResultType.Success };
                yield return new object[] { 8, 7, -1, RoleResultType.Fail };
                yield return new object[] { 7, 7, 0, RoleResultType.Success };
            }
        }

        /// <summary>
        /// First dice role but with modifications
        /// </summary>
        /// <param name="returnValue"></param>
        /// <param name="courage"></param>
        /// <param name="result"></param>
        /// <param name="expectedRoleType"></param>
        /// <param name="modificator"></param>
        [DataTestMethod]
        [DynamicData(nameof(FirstDiceRoleWithModificatorInputs), DynamicDataSourceType.Property)]
        public void RoleFor_FirstDiceRole_WithModificator(
            int returnValue, 
            int courage, 
            int result, 
            RoleResultType expectedRoleType, 
            int modificator)
        {
            var fakeDice = new FakeDice();
            fakeDice.FirstRoleResult = returnValue;
            var gameMaster = new GameMaster(fakeDice, fakeDice);
            var character = new Character().WithCourage(courage);

            var check = gameMaster.RoleFor(character, Attributes.Courage, modificator);

            Assert.AreEqual(result, check.RoleHistory[0].Result);
            Assert.AreEqual(expectedRoleType, check.RoleHistory[0].Type);
        }

        public static IEnumerable<object[]> FirstDiceRoleWithModificatorInputs
        {
            get
            { 
                yield return new object[] { 7, 7, 1, RoleResultType.Success, 1};
                yield return new object[] { 7, 7, -1, RoleResultType.Fail, -1};
            }
        }

        [TestMethod]
        public void RoleFor_ArgumentException_When_DiceIsNotD20()
        {
            var diceWithSixSites = new Dice().WithSites(6);
            var gameMaster = new GameMaster(diceWithSixSites, diceWithSixSites);
            var character = new Character().WithCourage(7);

           Assert.ThrowsException<ArgumentException>(() => gameMaster.RoleFor(character, Attributes.Courage));
        }

        [TestMethod]
        public void RoleFor_EffectiveAttributeUnderOne()
        {
            var fakeDice = new FakeDice();
            fakeDice.FirstRoleResult = 6;
            var gameMaster = new GameMaster(fakeDice, fakeDice);
            var character = new Character().WithCourage(7);

            var check = gameMaster.RoleFor(character, Attributes.Courage, -7);

            Assert.AreEqual(0, check.RoleHistory.Count);
        }

    }
}