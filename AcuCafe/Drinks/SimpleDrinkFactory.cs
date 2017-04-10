namespace AcuCafe.Drinks
{
    public class SimpleDrinkFactory
    {
        public virtual SimpleDrink Create(DrinkInfo drink)
        {
            return new SimpleDrink(drink);
        }
    }
}
