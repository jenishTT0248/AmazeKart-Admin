using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazeKart.Admin.Core.ObjectModel
{
    [DataContract]
    public partial class Size
    {
        public Size()
        {
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        public string SizeName { get; set; }

        [DataMember]
        public bool Active { get; set; }
    }
}
