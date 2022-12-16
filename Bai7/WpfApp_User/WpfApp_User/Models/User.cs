using System;
using System.Collections.Generic;

namespace WpfApp_User.Models
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public int? Age { get; set; }
        public bool? Gender { get; set; }
        public int GroupId { get; set; }
        public bool? Status { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
