using AcuCafe.Drinks;

namespace AcuCafe.Topics
{
    public class Topic : Drink
    {
        private readonly Drink _drink;
        private readonly TopicInfo _topicInfo;

        public Topic(Drink drink, TopicInfo topicInfo)
        {
            _drink = drink;
            _topicInfo = topicInfo;
        }

        public string WithoutMessage => _topicInfo.WithoutMessage;
        public string WithMessage => _topicInfo.WithMessage;

        public override string Description => $"{_drink.Description.Replace(WithoutMessage, WithMessage)}";

        public override double Cost => _drink.Cost + _topicInfo.Cost;

    }
}