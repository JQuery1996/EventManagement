using System.Reflection;
using Domain.Model.IdentityModels;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace Authorization; 

public static class DependencyInjection {
   public static IServiceCollection AddApi(this IServiceCollection services) {
      services.ConfigureIdentity();
      services.ConfigureSwagger();
      services.AddAutoMapper(typeof(Program));
      return services;
   }

   private static void ConfigureIdentity(this IServiceCollection services) {
      // add identity
      services.AddIdentity<User, Role>()
         .AddEntityFrameworkStores<ApplicationDbContext>()
         .AddDefaultTokenProviders();

      services.Configure<IdentityOptions>(options => {
         // Password Settings
         options.Password.RequireDigit = false;
         options.Password.RequireLowercase = false;
         options.Password.RequireUppercase = false;
         options.Password.RequireNonAlphanumeric = false;
         options.Password.RequireNonAlphanumeric = false;
         options.Password.RequiredLength = 8;
         
         // Lockout settings
         options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
         options.Lockout.MaxFailedAccessAttempts = 5;
         options.Lockout.AllowedForNewUsers = true;
         
         // User Settings
         options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
         options.User.RequireUniqueEmail = true;
      });
   }

   private static void ConfigureSwagger(this IServiceCollection services) {
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen(options => {
         options.SwaggerDoc("v1", new OpenApiInfo {
            Title = "Event Management System",
            Description = "a web-based application that allows users to create, manage, and participate in events."
         });
         options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
            In = ParameterLocation.Header,
            Description = "Please insert Jwt with Bearer into Field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
         });
         options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
               new OpenApiSecurityScheme {
                     Reference = new OpenApiReference() {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer" 
                     }
               },
               new string[] {}
            }
         });
      });
   }
}