using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbExample.Commands;
using MongoDbExample.Models;

namespace MongoDbExample.Handlers
{

    //I have implemented handlers without the use of repositories, so pure CQRS pattern is follwed here without the repository pattern.
    //Repo pattern could also be implemented, but it would take extra time
    //anyway this will work perfectly fine. moreover testing this will be easier than that with taht of the repository pattern
    //all the handlers following this create are alos in inline with the oattern
    //Handlers are separate. it gives better understanding and the project separation
    public class Program : IRequestHandler<CreateProductCommand, Products>
    {
        private readonly IMongoCollection<Products> _productsCollection;

        public Program(IOptions<ProductStoreSetting> productDatabaseSettings)
        {
            var mongoClient = new MongoClient(productDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(productDatabaseSettings.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<Products>(productDatabaseSettings.Value.ProductsCollectionName);
        }

        public async Task<Products> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productsCollection.InsertOneAsync(request.Product, cancellationToken: cancellationToken);
            return request.Product;
        }
    }
}
