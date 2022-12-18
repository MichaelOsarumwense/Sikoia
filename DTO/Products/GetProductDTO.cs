using System;
using System.Collections.Generic;

namespace Sikoia.DTO.Products
{
    public partial class GetProductDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> jurisdictions { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public DateTime date_created { get; set; }
    }
}
