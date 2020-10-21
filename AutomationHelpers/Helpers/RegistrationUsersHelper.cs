// <copyright file="RegistrationUsersHelper.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Automation.Helpers
{
    using System.Collections.Generic;
    using System.IO;
    using DataFactory.Configuration;

    /// <summary>
    /// Registration users helper.
    /// </summary>
    public class RegistrationUsersHelper
    {
        /// <summary>
        /// The excel file helper.
        /// </summary>
        private ExcelFileHelper excelFileHelper;

        /// <summary>
        /// The configuration parameters.
        /// </summary>
        private IWritableOptions<ConfigurationParameters> options;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationUsersHelper"/> class.
        /// </summary>
        /// <param name="excelFileHelper">The excel file helper.</param>
        /// <param name="options">The options.</param>
        public RegistrationUsersHelper(ExcelFileHelper excelFileHelper, IWritableOptions<ConfigurationParameters> options)
        {
            this.excelFileHelper = excelFileHelper;
            this.options = options;
        }

        /// <summary>
        /// Gets the user data.
        /// </summary>
        /// <param name="userDataFile">The user data file.</param>
        /// <returns>The user data list.</returns>
        public List<RegisterAndLoginDto> GetUserData(string userDataFile)
        {
            var absoluteFileNameAndPath = Path.Combine(this.options.Value.GeneralParameters.ProjectRootFolder, userDataFile);
            this.excelFileHelper.OpenFile(absoluteFileNameAndPath);
            var usersData = new List<RegisterAndLoginDto>();
            var wbksheet = this.excelFileHelper.CountWorksheetRows(Constants.UserDataSheetName);

            var rowCount = this.excelFileHelper.CountWorksheetRows(Constants.UserDataSheetName) - 1;
            for (var rowIndex = 2; rowIndex <= rowCount; rowIndex++)
            {
                var userData = new RegisterAndLoginDto
                {
                    FirstName = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetFirstNameColumn),
                    LastName = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetLastNameColumn),
                    Phone = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetPhoneColumn),
                    Email = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetEmailColumn),
                    Address1 = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetAddress1Column),
                    Address2 = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetAddress2Column),
                    City = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetCityColumn),
                    StateProvince = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetStateProvince),
                    PostalCode = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetPostalCode),
                    Country = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetCountry),
                    UserName = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UsersDataSheetUserNameColumn),
                    Password = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetUserPasswordColumn),
                    ConfirmPassword = this.excelFileHelper.GetCellData(Constants.UserDataSheetName, rowIndex, Constants.UserDataSheetUserPasswordColumn),
                };
                usersData.Add(userData);
            }

            return usersData;
        }
    }
}