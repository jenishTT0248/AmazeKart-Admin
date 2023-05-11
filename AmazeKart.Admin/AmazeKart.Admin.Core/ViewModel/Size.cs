using System.ComponentModel.DataAnnotations;

namespace AmazeKart.Admin.Core.ViewModel
{
    public class Size
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string SizeName { get; set; }
        
        public bool Active { get; set; }
    }
}