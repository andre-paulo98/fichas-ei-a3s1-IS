using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelLib1
{
    public static class ExcelHandler
    {
        public static void CreateNewExcelFile(string filename)
        {
            var excelApplication = new Excel.Application();
            excelApplication.Visible = true;

            var excelWorkbook = excelApplication.Workbooks.Add();
            excelWorkbook.SaveAs(filename, AccessMode: Excel.XlSaveAsAccessMode.xlNoChange);

            excelWorkbook.Close();
            excelApplication.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
            excelWorkbook = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication);
            excelApplication = null;

            GC.Collect();
        }


        public static void WriteToExcelFile(string filename)
        {
            var excelApplication = new Excel.Application();
            excelApplication.Visible = true;

            Excel.Workbook workbook = excelApplication.Workbooks.Open(filename);
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            worksheet.Cells[1, 1].Value = "Hello";
            worksheet.Cells[1, 2].Value = "World!";

            var worksheet2 = workbook.Worksheets.Add();
            worksheet2.Cells[1, 1].Value = "Goodbye";
            worksheet2.Cells[1, 2].Value = "World!";

            workbook.Save();
            workbook.Close();
            excelApplication.Quit();


            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            workbook = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            worksheet = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet2);
            worksheet2 = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication);
            excelApplication = null;

            GC.Collect();


        }

        public static string ReadFromExcelFile(string filename)
        {
            var excelApplication = new Excel.Application();
            excelApplication.Visible = true;

            Excel.Workbook workbook = excelApplication.Workbooks.Open(filename);
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            string content = worksheet.Cells[1, 1].Value+"";
            content += (worksheet.Cells[1, 2] as Excel.Range).Text;

            workbook.Close();
            excelApplication.Quit();


            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            workbook = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            worksheet = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication);
            excelApplication = null;

            return content;
        }

        public static void CreateChartToExcelFile(string filename)
        {
            var excelApplication = new Excel.Application();
            excelApplication.Visible = true;

            Excel.Workbook workbook = excelApplication.Workbooks.Open(filename);
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            Excel.Chart myChart = null;
            Excel.ChartObjects charts = worksheet.ChartObjects();
            Excel.ChartObject chartObj = charts.Add(50, 50, 300, 300);

            myChart = chartObj.Chart;

            var myRange = worksheet.get_Range("B1:B4");
            myChart.SetSourceData(myRange);

            myChart.ChartType = Excel.XlChartType.xlLine;
            myChart.ChartWizard(Source: myRange,
                Title: "GraphTitle",
                CategoryTitle: "Title of X axis...",
                ValueTitle: "Title of Y axis...");

            workbook.Save();
            workbook.Close();
            excelApplication.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            workbook = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            worksheet = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication);
            excelApplication = null;

        }

        public static string ReadFromExcelFile(string filename, int lines, int cols)
        {
            var excelApplication = new Excel.Application();
            excelApplication.Visible = true;

            Excel.Workbook workbook = excelApplication.Workbooks.Open(filename);
            Excel.Worksheet worksheet = workbook.ActiveSheet;


            //string content = ((Excel.Range)worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[lines, cols])).Text;
            Excel.Range range = (Excel.Range)worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[lines, cols]].Cells;
            var content = range.Value2;
            string result = "";
            foreach (var item in content)
            {
                result += item + "";
            }

            workbook.Close();
            excelApplication.Quit();


            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            workbook = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            worksheet = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication);
            excelApplication = null;

            return result;
        }

    }
}
