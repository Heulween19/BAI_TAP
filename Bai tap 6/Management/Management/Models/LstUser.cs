using System;
using System.Collections.Generic;

namespace Management.Models;

public partial class LstUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? Password { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public int? Age { get; set; }

    public bool? Gender { get; set; }

    public int? GroupId { get; set; }

    public bool Status { get; set; }

    public virtual Group? Group { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
