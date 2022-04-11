using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


namespace Web_Estoque_E_Faturamento.ControllersProduct
{
    public class ProductController : Controller
    {
        
        public  IActionResult Index()
        {
            ViewData["Message"]= Environment.GetEnvironmentVariable("Anime");
            return View();
        }

        // 
        // GET: /OrderService/Welcome/ 
        public IActionResult NewProduct(){
            return View();
        }

        

    }
}