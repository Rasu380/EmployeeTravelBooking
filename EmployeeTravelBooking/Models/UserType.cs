using System;
using System.Collections.Generic;

namespace EmployeeTravelBooking.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? AccessLevel { get; set; }
        public byte? Active { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
