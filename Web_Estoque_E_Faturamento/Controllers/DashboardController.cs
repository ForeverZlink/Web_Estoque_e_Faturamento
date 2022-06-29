using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Estoque_E_Faturamento.ViewModels;
using Web_Estoque_E_Faturamento._Models;
using Microsoft.EntityFrameworkCore;
namespace Web_Estoque_E_Faturamento.Controllers
{
    
    public class DashboardController : Controller
    {
        private readonly MvcProductContext _context;

        public DashboardController(MvcProductContext context)
        {
            _context = context;
        }

        public async  Task<IActionResult> Index()
        {
            
            IEnumerable<Provider> provider = await this._context.Provider.ToArrayAsync();
            IEnumerable<Product> product = await this._context.Product.ToArrayAsync();
            IEnumerable<ProductInventoryRegisterPurchase> productInventoryRegisterPurchase = await this._context.ProductInventoryRegisterPurchase.ToArrayAsync();
            DashBoardContextNecessary DashboardContext = new DashBoardContextNecessary(provider,product,productInventoryRegisterPurchase);
            return View(DashboardContext);
        }

      
    }
}