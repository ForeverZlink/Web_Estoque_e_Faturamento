using Xunit;
using Moq;
using Web_Estoque_E_Faturamento.Controllers;
using Web_Estoque_E_Faturamento._Models;
using WebEstoqueTests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Linq;

using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;

namespace WebEstoqueTests
{
    
    public interface IProductRepository{
        public void Edit();

        public Product Details(int id);
    }
    
    
    
    public class ProductControllerTest:IClassFixture<TestDatabaseFixture>
    {
       
       
       static public TestDatabaseFixture? Fixture;
        public string ViewResult = "ViewResult";
        public string NotFoundResult = "NotFoundResult";
        public string RedirectToActionResult = "RedirectToActionResult";
        
        
        MvcProductContext context = Fixture.CreateContext();
       
        
        
        Product ProductModelData = new Product(){
            Name="Car",Code="01",Description="A nice car"
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
            set{this._ProductController = new ProductController(context:value,logger:null);}
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
            
            //When id its different of product.Id
            var ResponseIdIsDifferentOfProductId =ProductControllerInstance.Edit(id:999999, product:ProductModelData);
            Assert.Contains(this.NotFoundResult, ResponseIdIsDifferentOfProductId.Result.ToString());

            //When id its equal, exist the product in database and the  changes were made.
            var ResponseIdEqualAndExistAProductWithId =ProductControllerInstance.Edit(id:ProductModelData.Id, product:ProductModelData);
            Assert.Contains(this.RedirectToActionResult, ResponseIdEqualAndExistAProductWithId.Result.ToString());

            //when id passed its equal a product.Id, but doesn't exist a product with this id in database
            Product ProductModelDataButWithoutSaveInDatabase = new Product(){
            Id=222222222,Name="Car",Code="01",Description="A nice car"
            };
            var ResponseIdEqualButNotExistAProductWithId =ProductControllerInstance.Edit(id:ProductModelDataButWithoutSaveInDatabase.Id, product:ProductModelDataButWithoutSaveInDatabase);
            Assert.Contains(this.NotFoundResult, ResponseIdEqualButNotExistAProductWithId.Result.ToString());
            this.ContextConfig.Dispose();

        }
        [Fact]
        public void Details()
        {
            var productData =  new Product{Id=44,Name="Car",Code="01",Description="A nice car"};
             

            ProductInventory ProductInventory = new ProductInventory(){
                ProductId=productData.Id,Product=productData,
                QuantityInStock=0,ProductInventoryRegisterPurchase= new List<ProductInventoryRegisterPurchase>()};

           

            ProductInventoryRegisterPurchase ProductInvetoryRegisterPurchaseModelData = new ProductInventoryRegisterPurchase(){
            QuantityBuyed=1,PriceOfPurchase=20,DateOfPurchase=DateTime.Today.ToString(),
            PriceProductUnity=2,ProductId=productData.Id,
            Product=productData
                };
            ProductInventory.ProductInventoryRegisterPurchase.Add(ProductInvetoryRegisterPurchaseModelData);
            
            var data = new List<Product>{
                productData
               
            }.AsQueryable();

            var dataProductInventoryPurchase = new List<ProductInventoryRegisterPurchase>{
                ProductInvetoryRegisterPurchaseModelData
            }.AsQueryable();
            
                
            var dataProductInventory = new List<ProductInventory>{
                ProductInventory
            }.AsQueryable();

            
            
            var mockset = new Mock<DbSet<Product>>();
            mockset.As<IQueryable<Product>>().Setup(m=>m.Provider);
            mockset.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockset.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mocksetInventory = new Mock<DbSet<ProductInventory>>();
            mockset.As<IQueryable<ProductInventory>>().Setup(m=>m.Provider);
            mockset.As<IQueryable<ProductInventory>>().Setup(m => m.Expression).Returns(dataProductInventory.Expression);
            mockset.As<IQueryable<ProductInventory>>().Setup(m => m.ElementType).Returns(dataProductInventory.ElementType);
            mockset.As<IQueryable<ProductInventory>>().Setup(m => m.GetEnumerator()).Returns(dataProductInventory.GetEnumerator());

            var mocksetPurchases = new Mock<DbSet<ProductInventoryRegisterPurchase>>();
            mockset.As<IQueryable<ProductInventoryRegisterPurchase>>().Setup(m=>m.Provider);
            mockset.As<IQueryable<ProductInventoryRegisterPurchase>>().Setup(m => m.Expression).Returns(dataProductInventoryPurchase.Expression);
            mockset.As<IQueryable<ProductInventoryRegisterPurchase>>().Setup(m => m.ElementType).Returns(dataProductInventoryPurchase.ElementType);
            mockset.As<IQueryable<ProductInventoryRegisterPurchase>>().Setup(m => m.GetEnumerator()).Returns(dataProductInventoryPurchase.GetEnumerator());

            var mockContext  = new Mock<MvcProductContext>();
            mockContext.Setup(x=>x.Product).Returns(mockset.Object);
            mockContext.Setup(x=>x.ProductInventory).Returns(mocksetInventory.Object);
            mockContext.Setup(x=>x.ProductInventoryRegisterPurchase).Returns(mocksetPurchases.Object);
            

           
            
            var logger = LoggerFactory.Create(config=>{config.AddConsole();}).CreateLogger("Program");

         
            
            
            ProductControllerInstance = mockContext.Object;
           

            // Case when its a Product  te jwenn
            

             

             var ResponseWanted  = ProductControllerInstance.Details(id:productData.Id);
           
             logger.LogInformation($"Hello {ResponseWanted.Result.ToString()}");

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
            MvcProductContext context = Fixture.CreateContext();
            this.ProductControllerInstance=context;
            Product ProductModelData = new Product(){Id=3222,
            Name="Car",Code="01",Description="A nice car"
           };
           ContextConfig=ProductModelData;
           ProductControllerInstance = ContextConfig;
           var ResponseWanted  = ProductControllerInstance.DeleteConfirmed(id:this.ProductModelData.Id);
           context.Dispose();
           Console.WriteLine(ResponseWanted.Result.ToString());
           Assert.Contains("RedirectToActionResult",ResponseWanted.Result.ToString());

        }
        [Fact]
        public async void CreateOn(){
            MvcProductContext context = Fixture.CreateContext();
            this.ProductControllerInstance=context;
            Product ProductModelData = new Product(){
            Name="Car2",Code="02",Description="A nice car"
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
           context.Dispose();
           

        }
        
    }
}