namespace AkademiECommerce.Web.Models
{
    public class ClientSettings
    {
        public Client coremvcclient { get; set;}
        public Client coremvcclientforuser { get; set;}
    }
    public class Client { 
        public string ClientId { get; set;}
        public string ClientSecret { get; set;}
    }

}
