namespace AmazeKart.Admin.Core.ViewModel
{
    public class Category
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}