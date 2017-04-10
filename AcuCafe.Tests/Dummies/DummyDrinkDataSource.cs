using System.Collections.Generic;
using System.Linq;
using AcuCafe.Drinks;
using AcuCafe.Interfaces;
using AcuCafe.Topics;

namespace AcuCafe.Tests.Dummies
{
    public class DummyDrinkDataSource : IDrinkDataSource
    {
        public IEnumerable<DrinkInfo> GetDrinks()
        {
            yield return new DrinkInfo
            {
                Name = "HotTea",
                Description = "Hot tea",
                Cost = 1,
                AllowedTopics = GetTopics().Where(x =>
                    x.Id == 2 ||
                    x.Id == 1).ToList()

            };
            yield return new DrinkInfo()
            {
                Name = "IceTea",
                Description = "Ice tea",
                Cost = 1.5,
                AllowedTopics = GetTopics().Where(x =>
                    x.Id == 2)
            };
            yield return new DrinkInfo()
            {
                Name = "Expresso",
                Description = "Expresso",
                Cost = 1.8,
                AllowedTopics = GetTopics().Where(x =>
                    x.Id == 1 ||
                    x.Id == 2 ||
                    x.Id == 3)
            };
        }

        public IEnumerable<TopicInfo> GetTopics()
        {
            yield return new TopicInfo()
            {
                Id = 1,
                Cost = 0.5,
                Name = "milk",
            };
            yield return new TopicInfo()
            {
                Id = 2,
                Cost = 0.5,
                Name = "sugar",
            };
            yield return new TopicInfo()
            {
                Id = 3,
                Cost = 0.5,
                Name = "chocolate",
            };
        }
    }
}
