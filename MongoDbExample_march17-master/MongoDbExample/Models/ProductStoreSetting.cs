namespace MongoDbExample.Models
{
    public class ProductStoreSetting
    {
        public String ConnectionString { get; set; } = null!;

        public String DatabaseName { get; set; } = null!;

        public String ProductsCollectionName { get; set; } = null!;
    }
}
