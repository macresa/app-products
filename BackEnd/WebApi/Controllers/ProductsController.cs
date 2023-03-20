using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;
        public ProductsController(IProductService service)
        => this.service = service;
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetProducts()
        => Ok(await service.GetAllAsync());


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProduct(int id)
        {
            var entity = await service.GetByIdAsync(id);

            return entity == null ? NotFound($"Product Id: {id} was not found") : Ok(entity);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProduct([FromBody] PostProductDTO entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await service.CreateAsync(entity);

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateProduct([FromBody] PutProductDTO entity, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entityId = await service.GetIdAsync(id);

            if (entityId != id) return NotFound($"Product Id: {id} was not found");

            await service.UpdatePartialAsync(entity, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            var entityId = await service.GetIdAsync(id);

            if (entityId != id) return NotFound();

            await service.DeleteAsync(id);

            return NoContent();
        }

    }
}
