using Microsoft.EntityFrameworkCore;
using SettingsService.Data;
using SettingsService.Repositories.Implementations;
using SettingsService.Repositories.Interfaces;
using SettingsService.UnitsOfWork.Implementations;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.Data;
using SharedLibrary.Repositories.Implementations;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.UnitsOfWork.Implementations;
using SharedLibrary.UnitsOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyUnitOfWork, CompanyUnitOfWork>();

builder.Services.AddScoped<IActivityStateRepository, ActivityStateRepository>();
builder.Services.AddScoped<IActivityStateUnitOfWork, ActivityStateUnitOfWork>();

builder.Services.AddScoped<IRequestTypeRepository, RequestTypeRepository>();
builder.Services.AddScoped<IRequestTypeUnitOfWork, RequestTypeUnitOfWork>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentUnitOfWork, DepartmentUnitOfWork>();

builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
builder.Services.AddScoped<IDocumentTypeUnitOfWork, DocumentTypeUnitOfWork>();

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