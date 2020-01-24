using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Task6ORM.Models;

namespace Task6Library
{
    public static class DataToExcelFileHelper
    {
        private const string ResultsPath = "ResultsTable.xlsx";
        private const string ExpelledStudentsPath = "ExpelledStudentsTable.xlsx";

        public static bool SaveResultsToXLSX(List<ResultOfSessionDto> results)
        {
            try
            {
                Application excelapp = new Application();
                Workbook workbook = excelapp.Workbooks.Add();
                Worksheet worksheet = (Worksheet)workbook.Sheets[1];

                int rowIndex = 1;
                int columnIndex = 1;

                for (int i = 0; i < results.Count; i++)
                {
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Учебный год: {0}", results[i].EducationPeriod);
                    rowIndex++;
                    columnIndex++;

                    worksheet.Cells[rowIndex, columnIndex] = "Максимальный балл по группам";
                    rowIndex++;
                    columnIndex++;
                    for (int j = 0; j < results[i].MaxMarksGroups.Count; j++)
                    {
                        worksheet.Cells[rowIndex, columnIndex] = results[i].MaxMarksGroups[j];
                        rowIndex++;
                    }

                    columnIndex--;
                    worksheet.Cells[rowIndex, columnIndex] = "Средний балл по группам";
                    rowIndex++;
                    columnIndex++;
                    for (int j = 0; j < results[i].MiddleMarksGroups.Count; j++)
                    {
                        worksheet.Cells[rowIndex, columnIndex] = results[i].MiddleMarksGroups[j];
                        rowIndex++;
                    }

                    columnIndex--;
                    worksheet.Cells[rowIndex, columnIndex] = "Минимальный балл по группам";
                    rowIndex++;
                    columnIndex++;
                    for (int j = 0; j < results[i].MinMarksGroups.Count; j++)
                    {
                        worksheet.Cells[rowIndex, columnIndex] = results[i].MinMarksGroups[j];
                        rowIndex++;
                    }
                    rowIndex++;
                    columnIndex = 1;
                }

                excelapp.AlertBeforeOverwriting = false;
                workbook.SaveAs(string.Format("{0}/{1}", Directory.GetCurrentDirectory(), ResultsPath));
                excelapp.Quit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SaveExpelledStudentsToXLSX(List<ExpelledStudentDto> results)
        {
            try
            {
                Application excelapp = new Application();
                Workbook workbook = excelapp.Workbooks.Add();
                Worksheet worksheet = (Worksheet)workbook.Sheets[1];

                int rowIndex = 1;
                int columnIndex = 1;

                for (int i = 0; i < results.Count; i++)
                {
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Отчисляемые студенты в группе: {0}", results[i].Group);
                    rowIndex++;
                    columnIndex++;

                    for (int j = 0; j < results[i].ExpelledStudents.Count; j++)
                    {
                        worksheet.Cells[rowIndex, columnIndex] = results[i].ExpelledStudents[j];
                        rowIndex++;
                    }
                    columnIndex = 1;
                }

                excelapp.AlertBeforeOverwriting = false;
                workbook.SaveAs(string.Format("{0}/{1}", Directory.GetCurrentDirectory(), ExpelledStudentsPath));
                excelapp.Quit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
