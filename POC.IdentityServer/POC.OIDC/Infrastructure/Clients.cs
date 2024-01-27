using IdentityServer4.Models;
using IdentityServer4;

namespace POC.IdentityServer.Infrastructure
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "weatherApi",
                    ClientName = "ASP.NET Core Weather Api",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("POCSecretCode".Sha256())},
                    AllowedScopes = new List<string> {"weatherApi.read"}
                },
                new Client
                {
                    ClientId = "oidcMVCApp",
                    ClientName = "Sample ASP.NET Core MVC Web App",
                    ClientSecrets = new List<Secret> {new Secret("POCSecretCode".Sha256())},

                    AllowedGrantTypes = GrantTypes.Code,
                    
                    RedirectUris = new List<string> {"https://localhost:7089/signin-oidc"},
                    PostLogoutRedirectUris = { "https://localhost:7089/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "weatherApi.read"
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }
            };
        }
    }
}
