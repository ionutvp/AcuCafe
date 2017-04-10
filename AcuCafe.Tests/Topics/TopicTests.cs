using AcuCafe.Drinks;
using AcuCafe.Topics;
using FakeItEasy;
using NUnit.Framework;

namespace AcuCafe.Tests.Topics
{
    public class TopicTests
    {
        readonly SimpleDrink _simpleDrinkDummy;
        readonly TopicInfo _topicInfoDummy;
        public TopicTests()
        {
            _simpleDrinkDummy = A.Dummy<SimpleDrink>();
            _topicInfoDummy = A.Dummy<TopicInfo>();
        }
       
        [Test]
        public void Topic_Increase_Cost()
        {
            double expected = _simpleDrinkDummy.Cost + _topicInfoDummy.Cost;
            Topic topic = new Topic(_simpleDrinkDummy, _topicInfoDummy);
            Assert.AreEqual(topic.Cost, expected);
        }

        [Test]
        public void Topic_Modify_Description()
        {
            Topic topic = new Topic(_simpleDrinkDummy, _topicInfoDummy);
            bool expected = topic.Description.Contains(_topicInfoDummy.WithMessage);
            Assert.True(expected);
        }
    }
}