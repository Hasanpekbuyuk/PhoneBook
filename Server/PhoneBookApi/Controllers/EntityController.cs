using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBookApi.Data;
using PhoneBookApi.Models;

namespace PhoneBookApi.Controllers
{
    [Route("api/entity")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListRecords()
        {
            var list = await _context.Persons.ToListAsync();
            return Ok(list);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRecord([FromBody] Person person)
        {
            if (person == null) return BadRequest("Veri boş olamaz");

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }


        [HttpDelete("delete/{name}")]
        public async Task<IActionResult> DeleteRecord(string name)
        {

            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Name == name);

            if (person == null) return NotFound("Kayıt bulunamadı.");

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return Ok($"{name} başarıyla silindi.");
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchRecords(string name)
        {
            var results = await _context.Persons
                                .Where(p => p.Name.Contains(name) || p.PhoneNumber.Contains(name))
                                .ToListAsync();
            return Ok(results);
        }
    }
}