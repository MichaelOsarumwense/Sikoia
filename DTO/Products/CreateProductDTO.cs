using System.Collections.Generic;

namespace Sikoia.DTO.Products
{
    public partial class CreateProductDTO
    {
        public string name { get; set; }
        public List<string> jurisdictions { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}
