using AcuCafe.Drinks;
using AcuCafe.Interfaces;
using AcuCafe.Tests.Dummies;
using NUnit.Framework;

namespace AcuCafe.Tests.Drinks
{
    public class DrinkValidatorTest
    {
        private readonly DrinkValidator _drinkValidator;
        public DrinkValidatorTest()
        {
            IDrinkInfoQuery drinkInfoQuery = new DrinkInfoQuery(new DummyDrinkDataSource());
            _drinkValidator = new DrinkValidator(drinkInfoQuery);
        }

        [TestCase(true, "IceTea")] //no topics
        [TestCase(false, "IceTea", "milk")] //no topics for drink
        [TestCase(true, "IceTea", "sugar")] //good topic
        [TestCase(false, "IceTea", "sugar", "milk")] //good topic no topic for drink combination
        [TestCase(false, "IceTea", "sugar", "inexisting topic")] //good topic inexisting topic combination
        [TestCase(true, "Expresso", "sugar", "milk", "chocolate")] //good multiple topic combination
        [TestCase(false, "Fake drink name", "sugar", "milk", "chocolate")] //bad name
        public void ValidateAllwedTopic_Return_EXPECTED_When_Drink_Is_DRINNAME_And_Topics_Are_TOPICNAMES(bool expected, string drinkName, params string[] topicNames)
        {
            string errorMessage;
            bool actual = _drinkValidator.ValidateDrinkParameters(drinkName, topicNames, out errorMessage);
            Assert.AreEqual(expected, actual);
        }
        [TestCase("IceTea", "milk")]
        [TestCase("IceTea", "milk", "chocolate")]
        [TestCase("Fake drink name")]
        public void ValidateDrinkParameters_Return_ErrorMessages_When_Incorrect_Parameters(string drinkName, params string[] topicNames)
        {
            string errorMessage;
            _drinkValidator.ValidateDrinkParameters(drinkName, topicNames, out errorMessage);
            Assert.IsNotEmpty(errorMessage);
        }
    }
}