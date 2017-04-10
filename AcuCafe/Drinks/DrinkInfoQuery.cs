using System;
using System.Collections.Generic;
using System.Linq;
using AcuCafe.Interfaces;
using AcuCafe.Topics;

namespace AcuCafe.Drinks
{
    public class DrinkInfoQuery : IDrinkInfoQuery
    {
        private readonly IDrinkDataSource _drinkDataSource;
        private readonly Lazy<List<DrinkInfo>> _drinks;
        private readonly Lazy<List<TopicInfo>> _topics;
        public DrinkInfoQuery(IDrinkDataSource drinkDataSource)
        {
            _drinkDataSource = drinkDataSource;
            _drinks = new Lazy<List<DrinkInfo>>(()=> _drinkDataSource.GetDrinks().ToList());
            _topics = new Lazy<List<TopicInfo>>(()=> _drinkDataSource.GetTopics().ToList());
        }

        public IEnumerable<string> GetAllowedTopicNames(string drinkName)
        {
            return _drinks.Value.Where(x => x.Name == drinkName).SelectMany(x=>x.AllowedTopics).Select(x=>x.Name);
        }
        public IEnumerable<string> GetAllowedTopicNames()
        {
            return _drinks.Value.SelectMany(x => x.AllowedTopics).Select(x=>x.Name);
        }

        public IEnumerable<DrinkInfo> GetDrinks()
        {
           return _drinks.Value;
        }

        public IEnumerable<TopicInfo> GetTopics()
        {
           return _topics.Value;
        }

        public IEnumerable<string> GetDrinkNames()
        {
            return _drinks.Value.Select(x => x.Name);
        }

        public DrinkInfo GetDrinkInfo(string drinkName)
        {
            return _drinks.Value.FirstOrDefault(x => x.Name == drinkName);
        }
    }
}