namespace AmazeKart.Admin.Core.ObjectModel
{
    using Microsoft.EntityFrameworkCore;

    public partial class AmazeKartDB : DbContext
    {
        //public string connectionString;

        public AmazeKartDB(DbContextOptions<AmazeKartDB> dbContextOptions)
              : base(dbContextOptions)
        {
        }

        #region AmazeKart

        //public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<Order> Orders { get; set; }
        //public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        //public virtual DbSet<Product> Products { get; set; }
        //public virtual DbSet<Supplier> Suppliers { get; set; }
        //public virtual DbSet<ProductCatalog> ProductCatalogs { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentType>().HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer(_options.Value.ConnectionString, options => options.EnableRetryOnFailure());

            builder.UseSqlServer("Persist Security Info = True; Integrated Security = true; Initial Catalog = AmazeKart; server = .\\SQLEXPRESS;TrustServerCertificate=Yes;", options => options.EnableRetryOnFailure());
        }

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