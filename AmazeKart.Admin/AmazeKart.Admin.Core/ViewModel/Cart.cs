namespace AmazeKart.Admin.Core.ViewModel
{
    public class Cart
    {
        public Cart()
        {
        }
        
        public int Id { get; set; }                
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }        
    }
}