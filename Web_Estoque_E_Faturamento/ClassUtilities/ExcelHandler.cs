using OfficeOpenXml;
using Microsoft.AspNetCore.Mvc;
using Web_Estoque_E_Faturamento._Models;
using System.Text;

namespace Web_Estoque_E_Faturamento.ClassUtilities
{
    public class ExcelHandler
    {
        public string DirectoryToExcelCreation;

        public bool SucessOperation = true;
        public string[] ValuesToColumsTitles;
        public string[] ValuesToRows;
        public ExcelPackage ExcelInstance;
        public int RowToInsertTitles = 1;
        public ExcelWorksheet Sheet;
        string ExtensionOfFileDefault = ".xlsx";
        static public string ExcelContentTypeToAspNetReturn = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

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

        public bool AddRowsIntoSheet(Dictionary<string,string[]> ValuesToInsert)
        {
            int IndexOfRowToInsertValues = this.RowToInsertTitles+1;
            int IndexColumn = 1;

            foreach (var ValuesOfArrayToInsertInRow in ValuesToInsert.Values) {
                foreach(var Value in ValuesOfArrayToInsertInRow)
                {
                    this.Sheet.Cells[IndexOfRowToInsertValues, IndexColumn].Value = Value;
                    IndexOfRowToInsertValues++;

                }
                IndexOfRowToInsertValues = this.RowToInsertTitles + 1;
                IndexColumn++;
            }
            return true;

        }
        public bool AddTitleIntoSheet( string[] ValuesToTitle)
        {
            
            if (this.Sheet == null) {
                throw new ArgumentNullException("Erro, not exists a sheet");
            }
            //1 == First Row
            
            int ColumnIndex = 1;

            try
            {
                foreach (var TitleName in ValuesToTitle)
                {
                    this.Sheet.Cells[this.RowToInsertTitles, ColumnIndex].Value = TitleName;
                    ColumnIndex++;
                }

            }catch (Exception e)
            {
                throw e;
            }


            return this.SucessOperation;

        }

         public MemoryStream CreateStreamSheetWithValues(
            string SheetName,
            string[] TitlesTable,
            Dictionary<string, string[]> ValuesToInsertInRows
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
