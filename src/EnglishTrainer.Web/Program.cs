using EnglishTrainer.ApplicationCore.Common;
using EnglishTrainer.ApplicationCore.Config;
using EnglishTrainer.Config;
using EnglishTrainer.Infrastructure.Data;
using EnglishTrainer.Services;
using EnglishTrainer.Web.Configuration;
using EnglishTrainer.Web.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

//var logger = new LoggerConfiguration()
//.MinimumLevel.Debug()
//.WriteTo.Console()
//.WriteTo.File("logs/rumble-.txt", rollingInterval: RollingInterval.Day)
//.MinimumLevel.Information()
//.WriteTo.File("logs/information-.txt", rollingInterval: RollingInterval.Day)
//.CreateLogger();

#region Serilog information
//https://ru.stackoverflow.com/questions/883035/%D0%9A%D0%B0%D0%BA-%D0%B2-serilog-%D0%B7%D0%B0%D0%B4%D0%B0%D1%82%D1%8C-%D1%81%D0%B2%D1%8F%D0%B7%D0%BA%D1%83-%D0%B8%D0%B7-%D0%BD%D0%B5%D1%81%D0%BA%D0%BE%D0%BB%D1%8C%D0%BA%D0%B8%D1%85-%D1%83%D1%80%D0%BE%D0%B2%D0%BD%D0%B5%D0%B9-%D0%BB%D0%BE%D0%B3%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F-%D0%B8-%D0%B8%D1%81%D1%82%D0%BE%D1%87%D0%BD%D0%B8%D0%BA%D0%BE%D0%B2-%D0%B7%D0%B0%D0%BF%D0%B8%D1%81
//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Debug()
//    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//    .Enrich.FromLogContext()
//    .WriteTo.Console()
//    .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
//    .CreateLogger();
#endregion


//Serilog
var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/main-.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(le => le.Level == LogEventLevel.Debug)
        .WriteTo.File("logs/debug-.txt", rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(le => le.Level == LogEventLevel.Information)
        .WriteTo.File("logs/information-.txt", rollingInterval: RollingInterval.Day))
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddOptions<AuthorizationConfig>().BindConfiguration("Authorization");
builder.Services.AddOptions<JwtConfig>().BindConfiguration("Jwt");

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true; //Сохраняет токен после авторизации
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };
});

builder.Services.AddCors();


//Add logger
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


EnglishTrainer.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCoreServices();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseCors(x => x.AllowCredentials().AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));







app.Logger.LogInformation("Database migraion running...");
using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var trainerContext = scopedProvider.GetRequiredService<EnglishTrainerContext>();
        if (trainerContext.Database.IsSqlServer())
        {
            trainerContext.Database.Migrate();
        }
        await EnglishTrainerContextSeed.SeedAsync(trainerContext, app.Logger);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred adding migrations to Databse.");
    }

}

// Improves cookie security
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

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



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Verb}/{action=Index}/{id?}");

app.UseSecureJwt();

app.UseAuthentication();
app.UseAuthorization();

//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseMiddleware<AuthorizationMiddleware>();

app.Run();
