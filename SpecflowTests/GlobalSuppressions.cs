// <copyright file="GlobalSuppressions.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "It is OK in this case", Scope = "member", Target = "~M:Specflow.GlobalFunctions.Hooks.CloseOrResetBrowser")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "It is OK in this case", Scope = "member", Target = "~M:Specflow.Steps.CommonSteps.GivenINavigateToThePage(System.String)")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:Specflow.GlobalFunctions.Hooks.CreateContainer~BoDi.IObjectContainer")]
