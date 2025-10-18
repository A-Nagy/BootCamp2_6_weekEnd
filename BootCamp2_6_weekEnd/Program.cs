using BootCamp2_6_weekEnd.Data;
using BootCamp2_6_weekEnd.Repository.Base;
using BootCamp2_6_weekEnd.Repository.Implement;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefualtConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));


builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler =System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
 
builder.Services.AddScoped(typeof(IRepository<>) ,typeof(MainRepository<>) );
//builder.Services.AddScoped<IRepoEmployee, RepoEmployee>();
//builder.Services.AddScoped<IRepoProduct, RepoProduct>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
