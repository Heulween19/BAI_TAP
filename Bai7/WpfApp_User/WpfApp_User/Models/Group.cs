using System;
using System.Collections.Generic;

namespace WpfApp_User.Models
{
    public partial class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
        }

        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
