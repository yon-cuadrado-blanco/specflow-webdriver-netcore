// <copyright file="ExcelFileHelper.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Automation.Helpers
{
    using System;
    using System.IO;
    using DataFactory.Configuration;
    using OfficeOpenXml;

    /// <summary>
    /// Excel file helper.
    /// </summary>
    public class ExcelFileHelper : IDisposable
    {
        /// <summary>
        /// The excel workbook.
        /// </summary>
        private ExcelWorkbook workbook;

        /// <summary>
        /// The excel package.
        /// </summary>
        private ExcelPackage excelPackge;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The column index to column letter.
        /// </summary>
        /// <param name="colIndex">The col index.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ColumnIndexToColumnLetter(int colIndex)
        {
            var div = colIndex;
            var colLetter = string.Empty;

            while (div > 0)
            {
                var mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (div - mod) / 26;
            }

            return colLetter;
        }

        /// <summary>
        /// Excels the column name to number.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The column number.</returns>
        /// <exception cref="ArgumentNullException">The columnName.</exception>
        public static int ExcelColumnNameToNumber(string columnName)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException(nameof(columnName));
            }

            columnName = columnName.ToUpperInvariant();

            int sum = 0;

            for (int i = 0; i < columnName.Length; i++)
            {
                sum *= 26;
                sum += columnName[i] - 'A' + 1;
            }

            return sum;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
            GC.SuppressFinalize(obj: this);
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="fileNameAndPath">The file name and path.</param>
        public void OpenFile(string fileNameAndPath)
        {
            var file = new FileInfo(fileNameAndPath);
            this.excelPackge = new ExcelPackage(file);
            this.workbook = this.excelPackge.Workbook;
        }

        /// <summary>
        /// The get cell data.
        /// </summary>
        /// <param name="workSheetName">The work sheet name.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="columnNumber">The column number.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetCellData(string workSheetName, int rowNumber, int columnNumber)
        {
            var workSheet = this.workbook.Worksheets[workSheetName];
            return workSheet.Cells[rowNumber, columnNumber].ToString();
        }

        /// <summary>
        /// Gets the cell data.
        /// </summary>
        /// <param name="workSheetName">Name of the work sheet.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>THe cell data.</returns>
        public string GetCellData(string workSheetName, int rowNumber, string columnName)
        {
            var columnNumber = ExcelColumnNameToNumber(columnName);
            var workSheet = this.workbook.Worksheets[workSheetName];
            return workSheet.Cells[rowNumber, columnNumber].Value.ToString();
        }

        /// <summary>
        /// Get the worksheet row count.
        /// </summary>
        /// <param name="workSheetName">The name of the worksheet.</param>
        /// <returns>The excel row count.</returns>
        public int CountWorksheetRows(string workSheetName)
        {
            var workSheet = this.workbook.Worksheets[workSheetName];
            return workSheet.Dimension.Rows;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">The disposing parameter.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.excelPackge.Dispose();
                    this.excelPackge = null;
                }
            }

            // dispose unmanaged resources
            this.disposed = true;
        }
    }
}