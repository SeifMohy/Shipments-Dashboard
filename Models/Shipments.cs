using System.ComponentModel.DataAnnotations.Schema;

namespace Shipments.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string? OrderDate { get; set; }
        public string Status { get; set; } = "Entered";
        public int? ShipperReference { get; set; }
        public int? ShipmentNumb { get; set; }
        public bool Checked { get; set; } = false;
        public List<OrderLine>? OrderLines { get; set; }
        public string? ShipFrom { get; set; }
        public string? ShipTo { get; set; }

        // public Address? Address { get; set; }
    }


}