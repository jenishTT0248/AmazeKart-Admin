using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazeKart.Admin.Core.ObjectModel
{
    [DataContract]
    public partial class Product
    {
        public Product()
        {
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [DataMember]
        public string SKU { get; set; }

        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int SupplierId { get; set; }
        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string Size { get; set; }

        [DataMember]
        public string Color { get; set; }

        [DataMember]
        public string UnitWeight { get; set; }

        [DataMember]
        public string UnitsInStock { get; set; }

        [DataMember]
        public string DiscountType { get; set; }

        [DataMember]
        public decimal DiscountValue { get; set; }

        [DataMember]
        public virtual Supplier Supplier { get; set; }

        [DataMember]
        public virtual Category Category { get; set; }
    }
}