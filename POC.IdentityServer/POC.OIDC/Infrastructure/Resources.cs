﻿using IdentityServer4.Models;

namespace POC.IdentityServer.Infrastructure
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "weatherApi",
                    DisplayName = "Weather Api",
                    Description = "Allow the application to access Weather Api on your behalf",
                    Scopes = new List<string> { "weatherApi.read", "weatherApi.write"},
                    ApiSecrets = new List<Secret> {new Secret("POCSecretCode".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };
        }
    }
}
