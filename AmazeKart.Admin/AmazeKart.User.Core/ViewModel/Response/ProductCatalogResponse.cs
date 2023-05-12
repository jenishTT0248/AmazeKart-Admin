namespace AmazeKart.User.Core.ViewModel.Response
{
    public class ProductCatalogResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductImage { get; set; }
        public string MediaType { get; set; }
        public bool Active { get; set; }
        public Product Product { get; set; }
    }
}