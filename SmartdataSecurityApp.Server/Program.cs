using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SmartdataSecurityService;
using SmartdataSecurityService.Interfaces;
using SmartdataSecurityService.Repositories;
using MySql.EntityFrameworkCore;
using System.Text;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:JwtTokenKey"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true

    };
});
// Add DbContext for MySQL
builder.Services.AddDbContext<MySqlDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));

IServiceCollection services = builder.Services;
services.AddScoped<IDepartmentRepository, DepartmentRepository>()
        .AddScoped<IEmployeeRepository, EmployeeRepository>();


var app = builder.Build();


// Middleware for development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware for serving Angular files and API requests
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication(); // Authentication middleware must be added before Authorization
app.UseAuthorization();

// Routing configuration
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html"); // Serves Angular's index.html for SPA routing
});

app.Run();
