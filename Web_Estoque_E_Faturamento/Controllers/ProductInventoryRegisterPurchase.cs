using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Estoque_E_Faturamento._Models;
using Web_Estoque_E_Faturamento.ViewModels;
using Microsoft.AspNetCore.Mvc.Controllers;

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
        
           
            IEnumerable<ProductInventoryRegisterPurchase> productInventoryRegisterPurchase =
                await this._context.ProductInventoryRegisterPurchase.Include("Product").Include("Provider").OrderByDescending(m=>m.DateOfPurchase).ToArrayAsync();
            IEnumerable < Product > products= this._context.Product.ToList();
            ICollection<Provider> providers = this._context.Provider.ToList();
            ProductContextNecessary purchaseContextNecessary = new ProductContextNecessary(providers,null,null,products, productInventoryRegisterPurchase);
            return View(purchaseContextNecessary);
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var productInventoryPurchase = await _context.ProductInventoryRegisterPurchase.Include("Product").Include("Provider")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productInventoryPurchase == null)
            {
                return NotFound();
            }




            
            ProductContextNecessary PurchaseContext = new ProductContextNecessary(null,null,null,null,null,productInventoryPurchase);


            //for show the detais of the product in a modal. In the view, its a 
            //a logic tha use this value and case true, the view will show 
            //a modal in same moment.
            ViewData["ShowModalWithDetailsOfSpecificPurchase"] = "true";
            return View( model: PurchaseContext);
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
        public async Task<IActionResult> Edit(int id, ProductInventoryRegisterPurchase ProductInventoryPurchaseNewVersion)
        {
            if(id!=ProductInventoryPurchaseNewVersion.Id){

                return NotFound();

            }
            if (ModelState.IsValid){
                
                try{
                    this._context.Update(ProductInventoryPurchaseNewVersion);
                     await this._context.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException){
                    if (!ProductExists(ProductInventoryPurchaseNewVersion.Id))
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

            return View("Index",ProductInventoryPurchaseNewVersion);

                
               

               
            
            
            
           
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