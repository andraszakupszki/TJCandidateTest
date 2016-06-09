using NUnit.Framework;
using PairingTest.Unit.Tests.Web.Stubs;
using PairingTest.Web.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireManagerTests
    {
        [Test]
        public void ShouldGetStringBack()
        {
            //Arrange
            var expectedResponse = "My expected string";
            var fakeApiClient = new FakeApiClient(expectedResponse);
            var questionnaireManager = new QuestionnaireManager(fakeApiClient);

            //Act
            var result = questionnaireManager.GetQuestionare();

            //Assert
            Assert.That(result, Is.EqualTo(expectedResponse));
        }
    }
}
