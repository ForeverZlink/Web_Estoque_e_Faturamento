using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Estoque_E_Faturamento._Models
{
    public class ProductListReminderToBuyWithoutUseProductAlreadyRegistered
    {
      
        
        [Key]
        public int Id {get;set;}
        
        public string DateOfCreation { get;set;}
        public string NameOfProduct{get;set;}
        public string CodeOfProduct{get;set;}
       

        public  bool AlreadyBuyed { get; set; }

      
        
       
    }
}