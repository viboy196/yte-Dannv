using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using Xcomp.Api;
using Xcomp.Api.Filters;
using Xcomp.Api.Security.Auth;
using Xcomp.Data;
using Xcomp.Data.InitData;
using Xcomp.Data.IRepositories;
using Xcomp.Data.TinhNang;
using Xcomp.Share.Common;

SystemInfo.SystemType = SystemType.HeThong;
SystemInfo.CodeHeThong = CodeHeThong.IoT;
SystemInfo.Mode = RunMode.Test;
SystemInfo.DuLieu = DuLieu.BoQua;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ApiExceptionFilter());
    // https://joonasw.net/view/apply-authz-by-default
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
    options.Filters.Add(new ValidateModelAttribute());
});
builder.Services.AddControllers();
builder.Services.AddApiVersioning(config =>
{
    // https://dev.to/99darshan/restful-web-api-versioning-with-asp-net-core-1e8g
    // Specify the default API Version
    config.DefaultApiVersion = new ApiVersion(1, 0);
    // If the client hasn't specified the API version in the request, use the default API version number 
    config.AssumeDefaultVersionWhenUnspecified = true;
    // Advertise the API versions supported for the particular endpoint
    config.ReportApiVersions = true;

    // Supporting multiple versioning scheme
    config.ApiVersionReader = new QueryStringApiVersionReader("v");
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerGenConfigurationOptions>();
builder.Services.AddSwaggerGen();
RegisterServices(builder.Services);
builder.Services.AddAutoMapperConfig();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, (o) =>
{
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = TokenAuthOption.Key,
        ValidAudience = TokenAuthOption.Audience,
        ValidIssuer = TokenAuthOption.Issuer,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ClockSkew = TimeSpan.FromMinutes(0)
    };
});

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy(JwtBearerDefaults.AuthenticationScheme, new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});


FirebaseApp.Create(new AppOptions()
{
    
    Credential = GoogleCredential.FromFile(builder.Configuration["FireBaseSettings"]),
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});


app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    AC.InitAC(services);

}
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("copyright © XCOMP");
    });
});
SystemInfo.HeThong = await AC.HeThong.GetByCodeHeThong(SystemInfo.CodeHeThong);
SystemInfo.HeThongAnNinh = await AC.HeThong.GetByCodeHeThong(CodeHeThong.AnNinh);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddSingleton<IMongoContext, MongoContext>();
    services.AddSingleton<IUnitOfWork, UnitOfWork>();
    services.AddDataRepositories();
}