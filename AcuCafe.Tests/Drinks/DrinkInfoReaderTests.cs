using System.Linq;
using AcuCafe.Drinks;
using AcuCafe.Tests.Dummies;
using NUnit.Framework;

namespace AcuCafe.Tests.Drinks
{
    public class DrinkInfoQueryTests
    {
        private readonly DrinkInfoQuery _drinkInfoQuery;

        public DrinkInfoQueryTests()
        {
            _drinkInfoQuery = new DrinkInfoQuery(new DummyDrinkDataSource());
        }

        [Test]
        public void GetDrinks_Return_NotEmpty()
        {
            var topicNames = _drinkInfoQuery.GetDrinks();
            Assert.IsNotEmpty(topicNames);
        }
        [Test]
        public void GetTopics_Return_NotEmpty()
        {
            var topicNames = _drinkInfoQuery.GetTopics();
            Assert.IsNotEmpty(topicNames);
        }

        [Test]
        public void GetAllowedTopicNames_Return_NotEmpty()
        {
            var topicNames = _drinkInfoQuery.GetAllowedTopicNames();
            Assert.IsNotEmpty(topicNames);
        }
        [Test]
        public void GetAllowedTopicNames_Return_NotEmpty_When_Product_Exist()
        {
            var drink = _drinkInfoQuery.GetDrinks().First();
            var expected = drink.AllowedTopics.Select(x=>x.Name);
            var actual = _drinkInfoQuery.GetAllowedTopicNames(drink.Name);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDrinkNames_Return_NotEmpty()
        {
            var actual = _drinkInfoQuery.GetDrinkNames();
            Assert.IsNotEmpty(actual);
        }
    }
}
