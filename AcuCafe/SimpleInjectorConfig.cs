using System.Collections.Generic;
using AcuCafe.Drinks;
using AcuCafe.InformBarista;
using AcuCafe.Interfaces;
using SimpleInjector;

namespace AcuCafe
{
    public static class SimpleInjectorConfig
    {
        public static Container Register(BaristaFileInfo baristaFileInfo = null)
        {
            var container = new Container();

            container.RegisterInterfaces();
            container.RegisterInformBarista(baristaFileInfo);
            container.Verify();

            return container;
        }

        public static void RegisterInterfaces(this Container container)
        {
            container.Register<IDrinkValidator, DrinkValidator>();
            container.Register<IDrinkPreparator, DrinkPreparator>();
            container.Register<IDrinkDataSource, DrinkDataSource>();
            container.Register<IDrinkInfoQuery, DrinkInfoQuery>();
        }

        public static void RegisterInformBarista(this Container container, BaristaFileInfo baristaFileInfo)
        {
            var informBarista = new List<IInformBarista>()
            {
                new InformBaristaOnConsole()
            };
            if (baristaFileInfo != null)
            {
                informBarista.Add(new InformBaristaOnFile(baristaFileInfo));
            }
            container.RegisterCollection<IInformBarista>(informBarista);
        }
    }
}