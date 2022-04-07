using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


namespace Web_Estoque_E_Faturamento.Controllers
{
    public class InventoryController : Controller
    {
        
        public IActionResult Index()
        {
            ViewData["Message"]= Environment.GetEnvironmentVariable("Anime");
            return View();
        }

        // 
        // GET: /OrderService/Welcome/ 

        

    }
}