using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PaiAirlines.Models;

namespace PaiAirlines.Migrations
{
    [DbContext(typeof(PaiDBContext))]
    [Migration("20181026101231_MigrationForTheDSSecondVeryLastTimePorFavor")]
    partial class MigrationForTheDSSecondVeryLastTimePorFavor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaiAirlines.Models.Aircraft", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BussinessSeats");

                    b.Property<int>("EconomySeats");

                    b.Property<int>("FirstSeats");

                    b.Property<int>("Range");

                    b.Property<int>("Size");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("PaiAirlines.Models.AircraftFlight", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BussinessSeatsTaken");

                    b.Property<int>("EconomySeatsTaken");

                    b.Property<int>("FirstSeatsTaken");

                    b.Property<int?>("arcftID");

                    b.Property<int?>("flghtID");

                    b.Property<int?>("schdlID");

                    b.HasKey("ID");

                    b.HasIndex("arcftID");

                    b.HasIndex("flghtID");

                    b.HasIndex("schdlID");

                    b.ToTable("AircraftFlight");
                });

            modelBuilder.Entity("PaiAirlines.Models.Airport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Coordinates");

                    b.Property<string>("IATAcode");

                    b.Property<string>("Name");

                    b.Property<int?>("ctyID");

                    b.HasKey("ID");

                    b.HasIndex("ctyID");

                    b.ToTable("Airport");
                });

            modelBuilder.Entity("PaiAirlines.Models.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FlightID");

                    b.Property<int>("SeatsAmount");

                    b.Property<int>("TotalPrice");

                    b.Property<int>("Userid");

                    b.HasKey("ID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("PaiAirlines.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("PaiAirlines.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("PaiAirlines.Models.Flight", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DestinationId");

                    b.Property<int>("FlightNumber");

                    b.Property<int>("OriginId");

                    b.Property<int>("Price");

                    b.Property<int>("Seats");

                    b.Property<DateTime>("Time");

                    b.HasKey("ID");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("PaiAirlines.Models.Price", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bussiness");

                    b.Property<int>("Economy");

                    b.Property<int>("First");

                    b.Property<int>("LuggagePrice");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.Property<int?>("flghtID");

                    b.Property<int?>("schdlID");

                    b.HasKey("ID");

                    b.HasIndex("flghtID");

                    b.HasIndex("schdlID");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("PaiAirlines.Models.Schedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Arrival");

                    b.Property<DateTime>("Boarding");

                    b.Property<DateTime>("Departure");

                    b.Property<int?>("FltID");

                    b.HasKey("ID");

                    b.HasIndex("FltID");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("PaiAirlines.Models.Seat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArcftID");

                    b.Property<int>("ClassId");

                    b.Property<int>("SeatNum");

                    b.HasKey("ID");

                    b.HasIndex("ArcftID");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("PaiAirlines.Models.Ticket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FlightID");

                    b.Property<int?>("UserIDID");

                    b.HasKey("ID");

                    b.HasIndex("UserIDID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("PaiAirlines.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CtyID");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("PaiAirlines.Models.UserMatmid", b =>
                {
                    b.HasBaseType("PaiAirlines.Models.User");

                    b.Property<int>("Miles");

                    b.ToTable("UserMatmid");

                    b.HasDiscriminator().HasValue("UserMatmid");
                });

            modelBuilder.Entity("PaiAirlines.Models.AircraftFlight", b =>
                {
                    b.HasOne("PaiAirlines.Models.Aircraft", "arcft")
                        .WithMany()
                        .HasForeignKey("arcftID");

                    b.HasOne("PaiAirlines.Models.Flight", "flght")
                        .WithMany()
                        .HasForeignKey("flghtID");

                    b.HasOne("PaiAirlines.Models.Schedule", "schdl")
                        .WithMany()
                        .HasForeignKey("schdlID");
                });

            modelBuilder.Entity("PaiAirlines.Models.Airport", b =>
                {
                    b.HasOne("PaiAirlines.Models.City", "cty")
                        .WithMany()
                        .HasForeignKey("ctyID");
                });

            modelBuilder.Entity("PaiAirlines.Models.Price", b =>
                {
                    b.HasOne("PaiAirlines.Models.Flight", "flght")
                        .WithMany()
                        .HasForeignKey("flghtID");

                    b.HasOne("PaiAirlines.Models.Schedule", "schdl")
                        .WithMany()
                        .HasForeignKey("schdlID");
                });

            modelBuilder.Entity("PaiAirlines.Models.Schedule", b =>
                {
                    b.HasOne("PaiAirlines.Models.Flight", "Flt")
                        .WithMany()
                        .HasForeignKey("FltID");
                });

            modelBuilder.Entity("PaiAirlines.Models.Seat", b =>
                {
                    b.HasOne("PaiAirlines.Models.Aircraft", "Arcft")
                        .WithMany()
                        .HasForeignKey("ArcftID");
                });

            modelBuilder.Entity("PaiAirlines.Models.Ticket", b =>
                {
                    b.HasOne("PaiAirlines.Models.User", "UserID")
                        .WithMany()
                        .HasForeignKey("UserIDID");
                });
        }
    }
}
