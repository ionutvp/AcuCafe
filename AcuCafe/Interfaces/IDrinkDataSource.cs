using System.Collections.Generic;
using AcuCafe.Drinks;
using AcuCafe.Topics;

namespace AcuCafe.Interfaces
{
    public interface IDrinkDataSource
    {
        IEnumerable<DrinkInfo> GetDrinks();
        IEnumerable<TopicInfo> GetTopics();
    }
}