using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//__Report And Bills//////////////////////////
builder.Services.AddDevExpressControls();
builder.Services.AddMvc();
builder.Services.ConfigureReportingServices(configurator =>
{
    configurator.ConfigureWebDocumentViewer(Viwerconfigurator =>
    {
        Viwerconfigurator.UseCachedReportSourceBuilder();
    });
});
///////////////////////////_____________\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Acces/Index";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        option.AccessDeniedPath = "/Acces/AccessDenied";
    });

var app = builder.Build();
app.UseDevExpressControls();
System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

var env = builder.Environment;///for report
app.UseHttpsRedirection();
app.UseStaticFiles();
/////for report////////////////
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider=new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "/Users/Tunahan/source/repos/WareHouseManagement/WareHouseManagement/node_modules")),
//    RequestPath= "/Users/Tunahan/source/repos/WareHouseManagement/WareHouseManagement/node_modules"
//});
/////for report
app.UseSession();

app.UseRouting();
app.UseAuthentication();


app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Acces}/{action=Index}/{id?}");

app.Run();
