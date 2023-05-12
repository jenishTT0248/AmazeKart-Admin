using System.ComponentModel.DataAnnotations;

namespace AmazeKart.User.Core.ViewModel
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string CategoryName { get; set; }
        
        public string? Description { get; set; }
        public bool Active { get; set; }
    }
}