using System;
using System.Collections.Generic;

namespace EmployeeTravelBooking.Models
{
    public partial class Hotel
    {
        public int HotelId { get; set; }
        public int? RequestId { get; set; }
        public string? HotelName { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string? RoomType { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual TravelRequest? Request { get; set; }
    }
}
