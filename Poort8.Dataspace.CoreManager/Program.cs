using Poort8.Dataspace.AuthorizationRegistry.Extensions;
using Poort8.Dataspace.CoreManager;
using Poort8.Dataspace.OrganizationRegistry.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Choose between Sqlite or SqlServer
builder.Services.AddOrganizationRegistrySqlite(options => options.ConnectionString = "Data Source=OrganizationRegistry.db");
builder.Services.AddAuthorizationRegistrySqlite(options => options.ConnectionString = "Data Source=AuthorizationRegistry.db");

//builder.Services.AddOrganizationRegistrySqlServer(options => options.ConnectionString = builder.Configuration["OrganizationRegistry:ConnectionString"]);
//builder.Services.AddAuthorizationRegistrySqlServer(options => options.ConnectionString = builder.Configuration["AuthorizationRegistry:ConnectionString"]);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.RunOrganizationRegistryMigrations();
app.RunAuthorizationRegistryMigrations();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
