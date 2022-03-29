using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
fjskfs
jk
namespace Web_Estoque_E_Faturamento.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public string Index()
        {
            return "This is my default actio.";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}