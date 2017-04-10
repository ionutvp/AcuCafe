using System.Collections.Generic;
using System.Linq;
using AcuCafe.Interfaces;
using AcuCafe.Topics;

namespace AcuCafe.Drinks
{
    public class DrinkPreparator : IDrinkPreparator
    {
        private const string SuccessPrefix = "We are preparing the following drink for you:";
        private readonly IDrinkInfoQuery _drinkInfoQuery;
        private readonly SimpleDrinkFactory _simpleDrinkFactory;
        private readonly TopicFactory _topicFactory;
        private readonly IDrinkValidator _drinkValidator;

        public DrinkPreparator(IDrinkInfoQuery drinkInfoQuery,
            SimpleDrinkFactory simpleDrinkFactory,
            TopicFactory topicFactory,
            IDrinkValidator drinkValidator)
        {
            _drinkInfoQuery = drinkInfoQuery;
            _simpleDrinkFactory = simpleDrinkFactory;
            _topicFactory = topicFactory;
            _drinkValidator = drinkValidator;
        }

        public Drink Prepare(string drinkName, IList<string> selectedTopicNames, out string preparationResult)
        {
            if (!_drinkValidator.ValidateDrinkParameters(drinkName, selectedTopicNames, out preparationResult)) return null;

            var drinkInfo = _drinkInfoQuery.GetDrinkInfo(drinkName);
            Drink drink = _simpleDrinkFactory.Create(drinkInfo);

            var topics = drinkInfo.AllowedTopics.Where(x => selectedTopicNames.Contains(x.Name));
            drink = AddTopicsToDrink(drink, topics);
            preparationResult = $"{SuccessPrefix} {drink.Description}";
            return drink;
        }

        private Drink AddTopicsToDrink(Drink drink, IEnumerable<TopicInfo> topics)
        {
            foreach (var topic in topics)
            {
                drink = _topicFactory.Create(drink, topic);
            }
            return drink;
        }
    }
}