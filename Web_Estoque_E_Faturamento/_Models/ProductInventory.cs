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
        public int Id {get;set;}
        public float ?QuantityInStock {get;set;}

        
        [ForeignKey("Product")]
        public int ProductId {get;set;}
        public virtual Product Product {get;set;}


        
        public virtual ICollection<ProductInventoryRegisterPurchase>? ProductInventoryRegisterPurchase  {get;set;}

        public void ChangeInventory(float ValueForChange)
        {
            this.QuantityInStock = ValueForChange;
        }
        public void AddInInventoryQuantityBuyed(float QuantityBuyed){
            this.QuantityInStock+=QuantityBuyed;
                

        }
        public void RemoveOfTheInventoryQuantity(float QuantityToRemove)
        {
            this.QuantityInStock -= QuantityToRemove;
        }

        public void AddPurchaseInProductInventory(ProductInventoryRegisterPurchase purchase){
            this.ProductInventoryRegisterPurchase.Add(purchase);
            AddInInventoryQuantityBuyed(purchase.QuantityBuyed);

        }
        
    }
}
