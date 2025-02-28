namespace EmployeeTravelBooking.Models
{
    public class TravelRequestInput
    {
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
        public FlightInput flightDetails { get; set; }
        public HotelInput hotelDetails { get; set; }
        public CarRentalInput carRentalDetails { get; set; }
    }
}
