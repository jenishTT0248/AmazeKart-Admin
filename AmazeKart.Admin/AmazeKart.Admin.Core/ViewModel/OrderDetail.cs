using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.ViewModel
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal OrderAmount { get; set; }
        public Product Product { get; set; }
    }
}