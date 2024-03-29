using Xunit;
using Moq;
using Web_Estoque_E_Faturamento;
using Web_Estoque_E_Faturamento.Controllers;
using Web_Estoque_E_Faturamento._Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Linq;
using WebEstoqueTests;
using Microsoft.Extensions.Logging;

using System;

namespace WebEstoqueTests
{
    
  
    
    
    public class ProductListReminderToBuyWithoutUseProductAlreadyRegisteredTest:Controller
    {


        static public TestDatabaseFixture Fixture = new TestDatabaseFixture();
        public string ViewResult = "ViewResult";
        public string NotFoundResult = "NotFoundResult";
        public string RedirectToActionResult = "RedirectToActionResult";

        MvcIndependentObjectsOfProductsContext context = Fixture.CreateMvcIndependentContext();

        public ProductListReminderToBuyWithoutUseProductAlreadyRegisteredController controller;

        public dynamic ProductListReminderToBuyWithoutUseProductAlreadyRegisteredInstanceController {
            get{return this.controller;}
            set{this.controller = new 
            ProductListReminderToBuyWithoutUseProductAlreadyRegisteredController(context:value,null);}
            
        }

        [Fact]
        public void TestCreateOn(){
             // Given
          
             ProductListReminderToBuyWithoutUseProductAlreadyRegistered productListReminder = new ProductListReminderToBuyWithoutUseProductAlreadyRegistered(){
                NameOfProduct="Iphone",CodeOfProduct="92",
                 DateOfCreation = "19-10-2022",
                 QuantityToBuy =0};
            
        
            ProductListReminderToBuyWithoutUseProductAlreadyRegisteredInstanceController = this.context;

            
            // When
            var Response = ProductListReminderToBuyWithoutUseProductAlreadyRegisteredInstanceController.CreateOn(productListReminder);
           
            Assert.Contains("RedirectToActionResult",Response.Result.ToString());
           
            // Then



        }
        [Fact]
        public void TestDeletePermanently()
        {
            ProductListReminderToBuyWithoutUseProductAlreadyRegistered productListReminder = new ProductListReminderToBuyWithoutUseProductAlreadyRegistered()
            {

                NameOfProduct = "Iphone",
                CodeOfProduct = "92",
                DateOfCreation="19-10-2022",
                QuantityToBuy = 0

            };
            this.context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Add(productListReminder);
            this.context.SaveChanges();
            ProductListReminderToBuyWithoutUseProductAlreadyRegisteredInstanceController = this.context;

            var Response = ProductListReminderToBuyWithoutUseProductAlreadyRegisteredInstanceController.DeletePermanently(productListReminder.Id);
            Assert.Contains("RedirectToActionResult", Response.Result.ToString());
        }

        [Fact]
        public void TestMarkAsPurchased()
        {
            ProductListReminderToBuyWithoutUseProductAlreadyRegistered productListReminder = new ProductListReminderToBuyWithoutUseProductAlreadyRegistered()
            {
                NameOfProduct = "Iphone",
                CodeOfProduct = "92",
                DateOfCreation = "19-10-2022",
                QuantityToBuy = 0
            };
            this.context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Add(productListReminder);
            this.context.SaveChanges();
            ProductListReminderToBuyWithoutUseProductAlreadyRegisteredInstanceController = this.context;

            var response = ProductListReminderToBuyWithoutUseProductAlreadyRegisteredInstanceController.MarkAsPurchased(productListReminder.Id);
            
            Assert.Contains("RedirectToActionResult", response.Result.ToString());
        }
        [Fact]
        public void TestMarkAsNotPurchased()
        {
            ProductListReminderToBuyWithoutUseProductAlreadyRegistered productListReminder = new ProductListReminderToBuyWithoutUseProductAlreadyRegistered()
            {
                
                NameOfProduct = "Iphone",
                CodeOfProduct = "92",
                DateOfCreation = "19-10-2022",
                QuantityToBuy = 0
            };
            this.context.ProductListReminderToBuyWithoutUseProductAlreadyRegistered.Add(productListReminder);
            this.context.SaveChanges();
            ProductListReminderToBuyWithoutUseProductAlreadyRegisteredInstanceController = this.context;

            var response = ProductListReminderToBuyWithoutUseProductAlreadyRegisteredInstanceController.MarkAsPurchased(productListReminder.Id);

            Assert.Contains("RedirectToActionResult", response.Result.ToString());
        }
    }
        
        
}
