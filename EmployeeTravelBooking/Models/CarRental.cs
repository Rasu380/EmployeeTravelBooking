using System;
using System.Collections.Generic;

namespace EmployeeTravelBooking.Models
{
    public partial class CarRental
    {
        public int RentalId { get; set; }
        public int? RequestId { get; set; }
        public string? RentalCompany { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? CarType { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual TravelRequest? Request { get; set; }
    }
}
