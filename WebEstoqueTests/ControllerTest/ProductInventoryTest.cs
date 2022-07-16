using Xunit;
using Moq;
using Web_Estoque_E_Faturamento.Controllers;
using Web_Estoque_E_Faturamento._Models;
using WebEstoqueTests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
namespace WebEstoqueTests.ControllerTest
{
    public class ProductInventoryTest:ProductInventory
        {
        public string ViewResult = "ViewResult";
        public string NotFoundResult = "NotFoundResult";
        public string RedirectToActionResult = "RedirectToActionResult";
         public ProductInventoryTest(TestDatabaseFixture fixture)=>Fixture=fixture;
       static public TestDatabaseFixture? Fixture;
         MvcProductContext context = Fixture.CreateContext();
        
        static Provider ProviderInstance = new Provider(){
            Name="Volkswagem",Andress="Rua das limitã",Cnpj="134"
        };
        static Product Product = new Product(){Id=9,
            Name="Car",Code="01",Description="A nice car"
        };
        
        static public ProductInventoryRegisterPurchase ProductInvetoryRegisterPurchaseModelData = new ProductInventoryRegisterPurchase(){
            Id=1,QuantityBuyed=3,PriceOfPurchase=30,DateOfPurchase=System.DateTime.Today.ToString(),
            PriceProductUnity=10, ProviderId=1,Provider=ProviderInstance, 
            ProductId=1,Product=Product
        };
         ProductInventory productInventory = new ProductInventory(){Product=Product,
         QuantityInStock=ProductInvetoryRegisterPurchaseModelData.QuantityBuyed};
        
        
        
        public void CalculateValueTotalOfTheStockForTheProductTest(){
            
            
            Product.ProductInventory=productInventory;
            
            Product.ProductInventory.ProductInventoryRegisterPurchase.Add(ProductInvetoryRegisterPurchaseModelData);
            var result = Product.ProductInventory.test();
            Assert.Equal(result,30);
            

        }

        }

}