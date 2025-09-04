using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly List<Product> _products;

        public ProductsController()
        {
            _products = new List<Product>
            {
            new() {ProductId=1, ProductName="Iphone 14", ProductPrice=60000, IsActive=true},
            new() {ProductId=2, ProductName="Iphone 15", ProductPrice=70000, IsActive=true},
            new() {ProductId=3, ProductName="Iphone 16", ProductPrice=80000, IsActive=true},
            new() {ProductId=4, ProductName="Iphone 17", ProductPrice=90000, IsActive=true}
            };
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            if (_products == null)
            {
                return NotFound();
            }
            return Ok(_products);
        }

        [HttpGet("{id}")]

        public IActionResult GetProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var p = _products.FirstOrDefault(x => x.ProductId == id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }
        

    }
}