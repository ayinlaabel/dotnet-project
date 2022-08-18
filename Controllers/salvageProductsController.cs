using salvage_portal.Data;
using salvage_portal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace salvage_portal.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class salvageProductsController : Controller
    {
        private readonly salvagePortalDbContext dbContext;

        public salvageProductsController(salvagePortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            // var test = DotNetEnv.Env.GetString("TEST");
            var products = await dbContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [Route("{id:guid}/edit")]
        [Authorize]
        public async Task<IActionResult> EditProduct()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProduct addProduct)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                title = addProduct.title,
                location = addProduct.location,
                state = addProduct.state,
                closeDate = addProduct.closeDate,
                status = addProduct.status,
                imageUrl = addProduct.imageUrl,
                // sessions = JsonConvert.SerializeObject(addProduct.sessions),
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };


            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return Ok(product);
        }
    }
}