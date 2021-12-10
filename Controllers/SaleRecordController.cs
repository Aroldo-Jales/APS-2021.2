using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class SaleRecordController : Controller
    {
        private readonly MyDbContext _context;

        public SaleRecordController(MyDbContext context)
        {
            _context = context;
        }

        // GET: SaleRecord
        public async Task<IActionResult> Index(int? sId)
        {
            if(sId != null) {
                var myDbContext = _context.SaleRecord.Where(s => s.SellerForeignKey == sId).Include(s => s.Seller);
                return View(await myDbContext.ToListAsync());
            } else {
                var myDbContext = _context.SaleRecord.Include(s => s.Seller);
                return View(await myDbContext.ToListAsync());
            }
        }
        // GET: SaleRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleRecord = await _context.SaleRecord
                .Include(s => s.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleRecord == null)
            {
                return NotFound();
            }

            return View(saleRecord);
        }

        // GET: SaleRecord/Create
        public IActionResult Create()
        {
            ViewData["SellerForeignKey"] = new SelectList(_context.Seller, "Id", "Name");
            return View();
        }

        // POST: SaleRecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SellerForeignKey,Date,Amount,Status")] SaleRecord saleRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SellerForeignKey"] = new SelectList(_context.Seller, "Id", "Name", saleRecord.SellerForeignKey);
            return View(saleRecord);
        }

        // GET: SaleRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleRecord = await _context.SaleRecord.FindAsync(id);
            if (saleRecord == null)
            {
                return NotFound();
            }
            ViewData["SellerForeignKey"] = new SelectList(_context.Seller, "Id", "Name", saleRecord.SellerForeignKey);
            return View(saleRecord);
        }

        // POST: SaleRecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SellerForeignKey,Date,Amount,Status")] SaleRecord saleRecord)
        {
            if (id != saleRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleRecordExists(saleRecord.Id))
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
            ViewData["SellerForeignKey"] = new SelectList(_context.Seller, "Id", "Name", saleRecord.SellerForeignKey);
            return View(saleRecord);
        }

        // GET: SaleRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleRecord = await _context.SaleRecord
                .Include(s => s.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleRecord == null)
            {
                return NotFound();
            }

            return View(saleRecord);
        }

        // POST: SaleRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleRecord = await _context.SaleRecord.FindAsync(id);
            _context.SaleRecord.Remove(saleRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleRecordExists(int id)
        {
            return _context.SaleRecord.Any(e => e.Id == id);
        }
    }
}
