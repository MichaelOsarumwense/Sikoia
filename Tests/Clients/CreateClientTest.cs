using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Sikoia.DTO;
using Sikoia.PayLoad.Clients;
using Sikoia.Utils;
using System.Net;

namespace Sikoia.Tests.Clients
{
    [TestClass]
    public class CreateClientTest : HelperMethod<GetClientDTO>
    {
        RestResponse response;

        [TestMethod]
        public void CreateClient()
        {
            //ARRANGE
            string path = "v1/entities/clients";
            CreateClientPayload client = new CreateClientPayload();

            //ACT
            response = CreatePostRequest(client.Body(), path);
            GetClientDTO content = GetContent<GetClientDTO>(response);

            // ASSERT
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual("1993-12-15", content.date_of_birth);
            Assert.AreEqual("Cliente", content.name);
            Assert.AreEqual("active", content.client_type);
            Assert.AreEqual("de", content.jurisdictions[0]);
            Assert.IsNotNull(content.id);
            Assert.AreEqual("application/json", response.ContentType);
            
        }
    }
}
