using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazeKart.Admin.Core.ObjectModel
{
    [DataContract]
    public partial class Customer
    {
        public Customer()
        {
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string BillingAddress { get; set; }
        [DataMember]
        public string BillingCity { get; set; }
        [DataMember]
        public string BillingState { get; set; }
        [DataMember]
        public string BillingPostalCode { get; set; }
        [DataMember]
        public string BillingCountry { get; set; }
        [DataMember]
        public string ShipAddress { get; set; }
        [DataMember]
        public string ShipCity { get; set; }
        [DataMember]
        public string ShipState { get; set; }
        [DataMember]
        public string ShipPostalCode { get; set; }
        [DataMember]
        public string ShipCountry { get; set; }

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
        public bool Active { get; set; }
    }
}