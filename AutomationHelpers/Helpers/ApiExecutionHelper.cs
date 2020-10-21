// <copyright file="ApiExecutionHelper.cs" company="demian INC.">
// Copyright (c) demian INC. All Rights Reserved.Licensed under the Apache License, Version 2.0.
// See LICENSE in the project root for license information.
// </copyright>

namespace Automation.Helpers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using DataFactory.Configuration;

    /// <summary>
    /// The api Execution helper class.
    /// </summary>
    public class ApiExecutionHelper
    {
        /// <summary>
        /// The options.
        /// </summary>
        private IWritableOptions<ConfigurationParameters> options;

        /// <summary>
        /// The HTTP response message.
        /// </summary>
        private HttpResponseMessage httpResponseMessage;

        /// <summary>
        /// The user identifier.
        /// </summary>
        private string userId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiExecutionHelper"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApiExecutionHelper(IWritableOptions<ConfigurationParameters> options)
        {
            this.options = options;
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        public void SendRequest()
        {
            using (var httpClient = new HttpClient())
            {
                var uriBuilder = new UriBuilder(this.options.Value.UrlParameters.ApiUrl);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query[nameof(this.userId)] = this.userId;
                uriBuilder.Query = query.ToString();
                var longurl = uriBuilder.ToString();

                var uri =
                    new Uri(longurl);

                var request = new HttpRequestMessage(HttpMethod.Get, uri);

                var task = httpClient.SendAsync(request);
                Task.WaitAll(task);

                this.httpResponseMessage = task.Result;
            }
        }

        /// <summary>
        /// Sets the user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public void SetUserId(string userId)
        {
            this.userId = userId;
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <returns>Gets the http response.</returns>
        public HttpResponseMessage GetResponse()
        {
            return this.httpResponseMessage;
        }
    }
}