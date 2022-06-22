using Xunit;
using Moq;
using Web_Estoque_E_Faturamento.Controllers;
using Web_Estoque_E_Faturamento._Models;
using WebEstoqueTests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;

namespace WebEstoqueTests
{
    public class ProductControllerTest:Controller
    {
        public string ViewResult = "ViewResult";
        public string NotFoundResult = "NotFoundResult";
        public string RedirectToActionResult = "RedirectToActionResult";
        static DbContextOptions<MvcProductContext> option = new DbContextOptionsBuilder<MvcProductContext>().UseInMemoryDatabase(databaseName:"ProductContextDatabase").Options;
        MvcProductContext context = new MvcProductContext(option);
        Product ProductModelData = new Product(){
            Id=1,Name="Car",Code="01",Description="A nice car"
           };

        [Fact]
        public void Details()
        {
            // Case when its a Product  te jwenn
             context.Product.Add(this.ProductModelData);
             context.SaveChanges();
             ProductController ProductControllerInstance = new ProductController(context);
             var ResponseWanted  = ProductControllerInstance.Details(id:1);
           
             

             Assert.Contains(this.ViewResult, ResponseWanted.Result.ToString());

             //Case when doesn't have a product with this id
             var ResponseWantedIdNotExists = ProductControllerInstance.Details(id:9999);
             Assert.Contains(this.NotFoundResult,ResponseWantedIdNotExists.Result.ToString());


             //Case when the id its null 
             var ResponseWantedIdIsNull = ProductControllerInstance.Details(id:null);
             Assert.Contains(this.NotFoundResult,ResponseWantedIdNotExists.Result.ToString());

             context.Dispose();
           
        }
        [Fact]
        public async void Delete()
        {
            Product ProductModelData = new Product(){
            Id=2,Name="Car",Code="01",Description="A nice car"
           };
           context.Product.Add(ProductModelData);
           context.SaveChanges();
           ProductController ProductControllerInstance = new ProductController(context);
           var ResponseWanted  = ProductControllerInstance.DeleteConfirmed(id:1);
           context.Dispose();
           Console.WriteLine(ResponseWanted.Result.ToString());
           Assert.Contains("RedirectToActionResult",ResponseWanted.Result.ToString());

        }
        [Fact]
        public async void CreateOn(){
            Product ProductModelData = new Product(){
            Id=3,Name="Car2",Code="02",Description="A nice car"
           };
           //True Case
           context.SaveChanges();
           ProductController ProductControllerInstance = new ProductController(context);
           var Response = ProductControllerInstance.CreateOn(ProductModelData);
           
           Assert.Contains("RedirectToActionResult",Response.Result.ToString());

           //Fall and erro expected because this part will attempt create with a values 
           //thas already exists in database 
           try{
            var ResultFail = ProductControllerInstance.CreateOn(ProductModelData);
           }catch(Exception e ){
             
           }
           

        }
        
    }
}