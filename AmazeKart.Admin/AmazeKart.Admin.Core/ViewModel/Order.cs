namespace AmazeKart.Admin.Core.ViewModel
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal GrossDiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string OrderStatus { get; set; }
        public string ShippingDate { get; set; }
        public string DelieveredDate { get; set; }
        public int PaymentId { get; set; }
        public string TransactionReferenceNumber { get; set; }
        public Customer Customer { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}