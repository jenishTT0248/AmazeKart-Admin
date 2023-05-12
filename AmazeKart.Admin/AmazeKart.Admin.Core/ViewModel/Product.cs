using System.ComponentModel.DataAnnotations;

namespace AmazeKart.Admin.Core.ViewModel
{
    public class Product
    {
        public Product()
        {
        }
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string SKU { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ProductName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public int SupplierId { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public int CategoryId { get; set; }
        
        [Required]
        public decimal UnitWeight { get; set; }
        
        [Required]
        public long UnitsInStock { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string DiscountType { get; set; }

        [Required]
        public decimal DiscountValue { get; set; }
        
        public bool Active { get; set; }

        public List<ProductDetail> ProductDetails { get; set; }
    }
}