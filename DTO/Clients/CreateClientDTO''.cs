using System.Collections.Generic;

namespace Sikoia.DTO.Clients
{
    public partial class CreateClientDTO
    {
        public string name { get; set; }
        public string client_type { get; set; }
        public string date_of_birth { get; set; }
        public List<string> jurisdictions { get; set; }
    }

}
