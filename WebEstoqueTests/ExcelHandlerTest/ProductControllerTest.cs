using Xunit;
using Moq;
using Web_Estoque_E_Faturamento.ClassUtilities;

using Microsoft.Extensions.Logging;

using System;

namespace WebEstoqueTests
{


    public class ExcelHandlerTest
    {
        static public string[] ExcelTitlesColums = new string[] { "Código do Produto", "Nome do produto" };
        static public string[] ExcelValuesRow = new string[] { "0720I", "Iphone5" };
        static public string ExcelDirectory = "Programação/Projetos web/WebEstoqueEFaturamento/WebEstoqueTests/Archive.xlsx";
           
        public ExcelHandler excel = new ExcelHandler(
            directoryToExcelCreation: ExcelDirectory
            
            
            );

        [Fact]
        public void CreateSheetTest()
        {
            this.excel.CreateSheet("MySheetTesting");
            this.excel.SaveArchive("Testing.xlsx");
        }
        
    }
}