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
        private readonly IApiClient _apiClient;

        public QuestionnaireManager(IApiClient apiClient)
        {
            this._apiClient = apiClient;
        }

        public QuestionnaireManager() : this(new ApiClient())
        {
        }

        public string GetQuestionare()
        {
            return this._apiClient.Get("/api/Questions");
        }
    }
}