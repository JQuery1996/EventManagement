using Domain.Constants;
using Domain.Model.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace Authorization.Seeder; 

public class RoleSeeder(RoleManager<Role> roleManager){
    public async Task Seed() {
        foreach (var role in Enum.GetValues<Roles>()) {
            await roleManager.CreateAsync(new Role {
                Name = role.ToString(),
                NormalizedName = role.ToString().ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
    }
}