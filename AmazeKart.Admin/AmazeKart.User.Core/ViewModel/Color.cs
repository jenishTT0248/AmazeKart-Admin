using System.ComponentModel.DataAnnotations;

namespace AmazeKart.User.Core.ViewModel
{
    public class Color
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ColorName { get; set; }

        public bool Active { get; set; }
    }
}