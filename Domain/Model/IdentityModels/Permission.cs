﻿using Microsoft.EntityFrameworkCore;

namespace Domain.Model.IdentityModels; 

public class Permission {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Role> Roles { get; set; } = new();
}