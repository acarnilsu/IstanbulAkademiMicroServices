namespace AkademiECommerce.Services.Catalog.Dtos
{
    public class ProductUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public string CategoryID { get; set; }
    }
}
