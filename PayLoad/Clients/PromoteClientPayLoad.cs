using Newtonsoft.Json;
using Sikoia.DTO.Clients;

namespace Sikoia.PayLoad.Clients
{
    public class PromoteClientPayLoad
    {
        public string Body(string client_id)
        {

            var client = new PromoteClientDTO();


            client.client_id = client_id;


            string clientObject = JsonConvert.SerializeObject(client);
            return clientObject;
        }
    }
}
