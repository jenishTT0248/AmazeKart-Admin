using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazeKart.User.Core.ObjectModel
{
    [DataContract]
    public partial class PaymentDetail
    {
        public PaymentDetail()
        {
        }
        
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public string Status { get; set; }

        private DateTime _createdDate;

        [DataMember]
        public DateTime CreatedDate
        {
            get
            {
                return _createdDate == DateTime.MinValue ? DateTime.UtcNow : _createdDate;
            }
            set
            {
                this._createdDate = value;
            }
        }

        [DataMember]
        public virtual Order Order { get; set; }
    }
}
