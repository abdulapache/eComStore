using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eComeStoreBuilder.Data;
using eComeStoreBuilder.Models;

namespace eComeStoreBuilder.Controllers
{
    public class StoreRequestQuesController : Controller
    {
        private readonly eComeStoreBuilderContext _context;

        public StoreRequestQuesController(eComeStoreBuilderContext context)
        {
            _context = context;
        }

        // GET: StoreRequestQues
        public async Task<IActionResult> Index()
        {
              return _context.StoreRequestQue != null ? 
                          View(await _context.StoreRequestQue.ToListAsync()) :
                          Problem("Entity set 'eComeStoreBuilderContext.StoreRequestQue'  is null.");
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

        // GET: StoreRequestQues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoreRequestQues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
    }
}
