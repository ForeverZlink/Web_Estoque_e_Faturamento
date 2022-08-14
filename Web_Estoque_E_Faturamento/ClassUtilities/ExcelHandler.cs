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
            string directoryToExcelCreation=null

            )
        {
            DirectoryToExcelCreation = directoryToExcelCreation;
            
            if (directoryToExcelCreation == null)
            {
                this.ExcelInstance= new ExcelPackage();
            }
            else
            {
                this.ExcelInstance = new ExcelPackage(DirectoryToExcelCreation);

            }
        }

        public void CreateSheet(string SheetName)
        {
            this.Sheet = ExcelInstance.Workbook.Worksheets.Add(SheetName);


        }
        public void SaveArchive(string NameArchive)
        {
            
            
            this.ExcelInstance.SaveAs(NameArchive);
        }

        public void AddRowsIntoSheet<T>(T[] values)
        {
            


        }
        public void AddTitleIntoSheet( string[] ValuesToTitle= null)
        {


                int counter = 1;
                foreach (var TitleName in ValuesToTitle)
                {
                    this.Sheet.Cells[1,counter ].Value = TitleName;
                    counter++;
                }
            
            
        }

         public MemoryStream CreateStreamSheetWithValues<T>(
            string SheetName,
            string[] TitlesTable,
            T[] ValuesToInsertInRows
            )
        {
            var stream = new MemoryStream();
            this.CreateSheet(SheetName);
            this.AddTitleIntoSheet(TitlesTable);
            this.AddRowsIntoSheet(ValuesToInsertInRows);
            this.ExcelInstance.SaveAs(stream);

            return stream;
        }

    }
}
