using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyntraCloneBackend.Data;
using MyntraCloneBackend.Models;

namespace MyntraCloneBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _context.Categories.ToList();
        }
    }
}
