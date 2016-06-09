using PairingTest.Web.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace PairingTest.Web.Domain.Core
{
    public class QuestionnaireManager : IQuestionnaireManager
    {
        private readonly IPairingTestUrlProvider _urlProvider;

        public QuestionnaireManager(IPairingTestUrlProvider urlProvider)
        {
            this._urlProvider = urlProvider;
        }

        public QuestionnaireManager() : this(new PairingTestUrlProvider())
        {
        }

        public string GetQuestionare()
        {
            var questionareCall = _urlProvider.WebApiUrl;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(questionareCall);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("/api/Questions").Result;
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