using Microsoft.AspNetCore.Mvc;
using ProductApp.Shared.Data;
using ProductApp.Shared.Models;

namespace ProductApp.Mvc.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(ProductRepository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = ProductRepository.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            ProductRepository.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            ProductRepository.Update(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProductRepository.Delete(id);
            return Ok();
        }
    }
}
