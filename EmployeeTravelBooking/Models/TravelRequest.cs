using System;
using System.Collections.Generic;

namespace EmployeeTravelBooking.Models
{
    public partial class TravelRequest
    {
        public TravelRequest()
        {
            CarRentals = new HashSet<CarRental>();
            Flights = new HashSet<Flight>();
            Hotels = new HashSet<Hotel>();
        }

        public int RequestId { get; set; }
        public int? EmployeeId { get; set; }
        public string? TravelType { get; set; }
        public string? Purpose { get; set; }
        public string? FromCity { get; set; }
        public string? FromCountry { get; set; }
        public string? DestinationCity { get; set; }
        public string? DestinationCountry { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal? ExpenseAmount { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ApprovedBy { get; set; }
        public byte? Active { get; set; }

        public virtual User? Employee { get; set; }
        public virtual ICollection<CarRental> CarRentals { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
