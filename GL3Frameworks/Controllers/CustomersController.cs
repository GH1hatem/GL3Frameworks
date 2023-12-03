using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GL3Frameworks.Data;
using GL3Frameworks.Models;

namespace GL3Frameworks.Controllers
{    public class CustomersController : Controller
    {
        private readonly GL3FrameworksContext _context;
       public CustomersController(GL3FrameworksContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            if (_context == null)
            {
                return View("Error");
            }
            var customersWithMembership = await _context.Customer
                .Include(c => c.Membershiptype)
                .ToListAsync();

            return View(customersWithMembership);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        // creating a customer with membership type
        public IActionResult Create()
        {
            // okay here we are going to create a dropdown list of membership types in view level 
            // using viewbag
            // first we got the list of membership types from the database
            var members = _context.Membershiptype.ToList();
            // then we create a viewbag and assign the list of membership types to the viewbag
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.Name,
                Value = members.ID.ToString()
            });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer c)
        { // here we are checking if the model is valid or not
            if (!ModelState.IsValid)
            {  // the same thing we did in the get method
                var members = _context.Membershiptype.ToList();
                ViewBag.member = members.Select(members => new SelectListItem()
                {
                    Text = members.Name ,

                    Value = members.ID.ToString()

                });
                return View();
            }
            // if the model is valid then we add the customer to the database
            _context.Add(c);
            // then we save the changes
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       

        public async Task<IActionResult> CreateWithMembershipType([Bind("Id,Name,Address,City,MembershipTypeId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var membershipTypes = await _context.Membershiptype.ToListAsync();
            ViewData["MembershipTypes"] = new SelectList(membershipTypes, "Id", "Name");
            return View(customer);
        }   


        public async Task<IActionResult> CreateWithMembershipType()
        {
            var membershipTypes = await _context.Membershiptype.ToListAsync();
            ViewData["MembershipTypes"] = new SelectList(membershipTypes, "Id", "Name");
            return View();
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,City")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'GL3FrameworksContext.Customer'  is null.");
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer != null)
            {
                _context.Customer.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return (_context.Customer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
