using System;
using System.Collections.Generic;
using Manage_User.Models;
using System.ComponentModel.DataAnnotations;
namespace Manage_User.Models;

public partial class DbUser
{
    [Key]
    public int Id { get; set; }

    public string UserName { get; set; } = null!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    public DateTime? BirthDay { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public int? Age { get; set; }

    public bool? Gender { get; set; }
}
