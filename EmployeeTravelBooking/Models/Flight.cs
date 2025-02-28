using System;
using System.Collections.Generic;

namespace EmployeeTravelBooking.Models
{
    public partial class Flight
    {
        public int FlightId { get; set; }
        public int? RequestId { get; set; }
        public string? Airline { get; set; }
        public string? FlightNumber { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual TravelRequest? Request { get; set; }
    }
}
