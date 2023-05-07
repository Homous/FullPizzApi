using FullPizzApi.Models;

namespace FullPizzApi.Interfaces
{
    public interface IPizza
    {
        IList<Pizza> GetPizza();
        Pizza GetPizzaById(int id);
        Pizza GetPizzaByName(string Pizzaname);
        Pizza AddPizza(Pizza Pizza);
        Pizza UpdatePizza(Pizza Pizza);
        Pizza DeletePizza(int id);
    }
}
