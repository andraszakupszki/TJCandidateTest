using NUnit.Framework;
using PairingTest.Unit.Tests.Web.Stubs;
using PairingTest.Web.Controllers;
using PairingTest.Web.Domain.Core;
using PairingTest.Web.Models;
using System.Collections.Generic;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "My expected quesitons";
            var expectedQuestions = new List<string> { "Question 1?", "Question 2?" };
            var fakeQuestionnaireManager = new FakeQuestionnaireManager(expectedTitle, expectedQuestions);
            var questionnaireController = new QuestionnaireController(fakeQuestionnaireManager);

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;
            
            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void ShouldGetRightNumberOfQuestions()
        {
            //Arrange
            var expectedTitle = "My expected quesitons";
            var expectedQuestions = new List<string> { "Question 1?", "Question 2?" };
            var fakeQuestionnaireManager = new FakeQuestionnaireManager(expectedTitle, expectedQuestions);
            var questionnaireController = new QuestionnaireController(fakeQuestionnaireManager);

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;

            //Assert
            Assert.That(result.QuestionsText.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldGetRightOfQuestion()
        {
            //Arrange
            var expectedTitle = "My expected quesitons";
            var expectedQuestions = new List<string> { "Question 1?" };
            var fakeQuestionnaireManager = new FakeQuestionnaireManager(expectedTitle, expectedQuestions);
            var questionnaireController = new QuestionnaireController(fakeQuestionnaireManager);

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;

            //Assert
            Assert.That(result.QuestionsText, Is.EqualTo(expectedQuestions));
        }
    }
}