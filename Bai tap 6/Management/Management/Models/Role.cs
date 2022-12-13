using System;
using System.Collections.Generic;

namespace Management.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Action { get; set; }

    public string? Controller { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
