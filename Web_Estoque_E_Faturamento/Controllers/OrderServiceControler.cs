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

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}