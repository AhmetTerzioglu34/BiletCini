using Project.BLL.ServiceInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();


builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(5);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});




builder.Services.AddDbContextService();
builder.Services.AddIdentityServices();

builder.Services.AddRepositoryService();
builder.Services.AddManagerServices();

builder.Services.AddCookieServices();



WebApplication app = builder.Build();








// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();


app.UseAuthentication();// Giriþ Yapmak
app.UseAuthorization(); // Yetkilendirmedir

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
