using FluentValidation;
using FluentValidation.AspNetCore;
using LoanManagementSystem.API.Extensions;
using LoanManagementSystem.Application.Interfaces;
using LoanManagementSystem.Application.Repositories;
using LoanManagementSystem.Application.Validators;
using LoanManagementSystem.Infrastructure.Authentication;
using LoanManagementSystem.Infrastructure.Services;
using LoanManagementSystem.Persistence.Context;
using LoanManagementSystem.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen( options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Loan Management API",
            Version = "v1"
        });

    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            In = ParameterLocation.Header,
            Description = "Enter JWT Token",
        });

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()

            }
        }); ;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddScoped<IRefreshTokenRepository,RefreshTokenRepository>();

var secret =
    builder.Configuration["JwtSettings:Secret"];

var key = Encoding.UTF8.GetBytes(secret!);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer =
                    builder.Configuration["JwtSettings:Issuer"],

                ValidAudience =
                    builder.Configuration["JwtSettings:Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(key)
            };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseGlobalExceptionMiddleware(); 

app.UseRequestLoggingMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();