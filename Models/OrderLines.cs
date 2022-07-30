using System.ComponentModel.DataAnnotations.Schema;

namespace Shipments.Models
{
    public class OrderLine
    {
        public long OrderLineId { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int ShipmentId { get; set; }
        public Shipment? Shipment { get; set; }
    }

    // public class Address
    // {
    //     public long AddressId { get; set; }
    //     public string? Company { get; set; }
    //     public string? Contact { get; set; }
    //     public string? AddressLine1 { get; set; }
    //     public string? AddressLine2 { get; set; }
    //     public string? City { get; set; }
    //     public string? State { get; set; }
    //     public string? Zip { get; set; }
    //     public string? Country { get; set; }
    //     public int OrderId { get; set; }
    //     public Shipment? Shipment { get; set; }
    // }


}

