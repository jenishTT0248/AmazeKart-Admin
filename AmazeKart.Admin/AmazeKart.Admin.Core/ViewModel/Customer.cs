using System.ComponentModel.DataAnnotations;

namespace AmazeKart.Admin.Core.ViewModel
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Phone { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Address1 { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Address2 { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string State { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string PostalCode { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Country { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string BillingAddress { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string BillingCity { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string BillingState { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string BillingPostalCode { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string BillingCountry { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ShipAddress { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ShipCity { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ShipState { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ShipPostalCode { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ShipCountry { get; set; }        

        private DateTime _createdDate;
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
        public bool Active { get; set; }
    }
}