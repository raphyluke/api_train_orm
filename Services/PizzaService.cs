using api_train_orm.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace api_train_orm.Services
{
    public class PizzaService
    {
        private readonly IMongoCollection<Pizza> _pizzaCollection;

        public PizzaService()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("Pizaa");
            _pizzaCollection = mongoDatabase.GetCollection<Pizza>("pizza");
        }

        public async Task<List<Pizza>> GetAsync() => 
            await _pizzaCollection.Find(p => true).ToListAsync();

        // find a pizza by id
        public async Task<Pizza> Get(string id) => 
            await _pizzaCollection.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task Add(Pizza pizza) => 
            await _pizzaCollection.InsertOneAsync(pizza);


        public async Task Delete(string id)
        {
            await _pizzaCollection.DeleteOneAsync(p => p.Id == id);
        }

        public async Task Update(Pizza pizza)
        {
           await _pizzaCollection.ReplaceOneAsync(p => p.Id == pizza.Id, pizza);
        }
    }
}
