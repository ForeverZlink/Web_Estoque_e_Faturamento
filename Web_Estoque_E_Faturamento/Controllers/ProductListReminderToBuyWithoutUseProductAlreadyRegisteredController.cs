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
        
        private readonly MvcProductContext _context;
        private readonly ILogger _logger;
        
        public ProductListReminderToBuyWithoutUseProductAlreadyRegisteredController(MvcProductContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public RedirectToActionResult RedirectToActionSucess(string ActionName){
            return RedirectToAction(ActionName);
        }
       
    }
}
