namespace EmployeeTravelBooking.Models
{
    public class HotelInput
    {
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string? RoomType { get; set; }
    }
}
