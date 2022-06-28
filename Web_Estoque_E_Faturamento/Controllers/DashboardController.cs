using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web_Estoque_E_Faturamento.Controllers
{
    
    public class DashboardController : Controller
    {
        private readonly MvcProductContext _context;

        public DashboardController(MvcProductContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

      
    }
}