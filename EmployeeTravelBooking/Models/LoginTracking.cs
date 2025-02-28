using System;
using System.Collections.Generic;

namespace EmployeeTravelBooking.Models
{
    public partial class LoginTracking
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? ActualToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual User? User { get; set; }
    }
}
