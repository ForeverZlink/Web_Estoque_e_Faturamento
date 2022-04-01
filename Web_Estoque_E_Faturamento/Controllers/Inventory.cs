using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


namespace Web_Estoque_E_Faturamento.Controllers
{
    public class InventoryController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /OrderService/Welcome/ 

        public IActionResult NewProductInventory()
        {
            DateTime DateTimeNow = DateTime.Now;
            
            return View();
        }
        

    }
}