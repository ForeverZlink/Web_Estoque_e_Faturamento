using OfficeOpenXml;
namespace Web_Estoque_E_Faturamento.ClassUtilities
{
    public class ExcelHandler
    {
        public string DirectoryToExcelCreation;
        public string[] ValuesToColumsTitles;
        public string[] ValuesToRows;
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
