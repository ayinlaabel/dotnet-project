using Custodian.Salvage.Api.Configurations;
using Custodian.Salvage.DomainFacade.services;
using Custodian.Salvage.Managers.Purchase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddSingleton(new SalvageDatabaseConfig() { Salvage = "" })
builder.Services.AddScoped<IPurchaseManager>(s => new PurchaseManager(SalvageDatabaseConfig.Salvage));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
