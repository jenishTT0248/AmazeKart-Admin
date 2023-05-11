namespace AmazeKart.Admin.Core.ObjectModel
{
    using Microsoft.EntityFrameworkCore;
    public partial class AmazeKartDB : DbContext
    {
        public AmazeKartDB(DbContextOptions<AmazeKartDB> dbContextOptions)
              : base(dbContextOptions)
        {
        }

        #region AmazeKart
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<ProductCatalog> ProductCatalogs { get; set; }
        public virtual DbSet<Cart> CartDetails { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Order>().HasKey(c => c.Id);

            modelBuilder.Entity<OrderDetail>().HasKey(c => c.OrderId);
            modelBuilder.Entity<OrderDetail>().HasKey(c => c.ProductId);

            modelBuilder.Entity<PaymentDetail>().HasKey(c => c.Id);
            modelBuilder.Entity<Product>().HasKey(c => c.Id);
            modelBuilder.Entity<ProductDetail>().HasKey(c => c.Id);
            modelBuilder.Entity<Supplier>().HasKey(c => c.Id);
            modelBuilder.Entity<ProductCatalog>().HasKey(c => c.Id);

            modelBuilder.Entity<Cart>().HasKey(c => c.Id);
            modelBuilder.Entity<Size>().HasKey(c => c.Id);
            modelBuilder.Entity<Color>().HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Persist Security Info = True; Integrated Security = true; Initial Catalog = AmazeKart; server = .\\SQLEXPRESS;TrustServerCertificate=Yes;", options => options.EnableRetryOnFailure());
        }                         
    }
}