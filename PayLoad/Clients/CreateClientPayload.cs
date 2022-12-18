using Newtonsoft.Json;
using Sikoia.DTO.Clients;
using System.Collections.Generic;


namespace Sikoia.PayLoad.Clients
{
    public  class CreateClientPayload
    {
       
        public  string Body(List<string> jurisdictions = null, string name = "Cliente", string client_type = "active", string date_of_birth = "1993-12-15")
        {
            List<string> alt = new List<string> { "de", "nl", "uk"};

            if (jurisdictions == null)
            {
                jurisdictions = alt;
            }

            var client = new CreateClientDTO();

            client.name = name;
            client.client_type = client_type;
            client.date_of_birth = date_of_birth;
            client.jurisdictions = jurisdictions;

            string clientObject = JsonConvert.SerializeObject(client);
            return clientObject;
        }
    }
}
