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
        
        private string DateOfCreationDefault = DateTime.Now.ToString();
        public string NameOfProduct{get;set;}
        public string CodeOfProduct{get;set;}
        public string DateOfCreation {
            get{
                return DateOfCreationDefault;
            }
            set{
                ;
            }
        }

        private bool _AlreadyBuyed = false;

        public bool AlreadyBuyed {
            get{
                return AlreadyBuyed;
            }
            set{
                _AlreadyBuyed= value;
            }
        }

        
       
    }
}