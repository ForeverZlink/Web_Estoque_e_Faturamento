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
    public class ProductInventoryRegisterPurchaseControlleTest:Controller
    {
        public string ViewResult = "ViewResult";
        public string NotFoundResult = "NotFoundResult";
        public string RedirectToActionResult = "RedirectToActionResult";
        static DbContextOptions<MvcProductContext> option = new DbContextOptionsBuilder<MvcProductContext>().UseInMemoryDatabase(databaseName:"ProductContextDatabase").Options;
        MvcProductContext context = new MvcProductContext(option);
        static Provider ProviderInstance = new Provider(){
            Name="Volkswagem",Andress="Rua das limitã",Cnpj="134"
        };
        static Product Product = new Product(){
            Name="Car",Code="01",Description="A nice car"
           };

        ProductInventoryRegisterPurchase ProductInvetoryRegisterPurchaseModelData = new ProductInventoryRegisterPurchase(){
            Id=1,QuantityBuyed=1,PriceOfPurchase=20,DateOfPurchase=DateTime.Today.ToString(),
            PriceProductUnity=2, ProviderId=1,Provider=ProviderInstance, 
            ProductId=1,Product=Product
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
            //This part will be test Edit method when acess via get, thus
            //its just search in database for the informations

            ContextConfig =ProductInvetoryRegisterPurchaseModelData;
            ProductInventoryRegisterPurchaseControllerInstance = ContextConfig;
            //When its passed a id null
            var ResponseWantedIdIsNull = ProductInventoryRegisterPurchaseControllerInstance.Edit(id:null);
            Assert.Contains(this.NotFoundResult, ResponseWantedIdIsNull.Result.ToString());
            
            //When its passed id that not null, but doesn't exists in database
            var ResponseWantedIdNotIsNullButDoesntExists= ProductInventoryRegisterPurchaseControllerInstance.Edit(id:4343343);
            Assert.Contains(this.NotFoundResult, ResponseWantedIdNotIsNullButDoesntExists.Result.ToString());
            
            // When its passed a product id that already exists
            var ResponseWantedExists= ProductInventoryRegisterPurchaseControllerInstance.Edit(id:ProductInvetoryRegisterPurchaseModelData.Id);
            Assert.Contains(this.ViewResult, ResponseWantedExists.Result.ToString());
            
            //end of part of test via get

            //This part will be test Edit method when acess via post 
            
            //When id its different of product.Id
            var ResponseIdIsDifferentOfProductId =ProductInventoryRegisterPurchaseControllerInstance.Edit(id:999999, ProductInventory:ProductInvetoryRegisterPurchaseModelData);
            Assert.Contains(this.NotFoundResult, ResponseIdIsDifferentOfProductId.Result.ToString());

            //When id its equal, exist the product in database and the  changes were made.
            var ResponseIdEqualAndExistAProductWithId =ProductInventoryRegisterPurchaseControllerInstance.Edit(id:ProductInvetoryRegisterPurchaseModelData.Id, ProductInventory:ProductInvetoryRegisterPurchaseModelData);
            Assert.Contains(this.RedirectToActionResult, ResponseIdEqualAndExistAProductWithId.Result.ToString());

            //when id passed its equal a product.Id, but doesn't exist a product with this id in database
            
            ProductInventoryRegisterPurchase ProductInvetoryRegisterPurchaseModelDataButWithoutSaveInDatabase = new ProductInventoryRegisterPurchase(){

            Id=33333333,QuantityBuyed=1,PriceOfPurchase=20,DateOfPurchase=DateTime.Today.ToString(),
            PriceProductUnity=2, ProviderId=1,Provider=ProviderInstance, 
            ProductId=2,Product=Product};
            var ResponseIdEqualButNotExistAProductWithId =ProductInventoryRegisterPurchaseControllerInstance.Edit(id:ProductInvetoryRegisterPurchaseModelDataButWithoutSaveInDatabase.Id, ProductInventory:ProductInvetoryRegisterPurchaseModelDataButWithoutSaveInDatabase);
            Assert.Contains(this.NotFoundResult, ResponseIdEqualButNotExistAProductWithId.Result.ToString());


        }
    }
}