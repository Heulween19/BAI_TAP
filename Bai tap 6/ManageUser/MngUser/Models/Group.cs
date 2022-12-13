using System;
using System.Collections.Generic;

namespace MngUser.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<LstUser> LstUsers { get; } = new List<LstUser>();
}
