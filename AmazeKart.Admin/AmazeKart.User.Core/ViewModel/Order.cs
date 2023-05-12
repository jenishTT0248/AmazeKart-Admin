using System.ComponentModel.DataAnnotations;

namespace AmazeKart.User.Core.ViewModel
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string OrderNumber { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public DateTime OrderDate { get; set; }
        
        public int CustomerId { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public decimal GrossAmount { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public decimal GrossDiscountAmount { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public decimal NetAmount { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string OrderStatus { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ShippingDate { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string DelieveredDate { get; set; }
        
        public int PaymentId { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string TransactionReferenceNumber { get; set; }        
    }
}