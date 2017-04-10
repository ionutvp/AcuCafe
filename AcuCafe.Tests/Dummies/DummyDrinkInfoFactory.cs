using System.Collections.Generic;
using AcuCafe.Drinks;
using AcuCafe.Topics;
using FakeItEasy;

namespace AcuCafe.Tests.Dummies
{
    public class DummyDrinkInfoFactory : DummyFactory<DrinkInfo>
    {
        protected override DrinkInfo Create()
        {
            return new DrinkInfo()
            {
                Name = "Expresso",
                Description = "Expresso",
                Cost = 1.8,
                AllowedTopics = new List<TopicInfo>()
                {
                    new TopicInfo()
                    {
                        Id = 1,
                        Cost = 0.5,
                        Name = "milk",
                    },
                    new TopicInfo()
                    {
                        Id = 2,
                        Cost = 0.5,
                        Name = "sugar",
                    },
                    new TopicInfo()
                    {
                        Id = 3,
                        Cost = 0.5,
                        Name = "chocolate",
                    }
                }
            };

        }
    }
}