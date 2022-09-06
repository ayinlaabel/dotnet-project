using Custodian.Salvage.DomainFacade.services;
using Custodian.Salvage.Managers.Purchase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IPurchaseManager, PurchaseManager>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
