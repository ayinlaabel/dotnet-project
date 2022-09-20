using Custodian.Salvage.Api.Configurations;
using Custodian.Salvage.DomainFacade.services;
using Custodian.Salvage.Managers.Purchase;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
SalvageDatabaseConfig config = new();

builder.Configuration.GetSection("Databases").Bind(config);

builder.Services.AddScoped<SalvageDatabaseConfig>(s => config);


//builder.Services.AddSingleton(new SalvageDatabaseConfig() { Salvage = "" })
builder.Services.AddScoped<IPurchaseManager>(s => new PurchaseManager(config.Salvage));

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
}
);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("EnableCORS");

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});

app.UseAuthorization();

app.MapControllers();

app.Run();
