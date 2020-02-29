using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelBookingSystem.DAL.Models
{
    public partial class HotelBookingSystemContext : DbContext
    {
        public HotelBookingSystemContext()
        {
        }

        public HotelBookingSystemContext(DbContextOptions<HotelBookingSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=HotelBookingSystem;Username=postgres;Password=159357;Port=5432");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.BookId)
                    .HasColumnName("bookID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CheckinDate)
                    .HasColumnName("checkinDate")
                    .HasColumnType("date");

                entity.Property(e => e.CheckoutDate)
                    .HasColumnName("checkoutDate")
                    .HasColumnType("date");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.RoomId).HasColumnName("roomID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("clientID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("roomID");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .HasColumnName("clientID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("clientName");

                entity.Property(e => e.ClientSurname)
                    .IsRequired()
                    .HasColumnName("clientSurname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.HotelId)
                    .HasColumnName("hotelID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country");

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasColumnName("hotelName");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Star).HasColumnName("star");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId)
                    .HasColumnName("roomID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aircondition).HasColumnName("aircondition");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.HotelId).HasColumnName("hotelID");

                entity.Property(e => e.Minibar).HasColumnName("minibar");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Television).HasColumnName("television");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("hotelID");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffId)
                    .HasColumnName("staffID")
                    .ValueGeneratedNever();

                entity.Property(e => e.HotelId).HasColumnName("hotelID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("character varying");

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasColumnName("staffName");

                entity.Property(e => e.StaffSurname)
                    .IsRequired()
                    .HasColumnName("staffSurname");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("hotelID");
            });
        }
    }
}
