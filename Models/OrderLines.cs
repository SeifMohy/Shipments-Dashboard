using System.ComponentModel.DataAnnotations.Schema;

namespace Shipments.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}

