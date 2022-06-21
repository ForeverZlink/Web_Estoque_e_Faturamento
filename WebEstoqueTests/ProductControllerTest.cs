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
        static DbContextOptions<MvcProductContext> option = new DbContextOptionsBuilder<MvcProductContext>().UseInMemoryDatabase(databaseName:"ProductContextDatabase").Options;
        MvcProductContext context = new MvcProductContext(option);
        Product ProductModelData = new Product(){
            Id=1,Name="Car",Code="01",Description="A nice car"
           };
        [Fact]
        public async void Delete()
        {
           
           context.Product.Add(ProductModelData);
           context.SaveChanges();
           ProductController ProductControllerInstance = new ProductController(context);
           var ResponseWanted  = ProductControllerInstance.DeleteConfirmed(id:1);
           context.Dispose();
           Assert.Contains("RedirectToActionResult",ResponseWanted.Result.ToString());

        }
        [Fact]
        public async void CreateOn(){
            Product ProductModelData = new Product(){
            Id=2,Name="Car2",Code="02",Description="A nice car"
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