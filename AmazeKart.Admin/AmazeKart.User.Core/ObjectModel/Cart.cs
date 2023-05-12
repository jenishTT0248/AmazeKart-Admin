using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazeKart.User.Core.ObjectModel
{
    [DataContract]
    public partial class Cart
    {
        public Cart()
        {
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int Quantity { get; set; }

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
        public virtual Customer Customer { get; set; }

        [DataMember]
        public virtual Product Product { get; set; }
    }
}