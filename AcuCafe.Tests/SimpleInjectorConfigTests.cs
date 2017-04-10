using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using AcuCafe.InformBarista;
using AcuCafe.Interfaces;
using FakeItEasy;
using NUnit.Framework;
using SimpleInjector;

namespace AcuCafe.Tests
{
    public class SimpleInjectorConfigTests
    {
        readonly Container _container;
        public SimpleInjectorConfigTests()
        {
            _container = SimpleInjectorConfig.Register();
        }
        [Test]
        public void Container_Return_AcuCafeInstace()
        {
            AcuCafe acuCafe = _container.GetInstance<AcuCafe>();
            Assert.NotNull(acuCafe);
        }
        [Test]
        public void InformBaristaOnFile_Is_Registered_When_BaristaFileInfo_Is_Not_Null()
        {
            Container container = SimpleInjectorConfig.Register(A.Dummy<BaristaFileInfo>());
            IEnumerable<IInformBarista> informBarista = container.GetAllInstances<IInformBarista>();
            Assert.AreEqual(2,informBarista.Count());
        }

        [Test]
        public void InformBaristaOnFile_Is_Not_Registered_When_BaristaFileInfo_Is_Null()
        {
            Container container = SimpleInjectorConfig.Register();
            IEnumerable<IInformBarista> informBarista = container.GetAllInstances<IInformBarista>();
            Assert.AreEqual(1, informBarista.Count());
        }
    }
}
