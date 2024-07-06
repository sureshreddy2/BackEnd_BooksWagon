using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksWagonApplication.Models;

namespace BooksWagonApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksWagonController : ControllerBase
    {
        private readonly BookShopContext _context;

        public BooksWagonController(BookShopContext context)
        {
            _context = context;
        }

        // GET: api/BooksWagon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtsPhotographyDatum>>> GetArtsPhotographyData()
        {
            return await _context.ArtsPhotographyData.ToListAsync();
        }

        // GET: api/BooksWagon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtsPhotographyDatum>> GetArtsPhotographyDatum(int id)
        {
            var artsPhotographyDatum = await _context.ArtsPhotographyData.FindAsync(id);

            if (artsPhotographyDatum == null)
            {
                return NotFound();
            }

            return artsPhotographyDatum;
        }

        // PUT: api/BooksWagon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtsPhotographyDatum(int id, ArtsPhotographyDatum artsPhotographyDatum)
        {
            if (id != artsPhotographyDatum.BookTypeId)
            {
                return BadRequest();
            }

            _context.Entry(artsPhotographyDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtsPhotographyDatumExists(id))
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

        // POST: api/BooksWagon
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtsPhotography>> PostArtsPhotographyDatum(ArtsPhotography artsPhotography)
        {
            _context.ArtsPhotographies.Add(artsPhotography);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArtsPhotographyDatumExists(artsPhotography.BookTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArtsPhotographyDatum", new { id = artsPhotography.BookTypeId }, artsPhotography);
        }

        // DELETE: api/BooksWagon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtsPhotographyDatum(int id)
        {
            var artsPhotographyDatum = await _context.ArtsPhotographyData.FindAsync(id);
            if (artsPhotographyDatum == null)
            {
                return NotFound();
            }

            _context.ArtsPhotographyData.Remove(artsPhotographyDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtsPhotographyDatumExists(int? id)
        {
            return _context.ArtsPhotographyData.Any(e => e.BookTypeId == id);
        }
    }
}
