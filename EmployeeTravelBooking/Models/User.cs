using System;
using System.Collections.Generic;

namespace EmployeeTravelBooking.Models
{
    public partial class User
    {
        public User()
        {
            LoginTrackings = new HashSet<LoginTracking>();
            TravelRequests = new HashSet<TravelRequest>();
        }

        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; set; }
        public string? Destination { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ContactNumber { get; set; }
        public DateTime? DateJoined { get; set; }
        public int? UserTypeId { get; set; }
        public int? ManagerId { get; set; }
        public byte? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual UserType? UserType { get; set; }
        public virtual ICollection<LoginTracking> LoginTrackings { get; set; }
        public virtual ICollection<TravelRequest> TravelRequests { get; set; }
    }
}
