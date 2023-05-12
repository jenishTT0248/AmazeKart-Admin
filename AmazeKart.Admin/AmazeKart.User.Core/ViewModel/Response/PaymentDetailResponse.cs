namespace AmazeKart.User.Core.ViewModel.Response
{
    public class PaymentDetailResponse
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Order Order { get; set; }
    }
}