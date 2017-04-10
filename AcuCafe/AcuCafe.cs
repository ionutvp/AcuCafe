using System;
using System.Collections.Generic;
using AcuCafe.Drinks;
using AcuCafe.Interfaces;

namespace AcuCafe
{
    public class AcuCafe
    {
        
        private readonly IEnumerable<IInformBarista> _informBarista;
        private readonly IDrinkPreparator _drinkPreparator;

        public string LastMessageToBarista { get; private set; }

        public AcuCafe(
            IEnumerable<IInformBarista> informBarista,
            IDrinkPreparator drinkPreparator)
        {
            _informBarista = informBarista;
            _drinkPreparator = drinkPreparator;
        }

        public virtual Drink OrderDrink(string drinkName, IList<string> selectedTopicNames)
        {
            Drink drink;
            try
            {
                string preprationResult;
                drink = _drinkPreparator.Prepare(drinkName, selectedTopicNames, out preprationResult);
                InformBarista(preprationResult);
            }
            catch (Exception ex)
            {
                InformBarista(ex.Message);
                throw;
            }
            return drink;
        }
       
        private void InformBarista(string message)
        {
            foreach (var method in _informBarista)
            {
                method.Inform(message);
            }
            LastMessageToBarista = message;
        }
    }
}