using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Net;

namespace Sikoia.Utils
{
    public class HelperMethod<T1>
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseUrl = "https://interview-srv4586rt.sikoia.com/";
        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            var restClient = new RestClient(url);
            return restClient;

        }
        public RestResponse CreatePostRequest(string payload, string endpoint)
        {
            var restRequest = new RestRequest();
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody(payload);
            var response = SetUrl(endpoint).Post(restRequest);
            return response;
        }

        public RestResponse CreatePatchRequest(string payload, string endpoint)
        {
            var restRequest = new RestRequest();
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody(payload);
            var response = SetUrl(endpoint).Patch(restRequest);
            return response;
        }

        public RestResponse CreateGetRequest(string endpoint)
        {
            var restRequest = new RestRequest();
            restRequest.AddHeader("Accept", "application/json");
            var response = SetUrl(endpoint).Get(restRequest);
            return response;

        }

        public RestRequest CreateDeleteRequest(string endpoint)
        {
            var restRequest = new RestRequest();
            restRequest.AddHeader("Accept", "application/json");
            var response = SetUrl(endpoint).Delete(restRequest);
            return restRequest;
        }

        public DTO GetContent<DTO>(RestResponse response)
        {
            var content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }
    }
}
