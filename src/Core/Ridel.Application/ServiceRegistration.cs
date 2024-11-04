using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ridel.Application.Helpers;
using Ridel.Application.Interfaces;
using Ridel.Application.Interfaces.Services;
using Ridel.Application.Mappings.User;
using Ridel.Application.Services;
using System.Reflection;
using System.Security.Claims;

namespace Ridel.Application
{
    public static class ServiceRegistration
    {
        public static void RegisterApplication(this IServiceCollection serviceProvider, IConfiguration configuration)
        {
            serviceProvider.AddScoped<IdentityHelper>();
            serviceProvider.AddScoped<ClaimsPrincipal>();
            serviceProvider.AddScoped<IJwtService, JwtService>();
            serviceProvider.AddScoped<IUserClaimService, UserClaimService>();
            serviceProvider.AddScoped<IUserService, UserService>();
            serviceProvider.AddScoped<IUserDetailService, UserDetailService>();
            serviceProvider.AddScoped<IVehicleTypeService, VehicleTypeService>();
            serviceProvider.AddScoped<IVehicleFeatureService, VehicleFeatureService>();
      


            // CQRS ve MediatR
            //serviceProvider.AddMediatR(typeof(AssemblyReference).Assembly);
            serviceProvider.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            serviceProvider.AddAutoMapper(typeof(UserProfile).Assembly);
        }
    }
}
