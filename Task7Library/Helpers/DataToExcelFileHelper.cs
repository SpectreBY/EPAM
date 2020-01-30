using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Task7ORM.DTO;
using Task7ORM.Models;

namespace Task7Library
{
    /// <summary>
    /// Helper static class which represents functionality for save data to xlsx files
    /// </summary>
    public static class DataToExcelFileHelper
    {
        /// <summary>
        /// constant fields with path of results files
        /// </summary>
        private const string ResultsOfSessionBySpecialityPath = "ResultsOfSessionBySpecialityTable.xlsx";
        private const string ResultsOfSessionBySubjectPath = "ResultsOfSessionBySubjectTable.xlsx";
        private const string ResultsOfSessionByTeacherPath = "ResultsOfSessionByTeacherTable.xlsx";

        /// <summary>
        /// Method for save Results Of Session By Speciality to xlsx file
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public static bool SaveResultsOfSessionBySpecialityToXLSX(List<ResultsOfSessionBySpecialityDto> results)
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
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Учебный год: {0}", results[i].SessionPeriod);
                    rowIndex++;
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Специальность: {0}", results[i].Speciality);
                    columnIndex++;
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Средняя оценка за 1й семестр: {0}", results[i].FirstSemestrMiddleMark);
                    columnIndex++;
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Средняя оценка за 2й семестр: {0}", results[i].SecondSemestrMiddleMark);
                    rowIndex++;
                    columnIndex = 1;
                }

                excelapp.AlertBeforeOverwriting = false;
                workbook.SaveAs(string.Format("{0}/{1}", Directory.GetCurrentDirectory(), ResultsOfSessionBySpecialityPath));
                excelapp.Quit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for save Results Of Session By Teacher to xlsx file
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public static bool SaveResultsOfSessionByTeacherToXLSX(List<ResultsOfSessionByTeacherDto> results)
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
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Учебный год: {0}", results[i].SessionPeriod);
                    rowIndex++;
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Преподаватель: {0}", results[i].Teacher);
                    columnIndex++;
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Средняя оценка за 1й семестр: {0}", results[i].FirstSemestrMiddleMark);
                    columnIndex++;
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Средняя оценка за 2й семестр: {0}", results[i].SecondSemestrMiddleMark);
                    rowIndex++;
                    columnIndex = 1;
                }

                excelapp.AlertBeforeOverwriting = false;
                workbook.SaveAs(string.Format("{0}/{1}", Directory.GetCurrentDirectory(), ResultsOfSessionByTeacherPath));
                excelapp.Quit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for save Results Of Session By Subject to xlsx file
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public static bool SaveResultsOfSessionBySubjectToXLSX(List<ResultsOfSessionBySubjectDto> results)
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
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Учебный год: {0}", results[i].SessionPeriod);
                    rowIndex++;
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Предмет: {0}", results[i].Subject);
                    columnIndex++;
                    worksheet.Cells[rowIndex, columnIndex] = string.Format("Оценка: {0}", results[i].MiddleMark);
                    rowIndex++;
                    columnIndex = 1;
                }

                excelapp.AlertBeforeOverwriting = false;
                workbook.SaveAs(string.Format("{0}/{1}", Directory.GetCurrentDirectory(), ResultsOfSessionBySubjectPath));
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
