using Xunit;
using Moq;
using Web_Estoque_E_Faturamento.Controllers;
using Web_Estoque_E_Faturamento._Models;
using WebEstoqueTests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEstoqueTests;
using System;

namespace WebEstoqueTests
{
    public class ProductInventoryRegisterPurchaseControlleTest:Controller
    {
        public string ViewResult = "ViewResult";
        public string NotFoundResult = "NotFoundResult";
        public string RedirectToActionResult = "RedirectToActionResult";


        static public TestDatabaseFixture Fixture = new TestDatabaseFixture();
         MvcProductContext context = Fixture.CreateContext();
        static Provider ProviderInstance = new Provider(){
            Name="Volkswagem",Andress="Rua das limitã",Cnpj="134"
        };
        static Product Product = new Product(){
            Name="Car",Code="01",Description="A nice car"
           };
        static ProductInventory ProductInventory = new ProductInventory(){ProductId=Product.Id,QuantityInStock=0};

        ProductInventoryRegisterPurchase ProductInvetoryRegisterPurchaseModelData = new ProductInventoryRegisterPurchase(){
            QuantityBuyed=1,PriceOfPurchase=20,DateOfPurchase=DateTime.Today.ToString(),
            PriceProductUnity=2, ProviderId=ProviderInstance.Id,ProductInventoryId=ProductInventory.Id,
            ProductId=Product.Id,DanfeNumber=1,Serie=1
        };
        public ProductInventoryRegisterPurchaseController _ProductInventoryRegisterPurchaseController;
        public dynamic ContextConfig{
            get{return context;}
            set{
                this.context.ProductInventoryRegisterPurchase.Add(value);
                context.SaveChanges();
            }
        } 
        public dynamic ProductInventoryRegisterPurchaseControllerInstance{
            get{ return this._ProductInventoryRegisterPurchaseController;}
            set{this._ProductInventoryRegisterPurchaseController = new ProductInventoryRegisterPurchaseController(context:value, logger:null );}
        }

        [Fact]
        public void Edit()
        {
            this.context.Provider.Add(ProviderInstance);
            this.context.Product.Add(Product);
            this.context.SaveChanges();
            
            
            ProductInventory ProductInventory = new ProductInventory() { ProductId = Product.Id, QuantityInStock = 0 };
            this.context.ProductInventory.Add(ProductInventory);
            this.context.SaveChanges();

            ProductInventoryRegisterPurchase ProductInvetoryRegisterPurchaseModelData = new ProductInventoryRegisterPurchase()
            {
                QuantityBuyed = 1,
                PriceOfPurchase = 20,
                DateOfPurchase = DateTime.Today.ToString(),
                PriceProductUnity = 2,
                ProviderId = ProviderInstance.Id,
                ProductInventoryId = ProductInventory.Id,
                ProductId = Product.Id,
                DanfeNumber = 1,
                Serie = 1
            };
            //This part will be test Edit method when acess via get, thus
            //its just search in database for the informations

            ContextConfig = ProductInvetoryRegisterPurchaseModelData;
            ProductInventoryRegisterPurchaseControllerInstance = ContextConfig;
            //When its passed a id null
           
            //When its passed id that not null, but doesn't exists in database
            var ResponseWantedIdNotIsNullButDoesntExists= ProductInventoryRegisterPurchaseControllerInstance.Edit(id:4343343);
               
            Assert.Contains(this.NotFoundResult, ResponseWantedIdNotIsNullButDoesntExists.Result.ToString());
            
            // When its passed a product id that already exists
            var ResponseWantedExists= ProductInventoryRegisterPurchaseControllerInstance.Edit(id:ProductInvetoryRegisterPurchaseModelData.Id);
            Assert.Contains(this.ViewResult, ResponseWantedExists.Result.ToString());
            
            //end of part of test via get

            //This part will be test Edit method when acess via post 
            
            //When id its different of product.Id
            var ResponseIdIsDifferentOfProductId =ProductInventoryRegisterPurchaseControllerInstance.Edit(id:999999, ProductInventoryPurchaseNewVersion:ProductInvetoryRegisterPurchaseModelData);
            Assert.Contains(this.NotFoundResult, ResponseIdIsDifferentOfProductId.Result.ToString());

            //When id its equal, exist the product in database and the  changes were made.
            //change just a value of product for the comparision
            ProductInvetoryRegisterPurchaseModelData.QuantityBuyed=33;
            var ResponseIdEqualAndExistAProductWithId =ProductInventoryRegisterPurchaseControllerInstance.Edit(id:ProductInvetoryRegisterPurchaseModelData.Id, ProductInventoryPurchaseNewVersion:ProductInvetoryRegisterPurchaseModelData);

            Assert.Contains(this.RedirectToActionResult, ResponseIdEqualAndExistAProductWithId.Result.ToString());

            //when id passed its equal a product.Id, but doesn't exist a product with this id in database
            
            ProductInventoryRegisterPurchase ProductInvetoryRegisterPurchaseModelDataButWithoutSaveInDatabase = new ProductInventoryRegisterPurchase(){
                Id=9999,
            QuantityBuyed=1,PriceOfPurchase=20,DateOfPurchase=DateTime.Today.ToString(),
            PriceProductUnity=2, ProviderId=1,Provider=ProviderInstance, ProductInventoryId=1,
            ProductId=1,Product=Product};
            var ResponseIdEqualButNotExistAProductWithId =ProductInventoryRegisterPurchaseControllerInstance.Edit(id:ProductInvetoryRegisterPurchaseModelDataButWithoutSaveInDatabase.Id, ProductInventoryPurchaseNewVersion:ProductInvetoryRegisterPurchaseModelDataButWithoutSaveInDatabase);
            Assert.Contains(this.NotFoundResult, ResponseIdEqualButNotExistAProductWithId.Result.ToString());


        }
        [Fact]
        public void Create()
        {
            ContextConfig = ProductInvetoryRegisterPurchaseModelData;
            ProductInventoryRegisterPurchaseControllerInstance = ContextConfig;

        }
    }
}