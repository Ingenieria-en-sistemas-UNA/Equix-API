using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EquixAPI.Entities;
using EquixAPI.Models;

namespace EquixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhrasesController : ControllerBase
    {
        private readonly EquixAPIContext _context;

        public PhrasesController(EquixAPIContext context)
        {
            _context = context;
        }

        // GET: api/Phrases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phrase>>> GetPhrase()
        {
            return await _context.Phrases.ToListAsync();
        }

        // GET: api/Phrases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phrase>> GetPhrase(int id)
        {
            var phrase = await _context.Phrases.FindAsync(id);

            if (phrase == null)
            {
                return NotFound();
            }

            return phrase;
        }

        // PUT: api/Phrases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhrase(int id, Phrase phrase)
        {
            if (id != phrase.Id)
            {
                return BadRequest();
            }

            _context.Entry(phrase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhraseExists(id))
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

        // POST: api/Phrases
        [HttpPost]
        public async Task<ActionResult<Phrase>> PostPhrase(Phrase phrase)
        {
            _context.Phrases.Add(phrase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhrase", new { id = phrase.Id }, phrase);
        }

        // DELETE: api/Phrases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Phrase>> DeletePhrase(int id)
        {
            var phrase = await _context.Phrases.FindAsync(id);
            if (phrase == null)
            {
                return NotFound();
            }

            _context.Phrases.Remove(phrase);
            await _context.SaveChangesAsync();

            return phrase;
        }

        private bool PhraseExists(int id)
        {
            return _context.Phrases.Any(e => e.Id == id);
        }
    }
}
