using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eComeStoreBuilder.Data;
using eComeStoreBuilder.Models;
using Microsoft.Data.SqlClient;

namespace eComeStoreBuilder.Controllers
{
    public class StoreRequestController : Controller
    {
        private readonly eComeStoreBuilderContext _context;


        public StoreRequestController(eComeStoreBuilderContext context)
        {
            _context = context;
        }

        // GET: StoreRequestQues
        public async Task<IActionResult> Index()
        {
            return View();
        }




        // GET: StoreRequestQues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StoreRequestQue == null)
            {
                return NotFound();
            }

            var storeRequestQue = await _context.StoreRequestQue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeRequestQue == null)
            {
                return NotFound();
            }

            return View(storeRequestQue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Business,StoreTitle,Name,Email,Phone")] StoreRequestQue storeRequestQue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeRequestQue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storeRequestQue);
        }

        // GET: StoreRequestQues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StoreRequestQue == null)
            {
                return NotFound();
            }

            var storeRequestQue = await _context.StoreRequestQue.FindAsync(id);
            if (storeRequestQue == null)
            {
                return NotFound();
            }
            return View(storeRequestQue);
        }

        // POST: StoreRequestQues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Business,StoreTitle,Name,Email,Phone")] StoreRequestQue storeRequestQue)
        {
            if (id != storeRequestQue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeRequestQue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreRequestQueExists(storeRequestQue.Id))
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
            return View(storeRequestQue);
        }

        // GET: StoreRequestQues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StoreRequestQue == null)
            {
                return NotFound();
            }

            var storeRequestQue = await _context.StoreRequestQue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeRequestQue == null)
            {
                return NotFound();
            }

            return View(storeRequestQue);
        }

        // POST: StoreRequestQues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StoreRequestQue == null)
            {
                return Problem("Entity set 'eComeStoreBuilderContext.StoreRequestQue'  is null.");
            }
            var storeRequestQue = await _context.StoreRequestQue.FindAsync(id);
            if (storeRequestQue != null)
            {
                _context.StoreRequestQue.Remove(storeRequestQue);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreRequestQueExists(int id)
        {
            return (_context.StoreRequestQue?.Any(e => e.Id == id)).GetValueOrDefault();
        }




        [HttpPost]
        public async Task<JsonResult> GetDropdownData(string input)
        {
            List<WebsiteType> dropdownItems = await _context.WebsiteType
                .Where(w => w.StoreType.Contains(input))
                .ToListAsync();

            return Json(dropdownItems.Select(w => new { Value = w.Id.ToString(), Text = w.StoreType }));
        }





    }
}
