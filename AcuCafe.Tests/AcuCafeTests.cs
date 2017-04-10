using System;
using System.Collections.Generic;
using AcuCafe.Drinks;
using AcuCafe.Interfaces;
using FakeItEasy;
using NUnit.Framework;

namespace AcuCafe.Tests
{
    public class AcuCafeTests
    {
        readonly IDrinkPreparator _drinkPreparatorFake;
        readonly AcuCafe _acuCafe;
        public AcuCafeTests()
        {
            var informBaristaFake = A.Fake<IInformBarista>();
            _drinkPreparatorFake = A.Fake<IDrinkPreparator>();
            _acuCafe = new AcuCafe(new List<IInformBarista>() { informBaristaFake }, _drinkPreparatorFake);
        }
        [Test]
        public void PrepareDrink_Call_DrinkPreparator_Prepare()
        {
            string ignored;
            _acuCafe.OrderDrink(A.Dummy<string>(), A.Dummy<List<string>>());
            A.CallTo(() => _drinkPreparatorFake.Prepare(A<string>.Ignored, A<List<string>>.Ignored, out ignored)).MustHaveHappened();
        }

        [Test]
        public void PrepareDrink_LastMessage_Is_Not_Null_When_Drink_Cannot_Be_Prepared()
        {
            string expected = "Message after preparation";
            string ignored;

            A.CallTo(() => _drinkPreparatorFake.Prepare(A<string>.Ignored, A<List<string>>.Ignored, out ignored))
                .Returns(null)
                .AssignsOutAndRefParameters(expected);

            _acuCafe.OrderDrink(A.Dummy<string>(), A.Dummy<List<string>>());

            Assert.AreEqual(expected, _acuCafe.LastMessageToBarista);
        }

        [Test]
        public void PrepareDrink_Return_Not_Null_When_Drink_Can_Be_Prepared()
        {
            var fakeDrink = A.Dummy<SimpleDrink>();
            string ignored;
            A.CallTo(() => _drinkPreparatorFake.Prepare(A<string>.Ignored, A<List<string>>.Ignored, out ignored))
                .WithAnyArguments()
                .Returns(fakeDrink);
            var drink = _acuCafe.OrderDrink(A.Dummy<string>(), A.Dummy<List<string>>());

            A.CallTo(() => _drinkPreparatorFake.Prepare(A<string>.Ignored, A<List<string>>.Ignored, out ignored)).MustHaveHappened();
            Assert.NotNull(drink);
        }

        [Test]
        public void PrepareDrink_Inform_Barista_On_Error_Message()
        {
            string ignored;
            A.CallTo(() => _drinkPreparatorFake.Prepare(A<string>.Ignored, A<List<string>>.Ignored, out ignored)).Throws<Exception>().Once();
            Assert.Throws<Exception>(() => _acuCafe.OrderDrink(A.Dummy<string>(), A.Dummy<List<string>>()));

            Assert.NotNull(_acuCafe.LastMessageToBarista);
        }
    }
}

