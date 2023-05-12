namespace AmazeKart.User.Core.ViewModel
{
    public class ProductDetail
    {
        public ProductDetail()
        {
        }

        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public bool Active { get; set; }
    }
}