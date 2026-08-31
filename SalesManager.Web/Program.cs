//Captura o diretório atual e remove a referência do symlink '/var' do bazzite

using Microsoft.EntityFrameworkCore;
using SalesManager.Web.Data;
using SalesManager.Web.Services;

var currentDir = Directory.GetCurrentDirectory().Replace("/var/home", "/home");

//Força o ASP.NET a usar o caminho real absoluto para localizar as views
var options = new WebApplicationOptions()
{
    Args = args,
    ContentRootPath = currentDir
};

var builder = WebApplication.CreateBuilder(options);


// Add services to the container.
builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<SalesManagerDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SalesManageDbContext")));

// Seeding Service
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetService<SeedingService>();
        seedingService.Seed();
    }
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();