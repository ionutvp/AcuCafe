using AcuCafe.Drinks;
using FakeItEasy;

namespace AcuCafe.Tests.Dummies
{
    public class DummySimpleDrink : DummyFactory<SimpleDrink>
    {
        protected override SimpleDrink Create()
        {
            return new SimpleDrink(A.Dummy<DrinkInfo>());
        }
    }
}