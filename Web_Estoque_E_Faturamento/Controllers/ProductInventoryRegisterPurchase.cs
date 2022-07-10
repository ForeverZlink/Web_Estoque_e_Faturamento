using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Estoque_E_Faturamento._Models;
using Microsoft.Extensions.Logging;
using Web_Estoque_E_Faturamento.ViewModels;

namespace Web_Estoque_E_Faturamento.Controllers
{
    
    public class ProductInventoryRegisterPurchaseController : Controller
    {
        private readonly MvcProductContext _context;
        private readonly ILogger _logger;

        public ProductInventoryRegisterPurchaseController(MvcProductContext context, ILogger<ProductInventoryRegisterPurchaseController> logger)
        {
            _context = context;
            _logger  = logger;
        }

        public RedirectToActionResult RedirectToActionSucess(string ActionName){
            return RedirectToAction(ActionName);
        }
        // GET: ProductInventoryRegister
        public async Task<IActionResult> Index()
        {
        
            IEnumerable<Provider> provider = await this._context.Provider.ToArrayAsync();
            IEnumerable<Product> product = await this._context.Product.ToArrayAsync();
            IEnumerable<ProductInventoryRegisterPurchase> productInventoryRegisterPurchase = await this._context.ProductInventoryRegisterPurchase.OrderByDescending(m=>m.DateOfPurchase).ToArrayAsync();
            DashBoardContextNecessary DashboardContext = new DashBoardContextNecessary(provider,product,productInventoryRegisterPurchase);
            return View(DashboardContext);
        }

        // GET: ProductInventoryRegister/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.ProductInventoryRegisterPurchase
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
        public async Task<IActionResult> CreateOn(
            [Bind("Id,ProviderId, ProductId, DateOfPurchase, PriceOfPurchase,QuantityBuyed,  PriceProductUnity")] ProductInventoryRegisterPurchase productInventoryRegisterPurchase)
        {
             productInventoryRegisterPurchase.Product = await this._context.Product.FindAsync(productInventoryRegisterPurchase.ProductId);
             productInventoryRegisterPurchase.Provider = await this._context.Provider.FindAsync(productInventoryRegisterPurchase.ProviderId);
            
            if (ModelState.IsValid)
            {
                
                _context.ProductInventoryRegisterPurchase.Add(productInventoryRegisterPurchase);
                await this._context.SaveChangesAsync();
                this._logger.LogInformation(productInventoryRegisterPurchase.Id.ToString());
                
                
                var productInventoryRegisterPurchaseSave = this._context.ProductInventoryRegisterPurchase.Find(productInventoryRegisterPurchase.Id);
               
                var productInventory = this._context.ProductInventory.FirstOrDefault(m=>m.ProductId==productInventoryRegisterPurchaseSave.ProductId);
                this._context.ProductInventory.Include(u=>u.ProductInventoryRegisterPurchase).ToList();
                productInventory.AddPurchaseInProductInventory(productInventoryRegisterPurchaseSave);
                this._context.Update(productInventory);
                this._context.SaveChanges();

                
                return RedirectToActionSucess(nameof(Index));

            }
            else
            {
                Console.WriteLine("NO is valid");
            }
            
            return View(productInventoryRegisterPurchase);
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