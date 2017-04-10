using AcuCafe.Topics;
using FakeItEasy;

namespace AcuCafe.Tests.Dummies
{
    public class DummyTopicInfo : DummyFactory<TopicInfo>
    {
        protected override TopicInfo Create()
        {
            return new TopicInfo()
            {
                Id = 1,
                Cost = 0.5,
                Name = "milk",
            };
        }
    }
}