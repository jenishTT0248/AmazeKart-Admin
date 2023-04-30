
using System.ComponentModel.DataAnnotations;

namespace AmazeKart.Admin.Core.ViewModel
{
    public class Supplier
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string CompanyName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ContactFirstName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ContactLastName { get; set; }
        
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
        public string Phone { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        
        public bool Active { get; set; }
    }
}