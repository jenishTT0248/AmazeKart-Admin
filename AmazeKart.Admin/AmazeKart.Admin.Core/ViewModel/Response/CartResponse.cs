namespace AmazeKart.Admin.Core.ViewModel.Response
{
    public class CartResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
