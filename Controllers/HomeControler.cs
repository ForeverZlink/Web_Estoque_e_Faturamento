using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Web_Estoque_E_Faturamento.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /Home/

        public string index()
        {
            return "hello";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}