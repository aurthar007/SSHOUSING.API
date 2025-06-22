using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastructure.Repositories;
using SSHOUSING.Infrastructure.Repository;
using SSHOUSING.Infrastucture;
using SSHOUSING.Infrastucture.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ----------------------
// Database Configuration
// ----------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ----------------------
// Dependency Injection
// ----------------------
builder.Services.AddScoped<ICountry, CountryRepository>();
builder.Services.AddScoped<IState, StateRepository>();
builder.Services.AddScoped<IDistrict, DistrictRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IRole, RoleRepository>();
builder.Services.AddScoped<IUserRole, UserRoleRepository>();
builder.Services.AddScoped<IProperty, PropertyRepository>();
builder.Services.AddScoped<IManageUser, ManageUserRepository>();
builder.Services.AddScoped<IBilling, BillingRepository>();
builder.Services.AddScoped<IRule, RuleRepository>();
builder.Services.AddScoped<INotice, NoticeRepository>();
builder.Services.AddScoped<IMaintenanceRequest, MaintenanceRequestRepository>();

builder.Services.AddScoped<IDocument, DocumentRepository>();
builder.Services.AddScoped<IMessage, MessageRepository>();
builder.Services.AddScoped<IIncome, IncomeRepository>();
// ----------------------
// CORS Configuration
// ----------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React dev server
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Only needed if you're using cookies or Authorization header
    });
});

// ----------------------
// JWT Authentication
// ----------------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ----------------------
// Middleware Pipeline
// ----------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp"); // Must be before Auth

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
