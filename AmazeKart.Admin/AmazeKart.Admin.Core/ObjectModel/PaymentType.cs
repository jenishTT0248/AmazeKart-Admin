using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        public int PaymentId { get; set; }

        [DataMember]
        public string Type { get; set; }
    }
}
