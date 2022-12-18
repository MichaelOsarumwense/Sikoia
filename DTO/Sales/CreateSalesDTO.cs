namespace Sikoia.DTO.Sales
{
    public partial class CreateSalesDTO
    {
        public string description { get; set; }
        public int quantity { get; set; }
        public string client_id { get; set; }
        public string product_id { get; set; }
    }
}
