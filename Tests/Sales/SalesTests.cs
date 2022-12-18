using NUnit.Framework;
using RestSharp;
using Sikoia.DTO;
using Sikoia.DTO.Products;
using Sikoia.DTO.Sales;
using Sikoia.PayLoad.Clients;
using Sikoia.PayLoad.Products;
using Sikoia.PayLoad.Sales;
using Sikoia.Utils;
using System.Net;

namespace Sikoia.Tests.Sales
{
    [TestFixture]
    public class SalesTests: HelperMethod<GetSalesDTO>
    {
        RestResponse createClientResponse;
        RestResponse createProductResponse;
        RestResponse createSalesResponse;
        RestResponse getSalesResponse;

        GetSalesDTO sales;
        GetProductDTO product;
        GetClientDTO client;

        [SetUp]
        public void Init()
        {
            /* Flow Test - Here I aim to test the entire flow as whole like a sale exec would, hence requires no
             mocking but actually calling each endpoints as a step for the next*/

            // Create Product
            string productEndpoint = "v1/entities/products";
            CreateProductPayload postProduct = new CreateProductPayload();

            createProductResponse = CreatePostRequest(postProduct.Body(), productEndpoint);
            product = GetContent<GetProductDTO>(createProductResponse);

            Assert.AreEqual(HttpStatusCode.Created, createProductResponse.StatusCode);

            //Create Client
            string clientEndpoint = "v1/entities/clients";
            CreateClientPayload postClient = new CreateClientPayload();

            createClientResponse = CreatePostRequest(postClient.Body(null, "sales client", "active"), clientEndpoint);
            client = GetContent<GetClientDTO>(createClientResponse);

            Assert.AreEqual(HttpStatusCode.Created, createClientResponse.StatusCode);

            //Create Sale
            string salesEndpoint = "v1/entities/sales";
            CreateSalesPayload postSales = new CreateSalesPayload();

            createSalesResponse = CreatePostRequest(postSales.Body(client.id, product.id), salesEndpoint);
            sales = GetContent<GetSalesDTO>(createSalesResponse);

            Assert.AreEqual(HttpStatusCode.Created, createClientResponse.StatusCode);
        }

        [Test]
        public void GetSalesById()
        {
            //Arrange
            string salesEndpoint = "v1/entities/sales";

            //Act
            getSalesResponse = CreateGetRequest($"{salesEndpoint}/{sales.id}");
            GetSalesDTO getContent = GetContent<GetSalesDTO>(getSalesResponse);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, getSalesResponse.StatusCode);
            Assert.AreEqual("application/json", getSalesResponse.ContentType);
            Assert.AreEqual(sales.ToString(), getContent.ToString());

        }

        [TearDown]
        public void Dispose()
        {
            /* Tears down any resources used in creating the tests. */
        }
    }
}
