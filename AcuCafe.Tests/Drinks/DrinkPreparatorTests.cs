using System.Collections.Generic;
using AcuCafe.Drinks;
using AcuCafe.Interfaces;
using AcuCafe.Topics;
using FakeItEasy;
using NUnit.Framework;

namespace AcuCafe.Tests.Drinks
{
    public class DrinkPreparatorTests
    {
        private readonly DrinkPreparator _drinkPreparator;
        private readonly IDrinkValidator _drinkValidatorFake;

        public DrinkPreparatorTests()
        {
            _drinkValidatorFake = A.Fake<IDrinkValidator>();
            _drinkPreparator = new DrinkPreparator(A.Fake<IDrinkInfoQuery>(), A.Fake<SimpleDrinkFactory>(), A.Fake<TopicFactory>(), _drinkValidatorFake);
        }
        [Test]
        public void Prepare_Return_Drink_When_Drink_Validation_Return_True()
        {
        
            string preparationResult;
            A.CallTo(
                () =>_drinkValidatorFake.ValidateDrinkParameters(A<string>.Ignored, A<List<string>>.Ignored, out preparationResult))
                .WithAnyArguments()
                .Returns(true);
            var drink = _drinkPreparator.Prepare(A.Dummy<string>(), A.Dummy<List<string>>(), out preparationResult);
            Assert.NotNull(drink);
        }

        [Test]
        public void Prepare_Return_ErrorMessage_When_Drink_Validation_Return_False()
        {
            var expected = "Validation error";
            string preparationResult;
            A.CallTo(
                () => _drinkValidatorFake.ValidateDrinkParameters(A<string>.Ignored, A<List<string>>.Ignored, out preparationResult))
                .Returns(false)
                .AssignsOutAndRefParameters(expected); 

            _drinkPreparator.Prepare(A.Dummy<string>(), A.Dummy<List<string>>(), out preparationResult);
            Assert.AreEqual(expected,preparationResult);
        }

        [Test]
        public void Prepare_Return_Null_When_Drink_Validation_Return_False()
        {
            string preparationResult;
            A.CallTo(
                () => _drinkValidatorFake.ValidateDrinkParameters(A<string>.Ignored, A<List<string>>.Ignored, out preparationResult))
                .WithAnyArguments()
                .Returns(false);

            var drink = _drinkPreparator.Prepare(A.Dummy<string>(), A.Dummy<List<string>>(), out preparationResult);
            Assert.Null(drink);
        }
    }
}
