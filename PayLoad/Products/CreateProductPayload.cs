using Newtonsoft.Json;
using Sikoia.DTO.Products;
using System.Collections.Generic;

namespace Sikoia.PayLoad.Products
{
    public class CreateProductPayload
    {
        public string Body(List<string> jurisdictions = null, string name = "sikoia", double price = 200, string description = "new item")
        {
            List<string> alt = new List<string> { "de", "nl", "uk" };

            if (jurisdictions == null)
            {
                jurisdictions = alt;
            }

            var client = new CreateProductDTO();

            client.description = description;
            client.name = name;
            client.price = price;
            client.jurisdictions = jurisdictions;

            string clientObject = JsonConvert.SerializeObject(client);
            return clientObject;
        }
    }
}
