namespace EmployeeTravelBooking.Models
{
    public class CarRentalInput
    {
        public int RentalId { get; set; }
        public string? RentalCompany { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? CarType { get; set; }
    }
}
