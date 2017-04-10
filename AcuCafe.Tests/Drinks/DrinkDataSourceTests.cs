using System.Linq;
using AcuCafe.Drinks;
using NUnit.Framework;

namespace AcuCafe.Tests.Drinks
{
    public class DrinkDataSourceTests
    {
        readonly DrinkDataSource _drinkDataSource;
        public DrinkDataSourceTests()
        {
            _drinkDataSource = new DrinkDataSource();
        }
        [Test]
        public void GetDrinks_Return_NotEmpty()
        {
            var expected = _drinkDataSource.GetDrinks().ToList();
            Assert.IsNotEmpty(expected);
        }
        [Test]
        public void GetTopics_Return_NotEmpty()
        {
            var expected = _drinkDataSource.GetTopics().ToList();
            Assert.IsNotEmpty(expected);
        }
    }
}
