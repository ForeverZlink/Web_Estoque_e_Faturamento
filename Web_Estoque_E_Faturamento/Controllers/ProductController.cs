#nullable disable
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
    
    public class ProductController : Controller
    {
        
        private readonly MvcProductContext _context;
        private readonly ILogger _logger;
        
        public ProductController(MvcProductContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public RedirectToActionResult RedirectToActionSucess(string ActionName){
            return RedirectToAction(ActionName);
        }
        // GET: Product
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> product = await this._context.Product.ToArrayAsync();
            IEnumerable<ProductInventoryRegisterPurchase> productInventoryRegisterPurchase = await this._context.ProductInventoryRegisterPurchase.ToArrayAsync();
            ProductContextNecessary ProductContext = new  ProductContextNecessary(null,null,null,product,productInventoryRegisterPurchase);
            return View(ProductContext);
            
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            
            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var productInventory = this._context.ProductInventory.FirstOrDefault(m=>m.ProductId==product.Id);
            this._context.ProductInventory.Include(m=>m.ProductInventoryRegisterPurchase).ToList();
            
            this._context.ProductInventoryRegisterPurchase.Include("Provider").ToList().OrderBy(m=>m.DateOfPurchase);
            
            
           
            IEnumerable<Product> productenu = await this._context.Product.ToArrayAsync();    
            ProductContextNecessary productContext  = new ProductContextNecessary(null,product,null,productenu,null);
            

            //for show the detais of the product in a modal. In the view, its a 
            //a logic tha use this value and case true, the view will show 
            //a modal in same moment.
            ViewData["ShowModalWithDetailsOfProduct"] = "true";
            return View(viewName:"Index", model:productContext);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Create")]
        public async Task<IActionResult> CreateOn([Bind("Id,Name,Description,Code")] Product product)
        {
            
           

           
            product.DateOfCreation=DateTime.Today.ToString();

            if (ModelState.IsValid)
            {
                
               
                _context.Add(product);
                await _context.SaveChangesAsync();
               
                ProductInventory productInventory = new ProductInventory(){ProductId=product.Id,QuantityInStock=0};
                

                this._context.Add(productInventory);
                this._context.SaveChanges();
                
                

                product.ProductInventory = productInventory;
                

                this._context.Update(product);
                this._context.SaveChanges();

                
                
                return RedirectToActionSucess(nameof(Index));

            }
            else
            {
                Console.WriteLine("NO is valid");
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Code")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToActionSucess(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
        
    }
}
