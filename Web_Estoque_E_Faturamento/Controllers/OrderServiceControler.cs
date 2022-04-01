using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


namespace Web_Estoque_E_Faturamento.Controllers
{
    public class OrderServiceController : Controller
    {
        
        public string index()
        {
            return "hello";
        }

        // 
        // GET: /OrderService/Welcome/ 

        public string NewOrderOfService()
        {
            DateTime DateTimeNow = DateTime.Now;
            
            return $"Hoje é dia  {DateTimeNow}";
        }

    }
}