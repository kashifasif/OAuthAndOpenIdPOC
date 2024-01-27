using POC.OAuth.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
.AddCookie("Cookies")
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = "https://localhost:44344";
    options.ClientId = "oidcMVCApp";
    options.ClientSecret = "POCSecretCode";
    options.ResponseType = "code";
    options.UsePkce = true;
    options.ResponseMode = "query";
    options.Scope.Add("weatherApi.read");
    options.SaveTokens = true;
});

builder.Services.AddIdentityServer()
        .AddInMemoryClients(Clients.Get())
        .AddInMemoryIdentityResources(Resources.GetIdentityResources())
        .AddInMemoryApiResources(Resources.GetApiResources())
        .AddInMemoryApiScopes(Scopes.GetApiScopes())
        .AddTestUsers(Users.Get())
        .AddDeveloperSigningCredential();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseIdentityServer();

app.MapControllers();

app.Run();
