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
            new ApiResource("resource_Catalog"){Scopes={"Catalog_FullPermision"}},
                   new ApiResource("resource_Basket"){Scopes={"Basket_FullPermision"}},
                      new ApiResource("resource_Discount"){Scopes={"Discount_FullPermision"}},
                //     new ApiResource("resource_Order"){Scopes={"Order_FullPermision"}},
                //        new ApiResource("resource_Payment"){Scopes={"Payment_FullPermision"}},
                               new ApiResource("resource_PhotoStock"){Scopes={"PhotoStock_FullPermision"}},
                //                new ApiResource("resource_Gateway"){Scopes={"Gateway_FullPermision"}},
                                    new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),//sub 
                new IdentityResources.Profile(),
                new IdentityResources.Email()
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("Catalog_FullPermision","CatalogApi için full erişim"),
                    new ApiScope("Basket_FullPermision", "SepetApi için full erişim"),
                        new ApiScope("Discount_FullPermision", "İndirimApi için full erişim"),
                    //        new ApiScope("Order_FullPermision", "SiparişApi için full erişim"),
                    //            new ApiScope("Payment_FullPermision", "ÖdemeApi için full erişim"),
                                      new ApiScope("PhotoStock_FullPermision", "FotoğrafApi için full erişim"),
                    //                    new ApiScope("Gateway_FullPermision", "GatewayApi için full erişim"),
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

                    AllowedScopes = { "Catalog_FullPermision","PhotoStock_FullPermision", IdentityServerConstants.LocalApi.ScopeName }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "coremvcclientforuser",
                    ClientName= "ASP.Net Core",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowOfflineAccess=true,
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = { "Catalog_FullPermision", "Basket_FullPermision", "Discount_FullPermision",IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.StandardScopes.OfflineAccess, IdentityServerConstants.LocalApi.ScopeName },
                    AccessTokenLifetime=300

                },
            };
    }
}