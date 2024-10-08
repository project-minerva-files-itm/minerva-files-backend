using Fantasy.Backend.Repositories.Implementations;
using Fantasy.Backend.UnitsOfWork.Implementations;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Data;
using SharedLibrary.Entities;
using System.Text.Json.Serialization;
using UserService.Data;
using UserService.Repositories.Interfaces;
using UserService.UnitsOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configure database

builder.Services.AddScoped<DataContext>();

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

builder.Services.AddTransient<SeedDb>();

#endregion Configure database

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersUnitOfWork, UsersUnitOfWork>();

builder.Services.AddIdentity<User, IdentityRole>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequireDigit = false;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireLowercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();
SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using var scope = scopedFactory!.CreateScope();
    var service = scope.ServiceProvider.GetService<SeedDb>();
    service!.SeedAsync().Wait();
}

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