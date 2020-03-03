using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieapi.models;

namespace movieapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsItemsController : ControllerBase
    {
        private readonly FilmsContext _context;

        public FilmsItemsController(FilmsContext context)
        {
            _context = context;
        }

        // GET: api/FilmsItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmsItem>>> GetfilmsItems()
        {
            return await _context.filmsItems.ToListAsync();
        }

        // GET: api/FilmsItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmsItem>> GetFilmsItem(int id)
        {
            var filmsItem = await _context.filmsItems.FindAsync(id);

            if (filmsItem == null)
            {
                return NotFound();
            }

            return filmsItem;
        }

        // PUT: api/FilmsItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmsItem(int id, FilmsItem filmsItem)
        {
            if (id != filmsItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(filmsItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmsItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FilmsItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FilmsItem>> PostFilmsItem(FilmsItem filmsItem)
        {
            _context.filmsItems.Add(filmsItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFilmsItem), new { id = filmsItem.Id }, filmsItem);
        }

        // DELETE: api/FilmsItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FilmsItem>> DeleteFilmsItem(int id)
        {
            var filmsItem = await _context.filmsItems.FindAsync(id);
            if (filmsItem == null)
            {
                return NotFound();
            }

            _context.filmsItems.Remove(filmsItem);
            await _context.SaveChangesAsync();

            return filmsItem;
        }

        private bool FilmsItemExists(int id)
        {
            return _context.filmsItems.Any(e => e.Id == id);
        }
    }
}
