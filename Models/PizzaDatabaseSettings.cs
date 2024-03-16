namespace api_train_orm.Models
{
    public class PizzaDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PizzaCollectionName { get; set; } = null!;
    }
}
