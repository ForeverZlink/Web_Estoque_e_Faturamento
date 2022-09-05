using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Estoque_E_Faturamento._Models
{
    public class ProductInventoryRegisterPurchase
    {
        [Key]
        public int Id {get;set;}
        public float QuantityBuyed {get;set;}
        
        
        public string DateOfPurchase {get;set;}
        
        public int DanfeNumber { get; set; }

        public int Serie { get; set; }
        public float PriceOfPurchase {get;set;}
        public float PriceProductUnity {get;set;}

        [ForeignKey("ProductInventory")]
        public int ProductInventoryId{get;set;}

        //Case a view not send a arguement of the this type, the model state will raise a error.
        public ProductInventory? ProductInventory {get;set;}
        
        [ForeignKey("Provider")]
        public int ProviderId {get;set;}
        public Provider ?Provider{get;set;}
        
        [ForeignKey("Product")]
        public int ProductId{get;set;}
        public Product ?Product {get;set;}
       
    }
}