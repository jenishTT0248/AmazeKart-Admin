namespace AmazeKart.Admin.Core.ViewModel.Response
{
    public class ProductResponse
    {
        public ProductResponse()
        {                
        }

        public int Id { get; set; }
        
        public string SKU { get; set; }
        
        public string ProductName { get; set; }
        
        public int SupplierId { get; set; }
        
        public int CategoryId { get; set; }
        
        public string Size { get; set; }
        
        public string Color { get; set; }
        
        public decimal UnitWeight { get; set; }
        
        public long UnitsInStock { get; set; }
        
        public string DiscountType { get; set; }
        
        public decimal DiscountValue { get; set; }

        public bool Active { get; set; }

        public Supplier Supplier { get; set; }

        public Category Category { get; set; }
    }
}