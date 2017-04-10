using System.Collections.Generic;

namespace AcuCafe.Interfaces
{
    public interface IDrinkValidator
    {
        bool ValidateDrinkParameters(string drinkName, IList<string> selectedTopicNames, out string errorMessages);
    }
}