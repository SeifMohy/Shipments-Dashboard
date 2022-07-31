using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Shipments.Models
{
    public class ShipmentsContext : DbContext
    {
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public ShipmentsContext(DbContextOptions<ShipmentsContext> options)
            : base(options)
        {
        }
    }
}
