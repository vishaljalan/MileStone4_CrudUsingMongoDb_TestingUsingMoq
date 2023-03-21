using MediatR;
using MongoDbExample.Models;

namespace MongoDbExample.Queries
{

    //all the query related functions are written here
    public record GetProductsQuery() : IRequest<List<Products>>;
    public record GetProductByIdQuery(string Id) : IRequest<Products>;
}

//all the queries related to the functions along with the commands can also be defined in an interface to give a better project
//structure. testing can be implemented with the help of repository pattern. all the methods can be implemete in the repository
