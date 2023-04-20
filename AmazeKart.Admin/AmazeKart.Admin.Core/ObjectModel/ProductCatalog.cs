using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazeKart.Admin.Core.ObjectModel
{
    [DataContract]
    public partial class ProductCatalog
    {
        public ProductCatalog()
        {
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CatalogId { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public virtual Product Product { get; set; }

        [DataMember]
        public string ProductImage { get; set; }
        [DataMember]
        public string MediaType { get; set; }
    }
}