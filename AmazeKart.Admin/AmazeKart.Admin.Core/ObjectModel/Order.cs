using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazeKart.Admin.Core.ObjectModel
{
    [DataContract]
    public partial class Order
    {
        public Order()
        {
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [DataMember]
        public string OrderNumber { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public decimal GrossAmount { get; set; }
        [DataMember]
        public decimal GrossDiscountAmount { get; set; }
        [DataMember]
        public decimal NetAmount { get; set; }
        [DataMember]
        public string OrderStatus { get; set; }
        [DataMember]
        public string ShippingDate { get; set; }
        [DataMember]
        public string DelieveredDate { get; set; }
        [DataMember]
        public int PaymentId { get; set; }
        [DataMember]
        public string TransactionReferenceNumber { get; set; }
        [DataMember]
        public virtual Customer Customer { get; set; }
        [DataMember]
        public virtual PaymentType PaymentType { get; set; }
    }
}