using System.Collections.Generic;
using System.Linq;
using AcuCafe.Interfaces;

namespace AcuCafe.Drinks
{
    public class DrinkValidator : IDrinkValidator
    {
        private const string ErrorPrefix = "We are unable to prepare your drink.";
        private readonly IDrinkInfoQuery _drinkInfoQuery;
        public DrinkValidator(IDrinkInfoQuery drinkInfoQuery)
        {
            _drinkInfoQuery = drinkInfoQuery;
        }

        public bool ValidateDrinkParameters(string drinkName, IList<string> selectedTopicNames, out string errorMessage)
        {
            if (!ValidateDrinkName(drinkName, out errorMessage)) return false;

            if (!ValidateTopicName(selectedTopicNames, out errorMessage)) return false;

            if (!ValidateTopicIsAllowedForDrink(drinkName, selectedTopicNames, out errorMessage)) return false;

            return true;
        }

        private bool ValidateTopicIsAllowedForDrink(string drinkName, IList<string> selectedTopicNames, out string errorMessage)
        {
            var allowedTopics = _drinkInfoQuery.GetAllowedTopicNames(drinkName).ToList();

            var excluded = allowedTopics.Intersect(selectedTopicNames).Count();

            if (excluded != selectedTopicNames.Count())
            {
                var wrongTopics = selectedTopicNames.Except(allowedTopics).ToList();
                errorMessage = $"{ErrorPrefix} Requested drink ( {drinkName} ) does not have a selection of the folowing topics ( {string.Join(",", wrongTopics)} )";

                return false;
            }

            errorMessage = "";
            return true;
        }


        private bool ValidateTopicName(IList<string> selectedTopicNames, out string errorMessage)
        {
            var allowedTopics = _drinkInfoQuery.GetAllowedTopicNames().ToList();

            var excluded = allowedTopics.Intersect(selectedTopicNames).Count();

            if (excluded != selectedTopicNames.Count())
            {
                var wrongTopics = selectedTopicNames.Except(allowedTopics).ToList();
                errorMessage = $"{ErrorPrefix} The folowing topics ( {string.Join(",", wrongTopics)} ) is not correct";
                return false;
            }

            errorMessage = "";
            return true;
        }

        private bool ValidateDrinkName(string drinkName, out string errorMessage)
        {
            var drinkInfo = _drinkInfoQuery.GetDrinkInfo(drinkName);

            if (drinkInfo == null)
            {
                errorMessage = $"{ErrorPrefix} Requested drink ( {drinkName} ) is not available";
                return false;
            }
            errorMessage = "";
            return true;
        }
    }
}