#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Web_Estoque_E_Faturamento._Models;

    public class MvcIndependentObjectsOfProductsContext : DbContext
    { 
        public MvcIndependentObjectsOfProductsContext (DbContextOptions<MvcIndependentObjectsOfProductsContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            
        }
        public DbSet<Web_Estoque_E_Faturamento._Models.ProductListReminderToBuyWithoutUseProductAlreadyRegistered> ProductListReminderToBuyWithoutUseProductAlreadyRegistered {get;set;}
    
        
    }
