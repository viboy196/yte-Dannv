using Xcomp.Data;
using Xcomp.Data.InitData;
using Xcomp.Data.TinhNang;
using Xcomp.Share.Common;

#region addServices
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

SystemInfo.DuLieu = DuLieu.BoQua;

builder.Services.AddSingleton<IMongoContext, MongoContext>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddDataRepositories();

#endregion

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#region dữ liệu
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    AC.InitAC(services);
    if (SystemInfo.DuLieu == DuLieu.TaoMoi)
    {
        await DB.TaoMoi();
    }
}
#endregion



app.Run();
