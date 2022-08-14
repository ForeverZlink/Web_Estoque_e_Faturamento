using OfficeOpenXml;
using Microsoft.AspNetCore.Mvc;
using Web_Estoque_E_Faturamento._Models;
namespace Web_Estoque_E_Faturamento.ClassUtilities
{
    public class ExcelHandler
    {
        public string DirectoryToExcelCreation;
        public string[] ValuesToColumsTitles;
        public string[] ValuesToRows;
        public ExcelPackage ExcelInstance;
        public ExcelWorksheet Sheet;
        string ExtensionOfFileDefault = ".xlsx";
        public string ExcelContentTypeToAspNetReturn = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public ExcelHandler(
            string directoryToExcelCreation, 
            string[]valuesToColumsTitles,
            string[]valuesToRow)
        {
            DirectoryToExcelCreation = directoryToExcelCreation;
            ValuesToColumsTitles = valuesToColumsTitles;
            ValuesToRows = valuesToRow;
            ExcelPackage ExcelGateway = new ExcelPackage(DirectoryToExcelCreation); 
        }

    }
}
