using WebService.MvcIU.Areas.Admin.HttpApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // HttpContext.Session'� kullanabilmek i�in ilgili servisi container a register etmeliyiz
builder.Services.AddHttpContextAccessor(); // Uygulama IHttpContextAccessor tipindeki bir nesnenin, istenilen alana inject edilebilmesi i�incontainer a register etmemiz gerekiyor

builder.Services.AddHttpClient(); // HttpClient nesnesi isteyen yerlere bu nesneyi verebilmesi i�in
builder.Services.AddScoped<IHttpApiService, HttpApiService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Session'� kullanabilmek i�in pipeline'a eklememiz gerekiyor

app.UseAuthorization();

app.MapAreaControllerRoute(
          name: "Admin",
          areaName: "Admin",
          pattern: "Admin/{controller=Authentication}/{action=Index}/{id?}");

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
