using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyntraCloneBackend.Data;
using MyntraCloneBackend.Models;

namespace MyntraCloneBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return _context.Orders
                .Select(o => new Order { Id = o.Id, CreatedAt = o.CreatedAt, Items = o.Items })
                .ToList();
        }

        [HttpPost]
        public IActionResult Create([FromBody] List<OrderItem> items)
        {
            var order = new Order { Items = items };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok(order);
        }
    }
}
