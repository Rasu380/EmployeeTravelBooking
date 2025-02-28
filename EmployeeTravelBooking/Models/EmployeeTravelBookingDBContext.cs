using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeTravelBooking.Models
{
    public partial class EmployeeTravelBookingDBContext : DbContext
    {
        public EmployeeTravelBookingDBContext()
        {
        }

        public EmployeeTravelBookingDBContext(DbContextOptions<EmployeeTravelBookingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarRental> CarRentals { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<LoginTracking> LoginTrackings { get; set; } = null!;
        public virtual DbSet<TravelRequest> TravelRequests { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarRental>(entity =>
            {
                entity.HasKey(e => e.RentalId);

                entity.Property(e => e.RentalId).HasColumnName("RentalID");

                entity.Property(e => e.CarType).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PickupDate).HasColumnType("datetime");

                entity.Property(e => e.RentalCompany).HasMaxLength(100);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.CarRentals)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__CarRental__Reque__38996AB5");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.Airline).HasMaxLength(100);

                entity.Property(e => e.ArrivalTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DepartureTime).HasColumnType("datetime");

                entity.Property(e => e.FlightNumber).HasMaxLength(50);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__Flights__Request__36B12243");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.CheckInDate).HasColumnType("date");

                entity.Property(e => e.CheckOutDate).HasColumnType("date");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.HotelName).HasMaxLength(100);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.RoomType).HasMaxLength(50);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__Hotels__RequestI__37A5467C");
            });

            modelBuilder.Entity<LoginTracking>(entity =>
            {
                entity.ToTable("LoginTracking");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginTrackings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__LoginTrac__UserI__3D5E1FD2");
            });

            modelBuilder.Entity<TravelRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.DestinationCity).HasMaxLength(100);

                entity.Property(e => e.DestinationCountry).HasMaxLength(100);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ExpenseAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FromCity).HasMaxLength(100);

                entity.Property(e => e.FromCountry).HasMaxLength(100);

                entity.Property(e => e.Purpose).HasMaxLength(255);

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TravelType).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TravelRequests)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__TravelReq__Emplo__46E78A0C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ContactNumber).HasMaxLength(20);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.DateJoined).HasColumnType("date");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Destination).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__Users__UserTypeI__44FF419A");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccessLevel).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
