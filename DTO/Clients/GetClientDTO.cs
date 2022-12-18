using System.Collections.Generic;

namespace Sikoia.DTO
{
    public partial class GetClientDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string client_type { get; set; }
        public string date_of_birth { get; set; }
        public List<string> jurisdictions { get; set; }
    }
}
