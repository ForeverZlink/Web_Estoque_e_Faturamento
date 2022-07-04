using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Estoque_E_Faturamento._Models;

namespace Web_Estoque_E_Faturamento.ViewModels
{
    public class ProductContextNecessary
    {
        public ProductContextNecessary ( IEnumerable<Product> product, IEnumerable<ProductInventoryRegisterPurchase> productInventoryRegisterPurchase){
            this.Product=product;
            
            this.ProductInventoryRegisterPurchase=productInventoryRegisterPurchase;         
        }
   
        public IEnumerable<Product> Product{get;set;}
        public IEnumerable<ProductInventoryRegisterPurchase> ProductInventoryRegisterPurchase {get;set;}

    }
}