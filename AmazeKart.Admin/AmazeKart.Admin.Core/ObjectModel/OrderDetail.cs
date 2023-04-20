using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazeKart.Admin.Core.ObjectModel
{
    [DataContract]
    public partial class OrderDetail
    {
        public OrderDetail()
        {
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public virtual Product Product { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public decimal Discount { get; set; }
        [DataMember]
        public decimal OrderAmount { get; set; }
    }
}