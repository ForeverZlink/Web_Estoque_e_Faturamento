using Xunit;
using Moq;
using Web_Estoque_E_Faturamento.ClassUtilities;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
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
            
        }

        [Fact]
        public void AddTitleIntoSheetTest()
        {
            string NameSheet = "Testing";
            this.excel.CreateSheet(NameSheet);
            var response = this.excel.AddTitleIntoSheet(ExcelTitlesColums);
            Assert.True(response);
        }

        [Fact]
        public void AddRowsIntoSheetTest() {
            
            Dictionary<string, string[]> values = new Dictionary<string, string[]>();
            this.excel.CreateSheet("Test");
            string[] Names = new string[] { "Test", "Tst" };
            string[] Codes = new string[] { "001", "002" };

            //First Collumn
            values.Add("Names",Names);

            //Second Collumn
            values.Add("Codes", Codes);

            var  response = this.excel.AddRowsIntoSheet(values);
            Assert.True(response);
            var FirstNameInTableValue = this.excel.Sheet.Cells[this.excel.RowToInsertTitles+1, 1].Value.ToString();
            
            string FirstName = Names[0];
            Assert.Equal(FirstName, FirstNameInTableValue);



        
        }

    }
}