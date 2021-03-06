using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Estoque_E_Faturamento._Models;

namespace Web_Estoque_E_Faturamento.ViewModels
{
    public class ProductContextNecessary
    {
        public ProductContextNecessary (
            ICollection<Provider> providers, Product ProductCommon,ProductInventory productInventory, 
            IEnumerable<Product> product, IEnumerable<ProductInventoryRegisterPurchase> productInventoryRegisterPurchase,
            ProductInventoryRegisterPurchase ProducInventoryPurchase = null
        )
        {
            this.ProducInventoryPurchase = ProducInventoryPurchase;
            this.Product=product;
            this.ProductCommon=ProductCommon;
            this.ProductInventory = productInventory;
            this.Provider = providers;
            this.ProductInventoryRegisterPurchase=productInventoryRegisterPurchase;         
        }
   
        public IEnumerable<Product> Product{get;set;}
        public ICollection<Provider> Provider{get;set;}
        public Product ProductCommon {get;set;}
        public IEnumerable<ProductInventoryRegisterPurchase> ProductInventoryRegisterPurchase {get;set;}
        public ProductInventory ProductInventory{get;set;}
        public ProductInventoryRegisterPurchase ProducInventoryPurchase { get; set; }

    }
}