using AcuCafe.Drinks;
using FakeItEasy;
using NUnit.Framework;

namespace AcuCafe.Tests.Drinks
{
    public class SimpleDrinkTests
    {
        private readonly SimpleDrink _simpleDrink;
        public SimpleDrinkTests()
        {
            _simpleDrink = A.Dummy<SimpleDrink>();
        }
        [Test]
        public void After_Create_Description_Is_Corect()
        {
            string expected = "Expresso without milk without sugar without chocolate";
            
            Assert.AreEqual(expected, _simpleDrink.Description); 
        }
        [Test]
        public void After_Create_Cost_Is_Corect()
        {
            double expected = 1.8;

            Assert.AreEqual(expected, _simpleDrink.Cost);
        }
    }
}
