using FullPizzApi.Data;
using FullPizzApi.Interfaces;
using FullPizzApi.Models;

namespace FullPizzApi.Repo
{
    public class PizzaRepo : IPizza
    {
        private readonly AppDbContext db;
        public PizzaRepo(AppDbContext db)
        {
            this.db = db;
        }
        public IList<Pizza> GetPizza()
        {
            return db.Pizzas.ToList();
        }

        public Pizza GetPizzaById(int id)
        {
            return db.Pizzas.FirstOrDefault(a => a.Id == id);
        }

        public Pizza GetPizzaByName(string Pizzaname)
        {
            return db.Pizzas.FirstOrDefault(a => a.Name == Pizzaname);
        }

        public Pizza AddPizza(Pizza Pizza)
        {
             db.Pizzas.Add(Pizza);
            db.SaveChanges();
            return Pizza;
        }

        public Pizza UpdatePizza( Pizza Pizza)
        {
            db.Pizzas.Update(Pizza);
            db.SaveChanges();
            return Pizza;
        }

        public Pizza DeletePizza(int id)
        {
           var Delete = db.Pizzas.SingleOrDefault(a=> a.Id== id);
            db.Pizzas.Remove(Delete);
            db.SaveChanges();
            return Delete;
        }
    }
}
