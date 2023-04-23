using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazeKart.Admin.Core.ObjectModel
{
    [DataContract]
    public partial class PaymentType
    {
        public PaymentType()
        {
        }
        
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public string Type { get; set; }
    }
}
