using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyntraCloneBackend.Data;
using MyntraCloneBackend.Models;

namespace MyntraCloneBackend.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get(int productId)
        {
            return _context.Reviews.Where(r => r.ProductId == productId).ToList();
        }

        [HttpPost]
        public IActionResult Create(int productId, [FromBody] Review review)
        {
            review.ProductId = productId;
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return Ok(review);
        }
    }
}
