using NUnit.Framework;
using PingYourPackage.API.MessageHandler;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PingYourPackage.API.Test.MessageHandlers
{
    [TestFixture]
    public class RequireHttpsMessageHandlerTest
    {
        [Test]
        public async Task Returns_Forbidden_If_Request_Is_Not_Over_HTTPS()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080");
            var requireHttpsMessageHandler = new RequireHttpsMessageHandler();
            
            // Act
            var response = await requireHttpsMessageHandler.InvokeAsync(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Test]
        public async Task Returns_Delegated_StatusCode_When_Request_Is_Over_HTTPS()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:8080");
            var requireHttpsMessageHandler=new RequireHttpsMessageHandler();

            // Act
            var response = await requireHttpsMessageHandler.InvokeAsync(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
