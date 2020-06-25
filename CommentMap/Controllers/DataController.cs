using CommentMap.Data;
using CommentMap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommentMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public DataController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/<DataController>
        [HttpGet]
        [Produces("application/json")]
        public async Task<string> Get()
        {
            var results = await _context.Entries.Where(e => e.DoNotDisplay == false).ToListAsync();
            return JsonSerializer.Serialize(results);
        }        

        // POST api/<DataController>
        [HttpPost]
        public IActionResult Post([FromForm]Entry entry)
        {
            
            _context.Add(entry);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home", new { lat = entry.Lat, lng = entry.Lng });
        }
        
    }
}
