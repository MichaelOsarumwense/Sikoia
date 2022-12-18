using NUnit.Framework;
using RestSharp;
using Sikoia.DTO;
using Sikoia.DTO.Clients;
using Sikoia.PayLoad.Clients;
using Sikoia.Utils;
using System.Net;


namespace Sikoia.Tests.Clients
{
    [TestFixture]
    public class PromoteClientTest: HelperMethod<PromoteClientDTO>
    {
        RestResponse createClientResponse;
        RestResponse patchClientResponse;
        GetClientDTO client;

        [SetUp]
        public void Init()
        {
            /* Ideally we should seed the database with a new client and use the test ID to upgrade client
            but for the purpose of this test we will be using the create post endpoint to create a new 
            client and then use the ID for client upgrade*/

            string postClientEndPoint = "v1/entities/clients";

            //Create new prospect client
            CreateClientPayload postClient = new CreateClientPayload();
            createClientResponse = CreatePostRequest(postClient.Body(null, "upgraded client", "prospect"), 
                                                                      postClientEndPoint);
            client = GetContent<GetClientDTO>(createClientResponse);

            Assert.AreEqual(HttpStatusCode.Created, createClientResponse.StatusCode);
            Assert.AreEqual("prospect", client.client_type);
        }

        [Test]
        public void UpgradeClientById()
        {
            //ARRANGE
            string patchClientEndPoint = "v1/entities/clients/promote-prospect";
            PromoteClientPayLoad patchClient = new PromoteClientPayLoad();

            // Use new client ID to promote client
            patchClientResponse = CreatePatchRequest(patchClient.Body(client.id), $"{patchClientEndPoint}");
            GetClientDTO patchContent = GetContent<GetClientDTO>(patchClientResponse);

            //ASSERT
            Assert.AreEqual(HttpStatusCode.OK, patchClientResponse.StatusCode);
            Assert.AreEqual(client.id, patchContent.id);
            Assert.AreEqual("active", patchContent.client_type);
            Assert.AreEqual("application/json", patchClientResponse.ContentType);
        }

        [TearDown]
        public void Dispose()
        {
            /* Tears down any resources used in creating the tests. */
        }
    }
}
