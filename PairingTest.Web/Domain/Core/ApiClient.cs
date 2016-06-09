using PairingTest.Web.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace PairingTest.Web.Domain.Core
{
    public class ApiClient : IApiClient
    {
        private readonly IPairingTestUrlProvider _urlProvider;

        public ApiClient(IPairingTestUrlProvider urlProvider)
        {
            this._urlProvider = urlProvider;
        }

        public ApiClient() : this(new PairingTestUrlProvider())
        {
        }

        public string Get(string apiMethod)
        {
            var questionareCall = _urlProvider.WebApiUrl;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(questionareCall);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(apiMethod).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    return responseContent.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new Exception("Failed to get questionare.");
                }
            }
        }
    }
}