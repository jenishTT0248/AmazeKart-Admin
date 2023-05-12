using System.ComponentModel.DataAnnotations;

namespace AmazeKart.User.Core.ViewModel
{
    public class PaymentDetail
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public decimal Amount { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Status { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}