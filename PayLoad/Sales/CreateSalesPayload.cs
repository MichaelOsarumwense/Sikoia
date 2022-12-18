using Newtonsoft.Json;
using Sikoia.DTO.Sales;
using System.Collections.Generic;

namespace Sikoia.PayLoad.Sales
{
    public class CreateSalesPayload
    {
        public string Body(string client_id, string product_id, string description = "new sales Item", int quantity = 5)
        {

            var sales = new CreateSalesDTO();

            sales.client_id = client_id;
            sales.description = description;
            sales.product_id = product_id;
            sales.quantity = quantity;

            string clientObject = JsonConvert.SerializeObject(sales);
            return clientObject;
        }
    }
}
