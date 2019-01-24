using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteka.Models;
using Microsoft.AspNetCore.Identity;

namespace Biblioteka.Controllers
{


 

    public class UzytkowniciesController : Controller
    {
        private readonly BibliotekaContext _context;

        private readonly RoleManager<IdentityRole>
            _roleManager;
        private readonly UserManager<IdentityUser>
            _userManager;

       

        public UzytkowniciesController(BibliotekaContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Uzytkownicies
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View(await _context.Uzytkownicy.ToListAsync());
            }
            return RedirectToAction("Index", "Books");
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
            var user = GetCurrentUserAsync().GetAwaiter().GetResult();
            ViewBag.roles = _userManager.GetRolesAsync(user).GetAwaiter().GetResult();
            return View();
        }

        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


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
                //var roleName = "Verified";
                //IdentityResult roleResult;
                //var roleExist = await _roleManager.RoleExistsAsync(roleName);
                //if (!roleExist)
                //{
                //    roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                //}
                //var user = await _userManager.GetUserAsync(HttpContext.User);
                //await _userManager.AddToRoleAsync(user, roleName);
                var user = await GetCurrentUserAsync();

                var verifiedRole = await _roleManager.FindByNameAsync("Verified");
                if (verifiedRole == null)
                {
                    verifiedRole = new IdentityRole("Verified");
                    await _roleManager.CreateAsync(verifiedRole);
                }

                if (!await _userManager.IsInRoleAsync(user, verifiedRole.Name))
                {
                    await _userManager.AddToRoleAsync(user, verifiedRole.Name);
                }
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
            ViewBag.isAdmin = User.IsInRole("Admin");
            return View();
        }

        public async Task<IActionResult> Verify(int id)
        {
            if (User.IsInRole("Admin")) {
                var uzytkownicy = await _context.Uzytkownicy.FindAsync(id);
                if (uzytkownicy == null)
                {
                    return NotFound();
                }
                uzytkownicy.Verified = true;
                return await this.Edit(id, uzytkownicy);
            } else
            {
                return Unauthorized();
            }
        }


        // POST: Uzytkownicies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Imie,Nazwisko,DataUro, Verified")] Uzytkownicy uzytkownicy)
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
        public async Task<IActionResult> Reject(int id)
        {
            if (User.IsInRole("Admin"))
            {
                return await this.DeleteConfirmed(id);
            }
            else
            {
                return Unauthorized();
            }
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
