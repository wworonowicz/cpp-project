using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteka.Models;

namespace Biblioteka.Controllers
{


 

    public class UzytkowniciesController : Controller
    {
        private readonly BibliotekaContext _context;

        public UzytkowniciesController(BibliotekaContext context)
        {
            _context = context;
        }

        // GET: Uzytkownicies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uzytkownicy.ToListAsync());
        }

        // GET: Uzytkownicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownicy = await _context.Uzytkownicy
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }

            return View(uzytkownicy);
        }

        // GET: Uzytkownicies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uzytkownicies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Imie,Nazwisko,DataUro")] Uzytkownicy uzytkownicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uzytkownicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uzytkownicy);
        }

        // GET: Uzytkownicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownicy = await _context.Uzytkownicy.FindAsync(id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }
            return View(uzytkownicy);
        }

        // POST: Uzytkownicies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Imie,Nazwisko,DataUro")] Uzytkownicy uzytkownicy)
        {
            if (id != uzytkownicy.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzytkownicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzytkownicyExists(uzytkownicy.ID))
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
            return View(uzytkownicy);
        }

        // GET: Uzytkownicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownicy = await _context.Uzytkownicy
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uzytkownicy == null)
            {
                return NotFound();
            }

            return View(uzytkownicy);
        }

        // POST: Uzytkownicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uzytkownicy = await _context.Uzytkownicy.FindAsync(id);
            _context.Uzytkownicy.Remove(uzytkownicy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UzytkownicyExists(int id)
        {
            return _context.Uzytkownicy.Any(e => e.ID == id);
        }
    }
}
