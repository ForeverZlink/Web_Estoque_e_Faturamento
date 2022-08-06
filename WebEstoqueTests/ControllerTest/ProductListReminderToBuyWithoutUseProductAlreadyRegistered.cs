using Xunit;
using Moq;
using Web_Estoque_E_Faturamento;
using Web_Estoque_E_Faturamento.Controllers;
using Web_Estoque_E_Faturamento._Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Linq;
using WebEstoqueTests;
using Microsoft.Extensions.Logging;

using System;

namespace WebEstoqueTests
{
    
  
    
    
    public class ProductListReminderToBuyWithoutUseProductAlreadyRegistered:Controller
    {


        static public TestDatabaseFixture Fixture = new TestDatabaseFixture();
        public string ViewResult = "ViewResult";
        public string NotFoundResult = "NotFoundResult";
        public string RedirectToActionResult = "RedirectToActionResult";


        MvcProductContext context = Fixture.CreateContext();
       
        
        
        
    }
}