using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Estoque_E_Faturamento._Models;
using Microsoft.Extensions.Logging;

namespace Web_Estoque_E_Faturamento.Controllers
{
    
    public class ProviderController : Controller
    {
        private readonly MvcProductContext _context;

        public ProviderController(MvcProductContext context)
        {
            _context = context;
        }

        public RedirectToActionResult RedirectToActionSucess(string ActionName){
            return RedirectToAction(ActionName);
        }
        // GET: ProductInventoryRegister
        public async Task<IActionResult> Index()
        {
        
            return View(await _context.Provider.ToArrayAsync());
        }

        // GET: ProductInventoryRegister/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Provider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductInventoryRegister/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: ProductInventoryRegister/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Create")]
        public async Task<IActionResult> CreateOn([Bind("Id,Name,Cnpj,Andress")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provider);
                await _context.SaveChangesAsync();
                
                return RedirectToActionSucess(nameof(Index));

            }
            else
            {
                Console.WriteLine("NO is valid");
            }
            return View(provider);
        }

        // GET: ProductInventoryRegister/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.ProductInventoryRegisterPurchase.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductInventoryRegister/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Code")] ProductInventoryRegisterPurchase ProductInventory)
        {
            if (id != ProductInventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ProductInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(ProductInventory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToActionSucess(nameof(Index));
            }
            return View(ProductInventory);
        }

        // GET: ProductInventoryRegister/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.ProductInventoryRegisterPurchase.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductInventoryRegister/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.ProductInventoryRegisterPurchase.FindAsync(id);
            _context.ProductInventoryRegisterPurchase.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToActionSucess(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.ProductInventoryRegisterPurchase.Any(e => e.Id == id);
        }
        
    }
}