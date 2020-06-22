using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommentMap.Data;
using CommentMap.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public async Task<string> Get()
        {
            var results = await _context.Entries.Select(e => e.DoNotDisplay == false).ToListAsync();
            return JsonSerializer.Serialize(results);
        }        

        // POST api/<DataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var entry = JsonSerializer.Deserialize<Entry>(value);

            _context.Add(entry);
            _context.SaveChanges();

            RedirectToAction("Index", "Home");
        }
        
    }
}
