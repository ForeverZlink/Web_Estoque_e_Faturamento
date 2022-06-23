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
        public ProductController _ProductController;
        public dynamic ContextConfig{
            get{return context;}
            set{
                this.context.Product.Add(value);
                context.SaveChanges();
            }
        } 
        public dynamic ProductControllerInstance{
            get{ return this._ProductController;}
            set{this._ProductController = new ProductController(value);}
        }

        [Fact]
        public void Edit()
        {
            //This part will be test Edit method when acess via get, thus
            //its just search in database for the informations

            ContextConfig =ProductModelData;
            ProductControllerInstance = ContextConfig;
            //When its passed a id null
            var ResponseWantedIdIsNull = ProductControllerInstance.Edit(id:null);
            Assert.Contains(this.NotFoundResult, ResponseWantedIdIsNull.Result.ToString());
            
            //When its passed id that not null, but doesn't exists in database
            var ResponseWantedIdNotIsNullButDoesntExists= ProductControllerInstance.Edit(id:null);
            Assert.Contains(this.NotFoundResult, ResponseWantedIdNotIsNullButDoesntExists.Result.ToString());
            
            // When its passed a product id that already exists
            var ResponseWantedExists= ProductControllerInstance.Edit(id:ProductModelData.Id);
            Assert.Contains(this.ViewResult, ResponseWantedExists.Result.ToString());
            
            //end of part of test via get

            //This part will be test Edit method when acess via post 
            

        }
        [Fact]
        public void Details()
        {
            // Case when its a Product  te jwenn
             ContextConfig=ProductModelData;
             ProductControllerInstance = ContextConfig;

             var ResponseWanted  = ProductControllerInstance.Details(id:1);
           
             

             Assert.Contains(this.ViewResult, ResponseWanted.Result.ToString());

             //Case when doesn't have a product with this id
             var ResponseWantedIdNotExists = ProductControllerInstance.Details(id:9999);
             Assert.Contains(this.NotFoundResult,ResponseWantedIdNotExists.Result.ToString());


             //Case when the id its null 
             var ResponseWantedIdIsNull = ProductControllerInstance.Details(id:null);
             Assert.Contains(this.NotFoundResult,ResponseWantedIdNotExists.Result.ToString());

             this.ContextConfig.Dispose();
           
        }
        [Fact]
        public async void Delete()
        {
            Product ProductModelData = new Product(){
            Id=2,Name="Car",Code="01",Description="A nice car"
           };
           ContextConfig=ProductModelData;
           ProductControllerInstance = ContextConfig;
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
           ProductControllerInstance = ContextConfig;
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