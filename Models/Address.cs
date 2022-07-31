using System.ComponentModel.DataAnnotations.Schema;

namespace Shipments.Models
{

    public class Address
    {
        public int AddressId { get; set; }
        public string? Company { get; set; }
        public string? Contact { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Country { get; set; }
    }


}

