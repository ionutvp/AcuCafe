using AcuCafe.Drinks;

namespace AcuCafe.Topics
{
    public class TopicFactory
    {
        public virtual Topic Create(Drink drink, TopicInfo topicInfo)
        {
            return new Topic(drink, topicInfo);
        }
    }
}