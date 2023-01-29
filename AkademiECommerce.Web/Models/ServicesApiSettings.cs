namespace AkademiECommerce.Web.Models
{
    public class ServicesApiSettings
    {
        public string IdentityBaseURL { get; set; }
        public string GatewayBaseURL { get; set; }
        public string PhotoStockURL { get; set; }
        public ServicesApi Catalog { get; set; }
    }
    public class ServicesApi { public string Path { get; set; } }
}
