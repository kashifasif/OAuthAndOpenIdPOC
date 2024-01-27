using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "oauth";
})
.AddCookie("Cookies")
.AddOAuth("oauth", options =>
{
    options.TokenEndpoint = "https://localhost:7171/connect/token";
    options.AuthorizationEndpoint = "https://localhost:7171/connect/token";
    options.ClientId = "oidcMVCApp";
    options.ClientSecret = "POCSecretCode";
    options.UsePkce = true;
    options.Scope.Add("weatherApi.read");
    options.CallbackPath = "/Home/Privacy";
    options.Events = new OAuthEvents
    {
        OnCreatingTicket = async context =>
        {
            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);

        },
        OnAccessDenied = async context =>
        {
            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.ReturnUrlParameter);
        }
    };
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
