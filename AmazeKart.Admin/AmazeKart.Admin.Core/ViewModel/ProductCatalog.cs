using System.ComponentModel.DataAnnotations;

namespace AmazeKart.Admin.Core.ViewModel
{
    public  class ProductCatalog
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public int ProductId { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ProductImage { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string MediaType { get; set; }
        public bool Active { get; set; }        
    }
}