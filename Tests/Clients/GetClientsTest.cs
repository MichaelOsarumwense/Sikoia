using NUnit.Framework;
using RestSharp;
using Sikoia.DTO;
using Sikoia.PayLoad.Clients;
using Sikoia.Utils;
using System.Net;

namespace Sikoia.Tests.Clients
{
    [TestFixture]
    public class GetClientsTest: HelperMethod<GetClientDTO>
    {
        RestResponse response;
        RestResponse createClientResponse;

        GetClientDTO client;

        [SetUp]
        public void Init()
        {
            /* Ideally we should seed the database with a new client and use the test ID to get client
            but for the purpose of this test we will be using the create post endpoint to create a new 
            client and then use the ID get client*/

            string postClientEndPoint = "v1/entities/clients";
            CreateClientPayload postClient = new CreateClientPayload();

            //Create new prospect client
            createClientResponse = CreatePostRequest(postClient.Body(), postClientEndPoint);
            client = GetContent<GetClientDTO>(createClientResponse);

            Assert.AreEqual(HttpStatusCode.Created, createClientResponse.StatusCode);
        }

        [Test]
        public void GetClientById()
        {
            //ARRANGE
            string path = "v1/entities/clients/";

            //ACT
            response = CreateGetRequest($"{path}{client.id}");
            GetClientDTO getClient = GetContent<GetClientDTO>(response);

            //ASSERT
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(client.ToString(), getClient.ToString());
            Assert.AreEqual("application/json", response.ContentType);
        }

        [TearDown]
        public void Dispose()
        {
            /* Tears down any resources used in creating the tests. */
        }
    }
}
