// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AkademiECommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog") { Scopes = { "CatalogFullPermission" } },
            new ApiResource("ResourceCatalogRead") { Scopes = { "CatalogReadPermission" } },
            new ApiResource("ResourceDiscount") { Scopes = { "DiscountReadPermission", "DiscountCreatePermission" } },
            new ApiResource("ResourceDiscountFull") { Scopes = { "DiscountFullPermission" } },
            new ApiResource("ResourceOrderEdit") { Scopes = { "OrderEditPermission" } },
            new ApiResource("ResourceOrderFull") { Scopes = { "OrderFullPermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","FullAuthority For Catalog Operations"),
            new ApiScope("CatalogReadPermission","Catalog Read Authority For Catalog Read Operations"),
            new ApiScope("DiscountReadPermission","Discount Read Authority For Discount Read Operations"),
            new ApiScope("DiscountCreatePermission","Discount Create Authority For Discount Create Operations"),
            new ApiScope("DiscountFullPermission","FullAuthority For Discount Operations"),
            new ApiScope("OrderEditPermission","Order Edit Authority For Order Edit Operations"),
            new ApiScope("OrderFullPermission","FullAuthority For Order Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };
        public static IEnumerable<Client> Clients => new Client[]
        {
            //visitor Client
            new Client
            {
                ClientId="ECommerceVisitorID",
                ClientName="E Commerce Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("ecommercesecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission" }
            },
            //Manager Client
             new Client
            {
                ClientId="ECommerceManagerID",
                ClientName="E Commerce Manager User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("ecommercesecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }
            },
              //Admin Client
             new Client
            {
                ClientId="ECommerceAdminID",
                ClientName="E Commerce Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("ecommercesecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "DiscountReadPermission", "DiscountCreatePermission", "DiscountFullPermission",
                 "OrderEditPermission","OrderFullPermission",IdentityServerConstants.LocalApi.ScopeName },
                 AccessTokenLifetime=600
            },


        };
    }
}