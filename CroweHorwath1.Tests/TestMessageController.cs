using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CroweHorwath1.Controllers;
using CroweHorwath1.Models;

namespace CroweHorwath1.Tests
{
    [TestClass]
    public class TestMessageController
    {
        [TestMethod]
        public void GetMessage_ShouldReturnHelloWorld()
        {
            var testMessages = GetTestMessages();
            var controller = new MessageController(testMessages[0]);
            var actionResult = controller.GetMessages();
            var contentResult = actionResult as OkNegotiatedContentResult<Message>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(testMessages[0], contentResult.Content);
        }
        [TestMethod]
        public void GetAllMessages_ShouldReturnAllMessages()
        {
            var testMessages = GetTestMessages();
            var controller = new MessageDBController(testMessages);

            var actionResult = controller.GetMessages();
            var contentResult = actionResult as OkNegotiatedContentResult<List<Message>>;
            Assert.AreEqual(testMessages.Count, contentResult.Content.Count);
        }

        [TestMethod]
        public void GetMessage_ShouldReturnCorrectMessage()
        {
            var testMessages = GetTestMessages();
            var controller = new MessageDBController(testMessages);

            var actionResult = controller.GetMessage(2);
            var contentResult = actionResult as OkNegotiatedContentResult<Message>;

            Assert.IsNotNull(contentResult);
            Assert.AreEqual(testMessages[2], contentResult.Content);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new MessageDBController();

            var result = controller.GetMessage(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Message> GetTestMessages()
        {
            var testMessages = new List<Message>();
            testMessages.Add(new Message { Id = 0, TextToDisplay = "Hello World" });
            testMessages.Add(new Message { Id = 1, TextToDisplay = "Hello World1"});
            testMessages.Add(new Message { Id = 2, TextToDisplay = "Hello World2" });
            testMessages.Add(new Message { Id = 3, TextToDisplay = "Hello World3" });
            testMessages.Add(new Message { Id = 4, TextToDisplay = "Hello World4" });

            return testMessages;
        }
    }
}
