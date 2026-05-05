using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDWebApp.Data;
using CRUDWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CRUDWebApp.Controllers
{
    public class NumericalQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NumericalQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NumericalQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.NumericalQuestions.ToListAsync());
        }

        // // GET: NumericalQuestions/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        // POST: NumericalQuestions/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index", await _context.NumericalQuestions.Where( j => j.NumericalQuestion.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: NumericalQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numericalQuestions = await _context.NumericalQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (numericalQuestions == null)
            {
                return NotFound();
            }

            return View(numericalQuestions);
        }

        // GET: NumericalQuestions/Create

        [Authorize]

        public IActionResult Create()
        {
            return View();
        }

        // POST: NumericalQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumericalQuestion,NumericalAnswer,Category,Difficulty")] NumericalQuestions numericalQuestions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numericalQuestions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numericalQuestions);
        }

        // GET: NumericalQuestions/Edit/
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numericalQuestions = await _context.NumericalQuestions.FindAsync(id);
            if (numericalQuestions == null)
            {
                return NotFound();
            }
            return View(numericalQuestions);
        }

        // POST: NumericalQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumericalQuestion,NumericalAnswer,Category,Difficulty")] NumericalQuestions numericalQuestions)
        {
            if (id != numericalQuestions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numericalQuestions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumericalQuestionsExists(numericalQuestions.Id))
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
            return View(numericalQuestions);
        }

        // GET: NumericalQuestions/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numericalQuestions = await _context.NumericalQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (numericalQuestions == null)
            {
                return NotFound();
            }

            return View(numericalQuestions);
        }

        // POST: NumericalQuestions/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numericalQuestions = await _context.NumericalQuestions.FindAsync(id);
            if (numericalQuestions != null)
            {
                _context.NumericalQuestions.Remove(numericalQuestions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumericalQuestionsExists(int id)
        {
            return _context.NumericalQuestions.Any(e => e.Id == id);
        }
    }
}
