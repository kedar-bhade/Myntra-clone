using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyntraCloneBackend.Data;
using MyntraCloneBackend.Models;
using MyntraCloneBackend.Services;

namespace MyntraCloneBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cart;
        private readonly AppDbContext _context;

        public CartController(CartService cart, AppDbContext context)
        {
            _cart = cart;
            _context = context;
        }

        [HttpPost("{productId}")]
        public IActionResult Add(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }

            _cart.AddItem(productId);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            var items = _cart.GetItems().Select(i => new {
                Product = _context.Products.Find(i.ProductId),
                i.Quantity
            });
            return Ok(items);
        }
    }
}
