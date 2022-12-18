using System;

namespace Sikoia.DTO.Sales
{
    public partial class GetSalesDTO
    {
        public string id { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public string client_id { get; set; }
        public string product_id { get; set; }
        public DateTime date_created { get; set; }
    }
}
