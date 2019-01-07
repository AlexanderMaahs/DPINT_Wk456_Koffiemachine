using System.Collections.ObjectModel;

namespace KoffieMachineDomain.Drinks.Coffee.Special
{
    public class SpanishCoffeeDrink : BaseDrink
    {
        public SpanishCoffeeDrink():base("Spanish Coffee")
        {
        }

        public override void LogDrinkMaking(ObservableCollection<string> log)
        {
        }
    }
}