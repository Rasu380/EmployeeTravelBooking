namespace EmployeeTravelBooking.Models
{
    public class FlightInput
    {
        public int FlightId { get; set; }
        public string? Airline { get; set; }
        public string? FlightNumber { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
    }
}
