using System.Collections.Generic;
using AcuCafe.Drinks;

namespace AcuCafe.Interfaces
{
    public interface IDrinkPreparator
    {
        Drink Prepare(string drinkName, IList<string> selectedTopicNames, out string preparationResult);
    }
}