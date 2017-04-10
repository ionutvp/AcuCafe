using System.Collections.Generic;
using AcuCafe.Drinks;

namespace AcuCafe.Interfaces
{
    public interface IDrinkInfoQuery: IDrinkDataSource
    {
        IEnumerable<string> GetDrinkNames();
        DrinkInfo GetDrinkInfo(string drinkName);
        IEnumerable<string> GetAllowedTopicNames(string drinkName);
        IEnumerable<string> GetAllowedTopicNames();
    }
}