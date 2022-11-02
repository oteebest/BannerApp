using Banner.Application.Extentions;
using BannerApp.Extentions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDatabase(configuration);
builder.Services.RegisterServices();
builder.Services.AddApplicationLayer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Banner}/{action=Index}/{id?}");

//seed data // don't do this on production app
builder.Services.BuildServiceProvider().MigrateDBSeedData(configuration);


app.Run();
