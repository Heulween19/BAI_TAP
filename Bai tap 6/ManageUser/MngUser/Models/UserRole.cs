using System;
using System.Collections.Generic;

namespace MngUser.Models;

public partial class UserRole
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public bool? Status { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual LstUser User { get; set; } = null!;
}
