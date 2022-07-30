using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace Shipments.Models
{
    public class ShipmentsContext : DbContext
    {
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLine>()
                .HasOne(b => b.Shipment)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(p => p.ShipmentId)
                .HasPrincipalKey(c => c.OrderId);

        }
        public ShipmentsContext(DbContextOptions<ShipmentsContext> options)
            : base(options)
        {
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // configures one-to-many relationship
        //     modelBuilder.Entity<Shipment>()
        //         .HasRequired<OrderLine>(s => s.CurrentGrade)
        //         .WithMany(g => g.Students)
        //         .HasForeignKey<int>(s => s.ShipmentId);
        // }
    }
    // static void CreateData()
    // {
    //     Shipment S1 = new Shipment { OrderId = 1, OrderDate = "11/12/2022", ShipFrom = "Company, Contact, Address Line 1, Address Line 2, City, State, Zip, Country", ShipTo = "Company, Contact, Address Line 1, Address Line 2, City, State, Zip, Country" };
    //     Shipment S2 = new Shipment { OrderId = 2, OrderDate = "11/12/2022", ShipFrom = "Company, Contact, Address Line 1, Address Line 2, City, State, Zip, Country", ShipTo = "Company, Contact, Address Line 1, Address Line 2, City, State, Zip, Country" };
    //     Shipment S3 = new Shipment { OrderId = 3, OrderDate = "11/12/2022", ShipFrom = "Company, Contact, Address Line 1, Address Line 2, City, State, Zip, Country", ShipTo = "Company, Contact, Address Line 1, Address Line 2, City, State, Zip, Country" };

    //     OrderLine O1 = new OrderLine { Description = "order 1", Quantity = 1, Shipment = S1 };
    // }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Shipment>(entity => { entity.Property(e => e.Id).IsRequired(); });

    //     #region ShipmentSeed
    //     modelBuilder.Entity<Shipment>().HasData(new Shipment { OrderId = 1, OrderDate = "11/12/2022", ShipFrom = "Company, Contact, Address Line 1, Address Line 2, City, State, Zip, Country", ShipTo = "Company, Contact, Address Line 1, Address Line 2, City, State, Zip, Country" });
    //     #endregion



    // modelBuilder.Entity<Post>(
    //     entity =>
    //     {
    //         entity.HasOne(d => d.Blog)
    //             .WithMany(p => p.Posts)
    //             .HasForeignKey("BlogId");
    //     });

    // #region PostSeed
    // modelBuilder.Entity<Post>().HasData(
    //     new Post { BlogId = 1, PostId = 1, Title = "First post", Content = "Test 1" });
    // #endregion

    // #region AnonymousPostSeed
    // modelBuilder.Entity<Post>().HasData(
    //     new { BlogId = 1, PostId = 2, Title = "Second post", Content = "Test 2" });
    // #endregion

    // #region OwnedTypeSeed
    // modelBuilder.Entity<Post>().OwnsOne(p => p.AuthorName).HasData(
    //     new { PostId = 1, First = "Andriy", Last = "Svyryd" },
    //     new { PostId = 2, First = "Diego", Last = "Vega" });
    // #endregion
    // }

}
