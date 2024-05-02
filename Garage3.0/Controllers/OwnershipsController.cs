using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Data;
using Garage3._0.Entites;

namespace Garage3._0.Controllers
{
    public class OwnershipsController : Controller
    {
        private readonly Garage3_0Context _context;

        public OwnershipsController(Garage3_0Context context)
        {
            _context = context;
        }

        // GET: Ownerships
        public async Task<IActionResult> Index()
        {
            var garage3_0Context = _context.Ownership.Include(o => o.Member);
            return View(await garage3_0Context.ToListAsync());
        }

        // GET: Ownerships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownership = await _context.Ownership
                .Include(o => o.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownership == null)
            {
                return NotFound();
            }

            return View(ownership);
        }

        // GET: Ownerships/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Set<Member>(), "MemberId", "MemberId");
            return View();
        }

        // POST: Ownerships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,MemberId,Id,RegisterNumber,PersonNumberEntity,RegisterNumberEntity")] Ownership ownership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Set<Member>(), "MemberId", "MemberId", ownership.PersonNumber);
            return View(ownership);
        }

        // GET: Ownerships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownership = await _context.Ownership.FindAsync(id);
            if (ownership == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Set<Member>(), "MemberId", "MemberId", ownership.PersonNumber);
            return View(ownership);
        }

        // POST: Ownerships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentId,MemberId,Id,RegisterNumber,PersonNumberEntity,RegisterNumberEntity")] Ownership ownership)
        {
            if (id != ownership.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnershipExists(ownership.Id))
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
            ViewData["MemberId"] = new SelectList(_context.Set<Member>(), "MemberId", "MemberId", ownership.PersonNumber);
            return View(ownership);
        }

        // GET: Ownerships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownership = await _context.Ownership
                .Include(o => o.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownership == null)
            {
                return NotFound();
            }

            return View(ownership);
        }

        // POST: Ownerships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ownership = await _context.Ownership.FindAsync(id);
            if (ownership != null)
            {
                _context.Ownership.Remove(ownership);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnershipExists(int id)
        {
            return _context.Ownership.Any(e => e.Id == id);
        }
    }
}
