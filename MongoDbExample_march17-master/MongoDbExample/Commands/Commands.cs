using MediatR;
using MongoDbExample.Models;

namespace MongoDbExample.Commands
{

    //all the command realted functions are relatd here.
    public record CreateProductCommand(Products Product) : IRequest<Products>;
    public record UpdateProductCommand(string Id, Products Product) : IRequest<Unit>;
    public record DeleteProductCommand(string Id) : IRequest<Unit>;
}
