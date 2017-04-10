using AcuCafe.Drinks;
using AcuCafe.Topics;
using FakeItEasy;
using NUnit.Framework;

namespace AcuCafe.Tests.Topics
{
    public class TopicFactoryTests
    {
        private readonly TopicFactory _topicFactory;
        public TopicFactoryTests()
        {
            _topicFactory = new TopicFactory();
        }
        [Test]
        public void DrinkTopicFactory_Create_DrinkTopic()
        {
            Topic expected =_topicFactory.Create(A.Dummy<SimpleDrink>(), A.Dummy<TopicInfo>());
            Assert.NotNull(expected);
        }
    }
}
