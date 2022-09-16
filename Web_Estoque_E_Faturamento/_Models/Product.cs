using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
namespace Web_Estoque_E_Faturamento._Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name{get; set; }
        
        public string? Description{ get; set; }
        
        public string? Code{ get; set; }
        
        public string? DateOfCreation {get;set;}

        public virtual ProductInventory? ProductInventory {get;set;}

    }
}
