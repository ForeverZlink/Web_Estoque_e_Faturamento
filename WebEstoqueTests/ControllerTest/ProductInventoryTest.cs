using Xunit;
using Moq;
using Web_Estoque_E_Faturamento.Controllers;
using Web_Estoque_E_Faturamento._Models;
using WebEstoqueTests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebEstoqueTests.ControllerTest
{
    public class ProductInventoryTest:Controller
    {
        public string ViewResult = "ViewResult";
        public string NotFoundResult = "NotFoundResult";
        public string RedirectToActionResult = "RedirectToActionResult";
        static DbContextOptions<MvcProductContext> option = new DbContextOptionsBuilder<MvcProductContext>().UseInMemoryDatabase(databaseName:"ProductContextDatabase").Options;


    public void CalculateValueTotalOfTheStockForTheProduct(){

    }
    }

}