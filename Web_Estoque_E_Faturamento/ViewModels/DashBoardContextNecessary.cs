using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Estoque_E_Faturamento._Models;

namespace Web_Estoque_E_Faturamento.ViewModels
{
    public class DashBoardContextNecessary
    {
        public Provider Provider {get;set;}
        public Product  Product{get;set;}
        public ProductInventoryRegisterPurchase ProductInventoryRegisterPurchase {get;set;}
    }
}