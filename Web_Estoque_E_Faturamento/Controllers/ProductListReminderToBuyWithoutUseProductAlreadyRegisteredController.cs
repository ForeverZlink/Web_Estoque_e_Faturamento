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
using Web_Estoque_E_Faturamento.ClassUtilities;
using System.IO;
namespace Web_Estoque_E_Faturamento.Controllers
{
    
    public class ProductListReminderToBuyWithoutUseProductAlreadyRegisteredController : Controller
    {
        
        private readonly MvcIndependentObjectsOfProductsContext _context;
        private readonly ILogger _logger;
        public string DateToday = DateTime.Now.Date.ToString();
        public ProductListReminderToBuyWithoutUseProductAlreadyRegisteredController(MvcIndependentObjectsOfProductsContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public RedirectToActionResult RedirectToActionSucess(string ActionName){
            return RedirectToAction(ActionName);
        }
        
        public async Task<IActionResult> Index(){
            IEnumerable<ProductListReminderToBuyWithoutUseProductAlreadyRegistered> ProductsToBuy = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Where(m => m.AlreadyBuyed == false).Where(m=>m.WillBePurchased==false).ToArray();
            IEnumerable<ProductListReminderToBuyWithoutUseProductAlreadyRegistered> ProductsWillBePurchased = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Where(m => m.WillBePurchased == true).Where(m=>m.AlreadyBuyed==false).ToArray();
            IEnumerable<ProductListReminderToBuyWithoutUseProductAlreadyRegistered> ProductsAlreadyBuyed = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Where(m => m.AlreadyBuyed == true).ToArray();

            ViewBag.ProductsToBuy = ProductsToBuy;
            ViewBag.ProductsWillBePurchased = ProductsWillBePurchased;
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
        
        public async Task<IActionResult> MarkAsWillBePurchased (int id)
        {
            var product = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Find(id);
            product.WillBePurchased = true;
            product.AlreadyBuyed = false;
            this._context.Update(product);
            await this._context.SaveChangesAsync();
            return RedirectToActionSucess(nameof(Index));
        }

        public async Task<IActionResult> MarkAsNotWillBePurchased(int id)
        {
            var product = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Find(id);
            product.WillBePurchased = false;
            product.AlreadyBuyed = false;
            this._context.Update(product);
            await this._context.SaveChangesAsync();
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
            productbuyed.WillBePurchased = false;
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
                producNotbuyed.WillBePurchased=false;
                this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Update(producNotbuyed);
                await this._context.SaveChangesAsync();
            }catch (Exception e)
            {
                return View();
            }
           
            return RedirectToActionSucess(nameof(Index));
        }


        private MemoryStream ExportExcelBaseAsStreamController(string SheetName, string[] TitlesToTable
            ,Dictionary<string, string[]> ValuesToInsertInRow)
        {

            var ExcelInstance = new ExcelHandler();
            var stream = ExcelInstance.CreateStreamSheetWithValues(
                SheetName, TitlesToTable, ValuesToInsertInRow
                );
            return stream;
        }
        [HttpGet]
        public async Task<IActionResult> ExportToExcelProductsWillBePurchased()
        {
            string SheetName = "Cotação";
            string fileName = $"Cotação-{this.DateToday}.xlsx";
            string[] TitlesToTable = new string[] { "Código", "Nome" };

            Dictionary<string, string[]> ProductsValues = new Dictionary<string, string[]>();
            var products = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Where(m => m.AlreadyBuyed == false).Where(m=>m.WillBePurchased==true);
            string[] ArrayWithProductsName = products.Select(m => m.NameOfProduct).ToArray();
            string[] ArrayWithProductsCode = products.Select(m => m.CodeOfProduct).ToArray();

            ProductsValues.Add("ProductsCode", ArrayWithProductsCode);
            ProductsValues.Add("ProductsName", ArrayWithProductsName);
            var stream = this.ExportExcelBaseAsStreamController(SheetName, TitlesToTable, ProductsValues);



            return File(stream.ToArray(), ExcelHandler.ExcelContentTypeToAspNetReturn , fileName);
        }

        [HttpGet]
        public async Task<IActionResult> ExportToExcelProductsToBuy()
        {
            string SheetName = "Produtos Para a compra";
            string fileName = $"ProdutosEmFalta-{this.DateToday}.xlsx";
            string[] TitlesToTable = new string[] { "Código", "Nome" };

            Dictionary<string, string[]> ProductsValues = new Dictionary<string, string[]>();
            var products = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Where(m => m.AlreadyBuyed == false).Where(m=>m.WillBePurchased==false);
            string[] ArrayWithProductsName = products.Select(m => m.NameOfProduct).ToArray();
            string[] ArrayWithProductsCode = products.Select(m => m.CodeOfProduct).ToArray();

            ProductsValues.Add("ProductsCode", ArrayWithProductsCode);
            ProductsValues.Add("ProductsName", ArrayWithProductsName);
            var stream = this.ExportExcelBaseAsStreamController(SheetName, TitlesToTable, ProductsValues);
            
            

            return File(stream.ToArray(), ExcelHandler.ExcelContentTypeToAspNetReturn, fileName);
        }
        [HttpGet]
        public async Task<IActionResult> ExportToExcelProductsAlreadyBuyed()
        {
            string SheetName = "Produtos já comprados";
            string fileName = $"ProdutosComprados-{this.DateToday}.xlsx";
            string[] TitlesToTable = new string[] { "Código", "Nome" };

            Dictionary<string, string[]> ProductsValues = new Dictionary<string, string[]>();
            var products = this._context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Where(m => m.AlreadyBuyed == true).Where(m=>m.WillBePurchased==false);
            string[] ArrayWithProductsName = products.Select(m => m.NameOfProduct).ToArray();
            string[] ArrayWithProductsCode = products.Select(m => m.CodeOfProduct).ToArray();

            ProductsValues.Add("ProductsCode", ArrayWithProductsCode);
            ProductsValues.Add("ProductsName", ArrayWithProductsName);
            
            var stream = this.ExportExcelBaseAsStreamController(
                SheetName, TitlesToTable, ProductsValues
                );



            return File(stream.ToArray(), ExcelHandler.ExcelContentTypeToAspNetReturn, fileName);
        }
    }
}
