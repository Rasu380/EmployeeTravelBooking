using EmployeeTravelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTravelBooking.Repositories
{
    public class TravelRequestRepository: ITravelRequest
    {
        private readonly EmployeeTravelBookingDBContext _context;
        public TravelRequestRepository(EmployeeTravelBookingDBContext context)
        {
            _context = context;
        }
        public async Task<List<TravelRequest>> GetAllTravelRequests()
        {
            try
            {
                return await _context.TravelRequests.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<TravelRequest> GetTravelRequestByID(int RequestID)
        {
            try
            {
                var request = await _context.TravelRequests.FirstOrDefaultAsync(r => r.RequestId == RequestID);
                return request;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AddTravelRequest(TravelRequestInput entity)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var travelRequestEntity = new TravelRequest()
                    {
                        RequestId=0,
                        EmployeeId=entity.EmployeeId,
                        TravelType=entity.TravelType,
                        Purpose = entity.Purpose,
                        FromCity=entity.FromCity,
                        FromCountry=entity.FromCountry,
                        DestinationCity = entity.DestinationCity,
                        DestinationCountry = entity.DestinationCountry,
                        DepartureDate= entity.DepartureDate,
                        ReturnDate= entity.ReturnDate,
                        ExpenseAmount = entity.ExpenseAmount,
                        Status = "Requested",
                        CreateAt = DateTime.Now,
                        Active = 1
                    };
                    _context.TravelRequests.Add(travelRequestEntity);
                    await _context.SaveChangesAsync();

                    if (entity.TravelType == "flight")
                    {
                        var flightEntity = new Flight()
                        {
                            RequestId = travelRequestEntity.RequestId,
                            Airline = entity.flightDetails.Airline,
                            FlightNumber = entity.flightDetails.FlightNumber,
                            DepartureTime = entity.flightDetails.DepartureTime,
                            ArrivalTime = entity.flightDetails.ArrivalTime,
                            CreatedAt = DateTime.Now,
                        };
                        _context.Flights.Add(flightEntity);
                        await _context.SaveChangesAsync();
                    }
                    else if (entity.TravelType == "hotel")
                    {
                        var hotelEntity = new Hotel()
                        {
                            RequestId= travelRequestEntity.RequestId,
                            HotelName=entity.hotelDetails.HotelName,
                            CheckInDate= entity.hotelDetails.CheckInDate,
                            CheckOutDate = entity.hotelDetails.CheckOutDate,
                            RoomType = entity.hotelDetails.RoomType,
                            CreatedAt = DateTime.Now

                        };
                        _context.Hotels.Add(hotelEntity);
                        await _context.SaveChangesAsync();
                    }
                    else if (entity.TravelType == "car rental")
                    {
                        var carRetalEntity = new CarRental()
                        {
                            RequestId= travelRequestEntity.RequestId,
                            RentalCompany=entity.carRentalDetails.RentalCompany,
                            PickupDate=entity.carRentalDetails.PickupDate,
                            ReturnDate = entity.carRentalDetails.ReturnDate,
                            CarType = entity.carRentalDetails.CarType,
                            CreatedAt = DateTime.Now
                        };
                         _context.CarRentals.Add(carRetalEntity);
                        await _context.SaveChangesAsync();
                    }

                    await transaction.CommitAsync();
                    return travelRequestEntity.RequestId;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<int> UpdateTravelRequest(TravelRequestInput entity)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    int result = 0;
                    var travelRequestEntity = new TravelRequest()
                    {
                        RequestId = entity.RequestId,
                        EmployeeId = entity.EmployeeId,
                        TravelType = entity.TravelType,
                        Purpose = entity.Purpose,
                        FromCity = entity.FromCity,
                        FromCountry = entity.FromCountry,
                        DestinationCity = entity.DestinationCity,
                        DestinationCountry = entity.DestinationCountry,
                        DepartureDate = entity.DepartureDate,
                        ReturnDate = entity.ReturnDate,
                        ExpenseAmount = entity.ExpenseAmount,
                        Status = "Requested",
                        UpdatedAt = DateTime.Now,
                        Active = 1
                    };
                    _context.TravelRequests.Update(travelRequestEntity);
                    await _context.SaveChangesAsync();

                    if (entity.TravelType == "flight")
                    {
                        var flightEntity = new Flight()
                        {
                            FlightId = entity.flightDetails.FlightId,
                            RequestId = entity.RequestId,
                            Airline = entity.flightDetails.Airline,
                            FlightNumber = entity.flightDetails.FlightNumber,
                            DepartureTime = entity.flightDetails.DepartureTime,
                            ArrivalTime = entity.flightDetails.ArrivalTime,
                        };
                        _context.Flights.Update(flightEntity);
                        await _context.SaveChangesAsync();
                    }
                    else if (entity.TravelType == "hotel")
                    {
                        var hotelEntity = new Hotel()
                        {
                            HotelId = entity.hotelDetails.HotelId,
                            RequestId = entity.RequestId,
                            HotelName = entity.hotelDetails.HotelName,
                            CheckInDate = entity.hotelDetails.CheckInDate,
                            CheckOutDate = entity.hotelDetails.CheckOutDate,
                            RoomType = entity.hotelDetails.RoomType,
                        };
                        _context.Hotels.Update(hotelEntity);
                        await _context.SaveChangesAsync();
                    }
                    else if (entity.TravelType == "car rental")
                    {
                        var carRetalEntity = new CarRental()
                        {
                            RentalId = entity.carRentalDetails.RentalId,
                            RequestId = entity.RequestId,
                            RentalCompany = entity.carRentalDetails.RentalCompany,
                            PickupDate = entity.carRentalDetails.PickupDate,
                            ReturnDate = entity.carRentalDetails.ReturnDate,
                            CarType = entity.carRentalDetails.CarType,
                        };
                        _context.CarRentals.Update(carRetalEntity);
                        await _context.SaveChangesAsync();
                    }

                    await transaction.CommitAsync();
                    result = 1;
                    return result;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<int> DeleteTravelRequest(int requestID)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    int result = 0;
                   
                    var travelRequest = new TravelRequest()
                    {
                        RequestId = requestID,
                        Active = 0
                    };
                    _context.TravelRequests.Attach(travelRequest);
                    _context.Entry(travelRequest).Property(u => u.Active).IsModified = true;
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = 1;
                    
                    return result;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
        public async Task<int> UpdateTravelRequestStatus(int requestID, int userID, int status)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    int result = 0;
                    string statusStr="";

                    if (status == 1)
                    {
                        statusStr = "Requested";
                    }
                    else if (status == 2)
                    {
                        statusStr = "Approved";
                    }
                    else if (status == 3)
                    {
                        statusStr = "Rejected";
                    }
                    else if (status == 4)
                    {
                        statusStr = "Cancelled";
                    }
                    else if (status == 5)
                    {
                        statusStr = "Completed";
                    }

                    var travelRequest = new TravelRequest()
                    {
                        RequestId = requestID,
                        Status = statusStr,
                        ApprovedBy = userID,
                    };
                    _context.TravelRequests.Attach(travelRequest);
                    _context.Entry(travelRequest).Property(u => u.Status).IsModified = true;
                    _context.Entry(travelRequest).Property(u => u.ApprovedBy).IsModified = true;
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = 1;

                    return result;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
