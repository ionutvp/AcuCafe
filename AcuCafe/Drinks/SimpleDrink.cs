using System.Linq;
using System.Text;

namespace AcuCafe.Drinks
{
    public class SimpleDrink : Drink
    {
        private readonly DrinkInfo _drinkInfo;

        public SimpleDrink(DrinkInfo drinkInfo)
        {
            _drinkInfo = drinkInfo;
        }
        private string NoTopics()
        {
            var stringBuilder = new StringBuilder();
            foreach (var topic in _drinkInfo.AllowedTopics.ToList())
            {
                stringBuilder.Append(topic.WithoutMessage);
                stringBuilder.Append(" ");
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public override string Description => $"{_drinkInfo.Description} {NoTopics()}";

        public override double Cost => _drinkInfo.Cost;
    }
}