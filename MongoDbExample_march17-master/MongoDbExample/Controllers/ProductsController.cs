using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbExample.Commands;
using MongoDbExample.Models;
using MongoDbExample.Queries;
//using MongoDbExample.Services;

namespace MongoDbExample.Controllers
{
    
    //cors is enabed here to allow connecion with angular
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
      
        //mediatr pattern is followed here

        public ProductsController(IMediator mediator) =>
            _mediator = mediator;

        //get request to get all the products
        [HttpGet]
        public async Task<List<Products>> Get() =>
            await _mediator.Send(new GetProductsQuery());

        //get by id is implemented here or the request is sent here based on id
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Products>> Get(string id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        //create request is handled here
        [HttpPost]
        public async Task<IActionResult> Post(Products newProduct)
        {
            var createdProduct = await _mediator.Send(new CreateProductCommand(newProduct));

            return CreatedAtAction(nameof(Get), new { id = createdProduct.id }, createdProduct);
        }

        //update request is handled here
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Products updatedProduct)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product is null)
            {
                return NotFound();
            }

            updatedProduct.id = product.id;

            await _mediator.Send(new UpdateProductCommand(id, updatedProduct));

            return NoContent();
        }

        //delete request is handled here
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product is null)
            {
                return NotFound();
            }

            await _mediator.Send(new DeleteProductCommand(id));

            return NoContent();
        }
    }
}
