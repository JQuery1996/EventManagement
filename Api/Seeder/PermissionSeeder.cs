using Application.Repository;
using Domain.Constants;
using Domain.Model.IdentityModels;

namespace Authorization.Seeder; 

public class PermissionSeeder(IUnitOfWork unitOfWork) {
    public async Task Seed() {
        foreach (var permission in Enum.GetValues<Permissions>()) {
            var actualPermission = await unitOfWork.Permissions.FindAsync(p => p.Name == permission.ToString());
            if(actualPermission is null)
                unitOfWork.Permissions.Add(new Permission {
                    Name = permission.ToString()
                });
        }

        await unitOfWork.CommitAsync();
    }
    
}