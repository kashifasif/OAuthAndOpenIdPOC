using IdentityModel;
using IdentityServer4.Test;
using System.Security.Claims;

namespace POC.IdentityServer.Infrastructure
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "39487348",
                Username = "admin",
                Password = "admin",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Email, "support@demo.com"),
                    new Claim(JwtClaimTypes.Role, "admin"),
                    new Claim(JwtClaimTypes.WebSite, "https://demo.com")
                }
            }
        };
        }
    }
}
