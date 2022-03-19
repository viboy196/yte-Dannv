using Microsoft.AspNetCore.SignalR;
using Xcomp.Data;
using Xcomp.Data.InitData;
using Xcomp.Data.TinhNang;
using Xcomp.Share.Common;
using Xcomp.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

SystemInfo.SystemType = SystemType.HeThong;
SystemInfo.CodeHeThong = CodeHeThong.YTeMoi;
SystemInfo.Mode = RunMode.Dev;
SystemInfo.DuLieu = DuLieu.BoQua;

builder.Services.AddSingleton<IMongoContext, MongoContext>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddDataRepositories();
builder.Services.AddSignalR();


builder.Services.AddAuthentication("Ytemoi_CookieAuth").AddCookie("Ytemoi_CookieAuth", options =>
{
    options.Cookie.Name = "Ytemoi_CookieAuth";
    options.LoginPath = "/account/login"; // đường dẫn khi không authorize
    //options.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseRouting();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoint =>
{ 
    endpoint.MapHub<ComHub>("/comHub"); //định tuyến cho HubConnection
});

ComHub._hubContext = (IHubContext<ComHub>)app.Services.GetService(typeof(IHubContext<ComHub>));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    AC.InitAC(services);
    if (SystemInfo.SystemType == SystemType.HeThong)
    {
        if (SystemInfo.DuLieu == DuLieu.TaoMoi)
        {
            await DB.TaoMoi();
            await DB.SinhThem();
        } 
        if (SystemInfo.DuLieu == DuLieu.SinhThem)
        {            
            await DB.SinhThem();
        }
    }    
    
}

SystemInfo.HeThong = await AC.HeThong.GetByCodeHeThong(SystemInfo.CodeHeThong);

app.Run();
