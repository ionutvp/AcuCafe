using AcuCafe.Drinks;
using FakeItEasy;
using NUnit.Framework;

namespace AcuCafe.Tests.Drinks
{
    public class SimpleDrinkFactoryTests
    {
        private readonly SimpleDrinkFactory _simpleDrinkFactory;
        public SimpleDrinkFactoryTests()
        {
            _simpleDrinkFactory = new SimpleDrinkFactory();
        }
        [Test]
        public void SimpleDrinkFactory_Create_SimpleDrink()
        {
            SimpleDrink expected = _simpleDrinkFactory.Create(A.Fake<DrinkInfo>());
            Assert.NotNull(expected);
        }
    }
}