// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Ecommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("Catalog_FullPermision"){Scopes={"Catalog_FullPermision"}},
                new ApiResource("Basket_FullPermision"){Scopes={"Basket_FullPermision"}},
                   new ApiResource("Discount_FullPermision"){Scopes={"Discount_FullPermision"}},
                     new ApiResource("Order_FullPermision"){Scopes={"Order_FullPermision"}},
                        new ApiResource("Payment_FullPermision"){Scopes={"Payment_FullPermision"}},
                            new ApiResource("PhotoStock_FullPermision"){Scopes={"PhotoStock_FullPermision"}},
                                new ApiResource("Gateway_FullPermision"){Scopes={"Gateway_FullPermision"}},
                                    new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("Catalog_FullPermision","CatalogApi için full erişim"),
                    new ApiScope("Basket_FullPermision", "SepetApi için full erişim"),
                        new ApiScope("Discount_FullPermision", "İndirimApi için full erişim"),
                            new ApiScope("Order_FullPermision", "SiparişApi için full erişim"),
                                new ApiScope("Payment_FullPermision", "ÖdemeApi için full erişim"),
                                    new ApiScope("PhotoStock_FullPermision", "FotoğrafApi için full erişim"),
                                        new ApiScope("Gateway_FullPermision", "GatewayApi için full erişim"),
                                            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "coremvcclient",
                    ClientName = "ASP.Net Core",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedScopes = { "Catalog_FullPermision", "PhotoStock_FullPermision", IdentityServerConstants.LocalApi.ScopeName }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "coremvcclientforuser",
                    ClientName= "ASP.Net Core",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                },
            };
    }
}