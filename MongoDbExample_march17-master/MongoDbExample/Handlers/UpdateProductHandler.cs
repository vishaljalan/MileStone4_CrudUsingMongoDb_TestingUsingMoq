using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbExample.Commands;
using MongoDbExample.Models;

namespace MongoDbExample.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMongoCollection<Products> _productsCollection;

        public UpdateProductHandler(IOptions<ProductStoreSetting> productDatabaseSettings)
        {
            var mongoClient = new MongoClient(productDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(productDatabaseSettings.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<Products>(productDatabaseSettings.Value.ProductsCollectionName);
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productsCollection.ReplaceOneAsync(x => x.id == request.Id, request.Product, cancellationToken: cancellationToken);
            return Unit.Value;
        }
    }

}
