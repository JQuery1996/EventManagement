
using System.Text;
using Application.Interfaces;
using Application.Repository;
using Infrastructure.Authentication;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure; 

public static class DependencyInjection {
   public static IServiceCollection AddInfrastructure(this IServiceCollection services,
      ConfigurationManager configuration) {
      services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddPersistence(configuration); 
      services.ConfigureAuthentication(configuration);
      return services;
   }

   private static void AddPersistence(this IServiceCollection services, ConfigurationManager configuration) {
      services.AddDbContext<ApplicationDbContext>(options => {
         options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"),
            sqlDbContextOptionsBuilder => {
               sqlDbContextOptionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            });
      });
   }

   private static void ConfigureAuthentication(this IServiceCollection services, ConfigurationManager configuration) {
      var jwtSettings = new JwtSettings();
      configuration.Bind(JwtSettings.Section, jwtSettings);
      services.AddSingleton(Options.Create(jwtSettings));
      services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

      services.AddAuthentication(options => {
         options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; 
         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      })
         .AddBearerToken()
         .AddJwtBearer(options => {
         options.SaveToken = true;
         options.RequireHttpsMetadata = true;
         options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
         };
      });
      services.AddAuthorization();
      services.AddScoped<IPermissionService, PermissionService>();
      services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
      services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
   }
}
