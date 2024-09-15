using CabeleleilaLeila.Web.Helpers;
using CabeleleilaLeila.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAuthorizationCore();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

#region Configure Interface and Repository
builder.Services.AddTransient<CabeleleilaLeila.Web.Helpers.ISession, Session>();
builder.Services.AddTransient<IUsuarioServiceClient, UsuarioServiceClient>();
#endregion

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["CabeleleilaLeilaApi:Url"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
