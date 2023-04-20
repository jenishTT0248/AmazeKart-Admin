using Microsoft.EntityFrameworkCore;

namespace AmazeKart.Admin.Core.ObjectModel
{
    public partial class AmazeKartDB : DbContext
    {
        public string connectionString;

        public AmazeKartDB(DbContextOptions<AmazeKartDB> dbContextOptions)
              : base(dbContextOptions)
        {
        }

        #region AmazeKart
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<ProductCatalog> ProductCatalogs { get; set; }
        #endregion
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer();
        //}
    }
}