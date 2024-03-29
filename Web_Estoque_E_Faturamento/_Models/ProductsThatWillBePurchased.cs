﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Web_Estoque_E_Faturamento._Models
{
    public class ProductsThatWillBePurchased
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductListReminderToBuyWithoutUseProductAlreadyRegistered")]
        public int IdProductListReminderToBuyWithoutUseProductAlreadyRegistered { get; set; }
        public ProductListReminderToBuyWithoutUseProductAlreadyRegistered? ProductListReminderToBuyWithoutUseProductAlreadyRegistereduct { get; set; }    
    }
}
