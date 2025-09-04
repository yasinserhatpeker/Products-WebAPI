using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _context;


        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = entity.ProductId }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Product entity, int id)
        {
            if (entity.ProductId != id)
            {
                return BadRequest();
            }
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = entity.ProductName;
            product.ProductPrice = entity.ProductPrice;
            product.ProductId = entity.ProductId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();

        }
       
    }
}