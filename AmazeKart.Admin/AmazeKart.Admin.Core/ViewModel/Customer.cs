namespace AmazeKart.Admin.Core.ViewModel
{
    public class Customer
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingCountry { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipPostalCode { get; set; }
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