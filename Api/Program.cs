using Application;
using Authorization;
using Authorization.Middlewares;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApi()
        .AddInfrastructure(builder.Configuration)
        .AddApplication();
    
    // Add services to the container.
    builder.Services
        .AddControllers();

    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
}

var app = builder.Build(); {
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment()) {
        app.UseSwagger();
        app.UseSwaggerUI();


        // var scope = app.Services.CreateScope();
        // var services = scope.ServiceProvider;
        // new RoleSeeder(services.GetRequiredService<RoleManager<Role>>()).Seed().Wait();
        // new PermissionSeeder(services.GetRequiredService<IUnitOfWork>()).Seed().Wait();
    }
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    
    // use transaction middleware
    app.UseTransactionMiddleware();
    
    app.MapControllers();
    app.Run();
}


