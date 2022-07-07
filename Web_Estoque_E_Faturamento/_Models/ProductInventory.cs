using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Estoque_E_Faturamento._Models
{
    public class ProductInventory
    {
        [Key]
        public int? Id {get;set;}
        public float ?QuantityInStock {get;set;}

        
        [ForeignKey("Product")]
        public int ProductId {get;set;}
        public virtual Product Product {get;set;}


        

        public List< ProductInventoryRegisterPurchase>? ProductInventoryRegisterPurchase  {get;set;}
        
    }
}
