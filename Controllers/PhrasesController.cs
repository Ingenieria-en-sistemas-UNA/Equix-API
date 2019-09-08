using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EquixAPI.Entities;
using EquixAPI.Models;
using AutoMapper;

namespace EquixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhrasesController : ControllerBase
    {
        private readonly EquixAPIContext _context;
        private readonly IMapper _mapper;

        public PhrasesController(EquixAPIContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Phrases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutPhraseDTO>>> GetPhrase()
        {
            var phrases =  await _context.Phrases.Include(x => x.Category).Include(x => x.Author).ToListAsync();
            return _mapper.Map<List<OutPhraseDTO>>(phrases);

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
        public async Task<IActionResult> PutPhrase(int id, InPhraseDTO inPhraseDTO)
        {
            var phrase = _mapper.Map<Phrase>(inPhraseDTO);
            phrase.Id = id;
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
        public async Task<ActionResult<OutPhraseDTO>> PostPhrase([FromBody] InPhraseDTO inPhraseDTO)
        {
            var phrase = _mapper.Map<Phrase>(inPhraseDTO);
            _context.Phrases.Add(phrase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhrase", new { id = phrase.Id }, _mapper.Map<OutPhraseDTO>(phrase));
        }

        // DELETE: api/Phrases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OutPhraseDTO>> DeletePhrase(int id)
        {
            var phrase = await _context.Phrases.FindAsync(id);
            if (phrase == null)
            {
                return NotFound();
            }

            _context.Phrases.Remove(phrase);
            await _context.SaveChangesAsync();

            return _mapper.Map<OutPhraseDTO>(phrase);
        }

        private bool PhraseExists(int id)
        {
            return _context.Phrases.Any(e => e.Id == id);
        }
    }
}
