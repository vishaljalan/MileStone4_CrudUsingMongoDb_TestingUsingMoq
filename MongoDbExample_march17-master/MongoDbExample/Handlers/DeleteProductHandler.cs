using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbExample.Commands;
using MongoDbExample.Models;

namespace MongoDbExample.Handlers
{

    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IMongoCollection<Products> _productsCollection;

        public DeleteProductHandler(IOptions<ProductStoreSetting> productDatabaseSettings)
        {
            var mongoClient = new MongoClient(productDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(productDatabaseSettings.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<Products>(productDatabaseSettings.Value.ProductsCollectionName);
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productsCollection.DeleteOneAsync(x => x.id == request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
