using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GL3Frameworks.Data;

namespace GL3Frameworks.Models
{
    public class MembershiptypesController : Controller
    {
        private readonly GL3FrameworksContext _context;

        public MembershiptypesController(GL3FrameworksContext context)
        {
            _context = context;
        }

        // GET: Membershiptypes
        public async Task<IActionResult> Index()
        {
              return _context.Membershiptype != null ? 
                          View(await _context.Membershiptype.ToListAsync()) :
                          Problem("Entity set 'GL3FrameworksContext.Membershiptype'  is null.");
        }

        // GET: Membershiptypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Membershiptype == null)
            {
                return NotFound();
            }

            var membershiptype = await _context.Membershiptype
                .FirstOrDefaultAsync(m => m.ID == id);
            if (membershiptype == null)
            {
                return NotFound();
            }

            return View(membershiptype);
        }

        // GET: Membershiptypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membershiptypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,signUpFee,DurationInMonth,DiscountRate")] Membershiptype membershiptype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membershiptype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membershiptype);
        }

        // GET: Membershiptypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Membershiptype == null)
            {
                return NotFound();
            }

            var membershiptype = await _context.Membershiptype.FindAsync(id);
            if (membershiptype == null)
            {
                return NotFound();
            }
            return View(membershiptype);
        }

        // POST: Membershiptypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,signUpFee,DurationInMonth,DiscountRate")] Membershiptype membershiptype)
        {
            if (id != membershiptype.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membershiptype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershiptypeExists(membershiptype.ID))
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
            return View(membershiptype);
        }

        // GET: Membershiptypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Membershiptype == null)
            {
                return NotFound();
            }

            var membershiptype = await _context.Membershiptype
                .FirstOrDefaultAsync(m => m.ID == id);
            if (membershiptype == null)
            {
                return NotFound();
            }

            return View(membershiptype);
        }

        // POST: Membershiptypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Membershiptype == null)
            {
                return Problem("Entity set 'GL3FrameworksContext.Membershiptype'  is null.");
            }
            var membershiptype = await _context.Membershiptype.FindAsync(id);
            if (membershiptype != null)
            {
                _context.Membershiptype.Remove(membershiptype);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershiptypeExists(int id)
        {
          return (_context.Membershiptype?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
