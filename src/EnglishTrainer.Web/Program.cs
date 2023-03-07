using EnglishTrainer.Infrastructure.Data;
using EnglishTrainer.Services;
using EnglishTrainer.Web.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

//Add logger
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = AuthOptions.ISSUER,
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = AuthOptions.AUDIENCE,
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    });

EnglishTrainer.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCoreServices();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.Map("/login/{username}", (string username) =>
{
    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
    // создаем JWT-токен
    var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

    return new JwtSecurityTokenHandler().WriteToken(jwt);
});



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


app.Run();
