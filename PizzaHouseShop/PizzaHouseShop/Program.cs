using PizzaHouseShop.Interfaces; //Ubaceno je zbog Dependency Injection (DI)
using PizzaHouseShop.Repositories; // Ubaceno je zbog Dependency Injection (DI)
using Microsoft.EntityFrameworkCore;
using PizzaHouseShop.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(otps =>
{
    otps.Cookie.IsEssential = true;
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddTransient<IPizzaRepository, PizzaRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ShoppingCart>(sc => ShoppingCart.GetCart(sc));
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();


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
app.UseCookiePolicy();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseSession();
AuthAppBuilderExtensions.UseAuthentication(app);

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "categoryFilter",
    pattern: "Pizza/{action}/{category?}",
    defaults: new { Controller = "Pizza", Action = "List" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.UseDeveloperExceptionPage(); //Dodato zbog toga sto ova funkcija omogucava detaljne informacije o greskama kada je aplikacija u "razvojnom" okruzenju.
app.UseStatusCodePages(); //Dodato zbog toga sto ovo dodaje statusne stranice (npr. stranice za kodove gresaka poput 404).

app.Run();
