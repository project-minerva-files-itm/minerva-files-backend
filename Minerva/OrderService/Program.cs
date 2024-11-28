using OrderService.Data;
using OrderService.Repositories.Implementations;
using OrderService.Repositories.Interfaces;
using OrderService.UnitsOfWork.Implementations;
using OrderService.UnitsOfWork.Interfaces;
using SharedLibrary.Data;
using SharedLibrary.Repositories.Implementations;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.UnitsOfWork.Implementations;
using SharedLibrary.UnitsOfWork.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configure database

builder.Services.AddScoped<IDataConext, DataContext>();

var configuration = builder.Configuration;

builder.Services.AddTransient<IDbContextConfigurator>(provider =>
{
    var providerName = configuration["DatabaseProvider"] ?? "";
    var connectionString = configuration.GetConnectionString(providerName == "MySQL" ? "MySqlConnection" : "SqlServerConnection") ?? "";
    return DbContextConfiguratorFactory.CreateConfigurator(providerName, connectionString);
});

builder.Services.AddDbContext<DataContext>((serviceProvider, options) =>
{
    var configurator = serviceProvider.GetRequiredService<IDbContextConfigurator>();
    configurator.Configure(options);
});

#endregion Configure database

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestUnitOfWork, RequestUnitOfWork>();

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

app.UseCors(x => x
           .AllowAnyMethod()
           .AllowAnyHeader()
           .SetIsOriginAllowed(origin => true)
           .AllowCredentials());

app.Run();