// <copyright file="GlobalSuppressions.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1124:Do not use regions", Justification = "It is OK in this case", Scope = "type", Target = "~T:Automation.Pages.DragAndDropPage")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1124:Do not use regions", Justification = "It is OK in this case", Scope = "type", Target = "~T:Automation.Pages.WebElementColorsCheckPage")]
[assembly: SuppressMessage("Style", "GCop412:Don't hardcode a path. Consider using “AppDomain.CurrentDomain.GetPath()” instead.", Justification = "It is OK in this case", Scope = "member", Target = "~M:Automation.WebDriverHelper.AndroidWebDriver.StartAppium")]
[assembly: SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "It is OK in this case", Scope = "member", Target = "~P:Automation.Pages.DragAndDropPage.HighTatras")]
[assembly: SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "It is OK in this case", Scope = "member", Target = "~P:Automation.Pages.DragAndDropPage.HighTatras2")]
[assembly: SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "It is OK in this case", Scope = "member", Target = "~P:Automation.Pages.DragAndDropPage.Trash")]
[assembly: SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "It is OK in this case", Scope = "member", Target = "~P:Automation.Pages.DragAndDropPage.DragMeAround")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "It is OK in this case", Scope = "member", Target = "~M:Automation.WebDriverHelper.FirefoxWebDriver.CreateWebDriver(DataFactory.Configuration.IWritableOptions{DataFactory.Configuration.ConfigurationParameters})~OpenQA.Selenium.Firefox.FirefoxDriver")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "It is OK in this case", Scope = "member", Target = "~M:Automation.WebDriverHelper.IeWebdriver.CreateWebDriver(DataFactory.Configuration.IWritableOptions{DataFactory.Configuration.ConfigurationParameters})~OpenQA.Selenium.IE.InternetExplorerDriver")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "It is OK in this case", Scope = "member", Target = "~M:Automation.WebDriverHelper.ChromeWebDriver.CreateWebDriver(DataFactory.Configuration.IWritableOptions{DataFactory.Configuration.ConfigurationParameters})~OpenQA.Selenium.Chrome.ChromeDriver")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "It is OK in this case", Scope = "member", Target = "~M:Automation.WebDriverHelper.ChromeWebDriver.CreateNewWebDriver(DataFactory.Configuration.IWritableOptions{DataFactory.Configuration.ConfigurationParameters})~OpenQA.Selenium.IWebDriver")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:File should have header", Justification = "It is OK in this case")]
[assembly: SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "It is OK in this case", Scope = "member", Target = "~M:WebDriverHelper.Extensions.ElementExtensions.GetHexColor(System.Drawing.Color)~System.String")]
[assembly: SuppressMessage("Performance", "CA1806:Do not ignore method results", Justification = "It is OK in this case", Scope = "member", Target = "~M:WebDriverHelper.Extensions.ElementExtensions.ToColor(System.String)~System.Drawing.Color")]
