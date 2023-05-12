using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazeKart.User.Core.ObjectModel
{
    [DataContract]
    public partial class ProductDetail
    {
        public ProductDetail()
        {
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int SizeId { get; set; }

        [DataMember]
        public int ColorId { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public virtual Product Product { get; set; }

        [DataMember]
        public virtual Size Size { get; set; }

        [DataMember]
        public virtual Color Color { get; set; }
    }
}