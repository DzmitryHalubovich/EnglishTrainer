using EnglishTrainer.ApplicationCore;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Infrastructure.Data;
using EnglishTrainer.Services;
using EnglishTrainer.Services.Implementations;
using EnglishTrainer.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

EnglishTrainer.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

builder.Services.AddScoped(typeof(IRepository<>), typeof(EFTrainerRepository<>));
builder.Services.AddScoped(typeof(IApiWordService), typeof(ApiWordService));
builder.Services.AddScoped(typeof(IWordViewModelService), typeof(WordViewModelService));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
