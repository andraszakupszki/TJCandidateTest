using System.Web.Mvc;
using PairingTest.Web.Models;
using PairingTest.Web.Domain.Interfaces;
using PairingTest.Web.Domain.Core;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireManager _questionnaireManager;

        public QuestionnaireController(IQuestionnaireManager questionnaireManager)
        {
            this._questionnaireManager = questionnaireManager;
        }

        public QuestionnaireController() : this(new QuestionnaireManager())
        {
        }

        /* ASYNC ACTION METHOD... IF REQUIRED... */
        //        public async Task<ViewResult> Index()
        //        {
        //        }

        public ViewResult Index()
        {
            try
            {
                var questionare = JsonConvert.DeserializeObject<QuestionnaireViewModel>(_questionnaireManager.GetQuestionare());
                return View(questionare);
            }
            catch (Exception e)
            {
                TempData["message"] = e.Message;
                return View(new QuestionnaireViewModel());
            }

            TempData["message"] = "Something went wrong. Please try again";
            return View(new QuestionnaireViewModel());
        }


        //public async Task<ViewResult> IndexAsync()
        //{
        //    var questionareCall = _urlProvider.WebApiUrl;

        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(questionareCall);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            var response = await client.GetAsync("/api/Questions");
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var questionare = await response.Content.ReadAsAsync<dynamic>();
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        TempData["message"] = e.Message;
        //        return View(new QuestionnaireViewModel());
        //    }

        //    TempData["message"] = "Something went wrong. Please try again";
        //    return View(new QuestionnaireViewModel());
        //}
    }
}
