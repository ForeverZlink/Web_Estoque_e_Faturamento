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
    
    public class ProductListReminderToBuyWithoutUseProductAlreadyRegisteredController : Controller
    {
        
        private readonly MvcIndependentObjectsOfProductsContext _context;
        private readonly ILogger _logger;
        
        public ProductListReminderToBuyWithoutUseProductAlreadyRegisteredController(MvcIndependentObjectsOfProductsContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public RedirectToActionResult RedirectToActionSucess(string ActionName){
            return RedirectToAction(ActionName);
        }
        
        public async Task<IActionResult> Index(){
            IEnumerable<ProductListReminderToBuyWithoutUseProductAlreadyRegistered> ProductsToBuy = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Where(m => m.AlreadyBuyed == false).ToArray();
            IEnumerable<ProductListReminderToBuyWithoutUseProductAlreadyRegistered> ProductsAlreadyBuyed = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Where(m => m.AlreadyBuyed ==true).ToArray();
            ViewBag.ProductsToBuy = ProductsToBuy;
            ViewBag.ProductsAlreadyBuyed = ProductsAlreadyBuyed;
            
            return View("Index", this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.ToArray());
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreateOn( ProductListReminderToBuyWithoutUseProductAlreadyRegistered  ProductListReminder){
            if (ModelState.IsValid)
            {

                this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Add(ProductListReminder);
                await this._context.SaveChangesAsync();
                return RedirectToActionSucess(nameof(Index));
            }
            return View("Index", this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.ToArray());
            
            

        }

        public async Task<IActionResult> DeletePermanently(int id)
        {
            var ProductToDelete = await _context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.FindAsync(id);
            this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Remove(ProductToDelete);
            
            await _context.SaveChangesAsync();
            return RedirectToActionSucess(nameof(Index));
        }
        

        public async Task<IActionResult> MarkAsPurchased (int? id)
        {
            if (id == null)
            {
                return View();
            }
            var productbuyed = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.FirstOrDefault(m => m.Id == id);
            productbuyed.AlreadyBuyed = true;
            this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Update(productbuyed);
            await this._context.SaveChangesAsync();
            return RedirectToActionSucess(nameof(Index));
        }
        public async Task<IActionResult> MarkAsNotPurchased(int? id)
        {
            if (id == null)
            {
                return View();
            }
            try
            {
                var producNotbuyed = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.FirstOrDefault(m => m.Id == id);
                producNotbuyed.AlreadyBuyed = false;
                this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Update(producNotbuyed);
                await this._context.SaveChangesAsync();
            }catch (Exception e)
            {
                return View();
            }
           
            return RedirectToActionSucess(nameof(Index));
        }

    }
}
