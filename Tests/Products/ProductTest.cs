using NUnit.Framework;
using RestSharp;
using Sikoia.DTO;
using Sikoia.DTO.Products;
using Sikoia.PayLoad.Products;
using Sikoia.Utils;
using System.Net;


namespace Sikoia.Tests.Products
{
    [TestFixture]
    public class ProductTest: HelperMethod<GetClientDTO>
    {

            RestResponse createProductResponse;
            RestResponse getProductResponse;
            GetProductDTO product;

            [SetUp]
            public void Init()
            {
                /* Ideally we should seed the database with a new product and use the test ID to get product
                but for the purpose of this test we will be using the create post endpoint to create a new product
                and use the ID*/

                string productEndpoint = "v1/entities/products";
                CreateProductPayload postProduct = new CreateProductPayload();

                createProductResponse = CreatePostRequest(postProduct.Body(), productEndpoint);
                product = GetContent<GetProductDTO>(createProductResponse);

                Assert.AreEqual(HttpStatusCode.Created, createProductResponse.StatusCode);
            
            }

            [Test]
            public void GetProudctById()
            {
                //Arrange
                string productEndpoint = "v1/entities/products";

                //Act
                getProductResponse = CreateGetRequest($"{productEndpoint}/{product.id}");
                GetProductDTO getContent = GetContent<GetProductDTO>(getProductResponse);

                //Assert
                Assert.AreEqual(HttpStatusCode.OK, getProductResponse.StatusCode);
                Assert.AreEqual("application/json", getProductResponse.ContentType);
                Assert.AreEqual(product.ToString(), getContent.ToString());

            }

            [TearDown]
            public void Dispose()
            {
                /* Tears down any resources used in creating the tests like the seed data. */
            }

        }
    }
