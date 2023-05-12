using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazeKart.User.Core.ObjectModel
{
    [DataContract]
    public partial class ProductCatalog
    {
        public ProductCatalog()
        {
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductImage { get; set; }

        [DataMember]
        public string MediaType { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public virtual Product Product { get; set; }
    }
}