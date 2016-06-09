using PairingTest.Web.Domain.Interfaces;
using QuestionServiceWebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PairingTest.Unit.Tests.Web.Stubs
{
    public class FakeQuestionnaireManager : IQuestionnaireManager
    {
        public FakeQuestionnaireManager() {}

        public FakeQuestionnaireManager(string questionnaireTitle, IList<string> questions)
        {
            this.QuestionnaireTitle = questionnaireTitle;
            this.Questions = questions;
        }

        public string QuestionnaireTitle { get; set;}

        public IList<string> Questions { get; set; }

        public string GetQuestionare()
        {
            return JsonConvert.SerializeObject(new Questionnaire { QuestionnaireTitle = QuestionnaireTitle, QuestionsText = Questions });
        }
    }
}
