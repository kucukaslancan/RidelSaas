using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ridel.Application.Helpers;
using Ridel.Application.Interfaces;
using Ridel.Application.Interfaces.Repositories;
using Ridel.Domain.Entities;
using Ridel.Domain.Entities.Jwt;
using Ridel.Domain.Entities.Role;
using Ridel.Persistence.Contexts;
using Ridel.Persistence.Repositories;
using Ridel.Persistence.Repositories.Users;
using Ridel.Persistence.Repositories.Vehicle;
using System.Text;

namespace Ridel.Persistence
{
    public static class ServiceRegistration
    {
        public static void RegisterPersistence(this IServiceCollection serviceProvider, IConfiguration configuration)
        {
            serviceProvider.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DatabaseConnection"), b => b.MigrationsAssembly("Ridel.Persistence"));

            });

            serviceProvider.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            serviceProvider.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceProvider.AddScoped<IUserRepository, UserRepository>();
            serviceProvider.AddScoped<IVehicleRepository, VehicleRepository>();
            serviceProvider.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            serviceProvider.AddScoped<IdentityHelper>();


            serviceProvider.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            // JWT Konfigürasyonu
            var jwtSettings = configuration.GetSection("JwtSettings");


            // Identity konfigürasyonu
            serviceProvider.AddIdentity<User, ApplicationRole>(options =>
            {
                // Parola gereksinimlerini burada ayarlayın
                options.Password.RequireDigit = false;  // Rakam gereksinimini kaldır
                options.Password.RequiredLength = 1;    // Minimum uzunluk 6 karakter
                options.Password.RequireNonAlphanumeric = false; // Özel karakter gereksinimini kaldır
                options.Password.RequireUppercase = false; // Büyük harf gereksinimini kaldır
                options.Password.RequireLowercase = false; // Küçük harf gereksinimini kaldır
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            serviceProvider.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
                };
            });

    

        



        }
    }
}
