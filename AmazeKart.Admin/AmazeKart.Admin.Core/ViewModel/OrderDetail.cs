using System.ComponentModel.DataAnnotations;

namespace AmazeKart.Admin.Core.ViewModel
{
    public class OrderDetail
    {
        [Range(1, int.MaxValue)]
        public int OrderId { get; set; }

        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }
        
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal OrderAmount { get; set; }        
    }
}