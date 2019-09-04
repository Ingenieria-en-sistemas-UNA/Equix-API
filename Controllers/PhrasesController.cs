﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EquixAPI.Entities;
using EquixAPI.Models;

namespace EquixAPI.Controllers
{
    public class PhrasesController : Controller
    {
        private readonly EquixAPIContext _context;

        public PhrasesController(EquixAPIContext context)
        {
            _context = context;
        }

        // GET: Phrases
        public async Task<IActionResult> Index()
        {
            var equixAPIContext = _context.Phrase.Include(p => p.Author);
            return View(await equixAPIContext.ToListAsync());
        }

        // GET: Phrases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phrase = await _context.Phrase
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phrase == null)
            {
                return NotFound();
            }

            return View(phrase);
        }

        // GET: Phrases/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "Id");
            return View();
        }

        // POST: Phrases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,CreatedAt,AuthorId")] Phrase phrase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phrase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "Id", phrase.AuthorId);
            return View(phrase);
        }

        // GET: Phrases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phrase = await _context.Phrase.FindAsync(id);
            if (phrase == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "Id", phrase.AuthorId);
            return View(phrase);
        }

        // POST: Phrases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,CreatedAt,AuthorId")] Phrase phrase)
        {
            if (id != phrase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phrase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhraseExists(phrase.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Set<Author>(), "Id", "Id", phrase.AuthorId);
            return View(phrase);
        }

        // GET: Phrases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phrase = await _context.Phrase
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phrase == null)
            {
                return NotFound();
            }

            return View(phrase);
        }

        // POST: Phrases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phrase = await _context.Phrase.FindAsync(id);
            _context.Phrase.Remove(phrase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhraseExists(int id)
        {
            return _context.Phrase.Any(e => e.Id == id);
        }
    }
}
