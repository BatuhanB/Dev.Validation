using Dev.Validation.BusinessLogics.Interfaces;
using Dev.Validation.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Validation.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPut]
        public async Task<IActionResult> Update([FromKeyedServices("productService")] IProductService service, [FromBody] Product product)
        {
            var result = await service.Update(product);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromKeyedServices("productService")] IProductService service)
        {
            var result = await service.GetAll();
            if (result != null)
            {
                return Ok(result.ToList());
            }
            return NotFound(new List<Product>());
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByUd([FromKeyedServices("productService")] IProductService service, [FromRoute] string productId)
        {
            var result = await service.GetById(productId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete([FromKeyedServices("productService")] IProductService service, [FromRoute] string productId)
        {
            var result = await service.Delete(productId);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
