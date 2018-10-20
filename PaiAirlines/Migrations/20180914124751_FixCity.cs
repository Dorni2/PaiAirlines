using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PaiAirlines.Migrations
{
    public partial class FixCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BussinessSeats = table.Column<int>(nullable: false),
                    EconomySeats = table.Column<int>(nullable: false),
                    FirstSeats = table.Column<int>(nullable: false),
                    Range = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArcftID = table.Column<int>(nullable: true),
                    ClassId = table.Column<int>(nullable: false),
                    SeatNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seat_Aircraft_ArcftID",
                        column: x => x.ArcftID,
                        principalTable: "Aircraft",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CntrID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                    table.ForeignKey(
                        name: "FK_City_Country_CntrID",
                        column: x => x.CntrID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Coordinates = table.Column<int>(nullable: false),
                    IATAcode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ctyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Airport_City_ctyID",
                        column: x => x.ctyID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CntryID = table.Column<int>(nullable: true),
                    CtyID = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsMatmid = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Miles = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Country_CntryID",
                        column: x => x.CntryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_City_CtyID",
                        column: x => x.CtyID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DestinationIdID = table.Column<int>(nullable: true),
                    FlightNumber = table.Column<int>(nullable: false),
                    OriginIdID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_DestinationIdID",
                        column: x => x.DestinationIdID,
                        principalTable: "Airport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_OriginIdID",
                        column: x => x.OriginIdID,
                        principalTable: "Airport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arrival = table.Column<DateTime>(nullable: false),
                    Boarding = table.Column<DateTime>(nullable: false),
                    Departure = table.Column<DateTime>(nullable: false),
                    FltID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Schedule_Flight_FltID",
                        column: x => x.FltID,
                        principalTable: "Flight",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AircraftFlight",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BussinessSeatsTaken = table.Column<int>(nullable: false),
                    EconomySeatsTaken = table.Column<int>(nullable: false),
                    FirstSeatsTaken = table.Column<int>(nullable: false),
                    arcftID = table.Column<int>(nullable: true),
                    flghtID = table.Column<int>(nullable: true),
                    schdlID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftFlight", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AircraftFlight_Aircraft_arcftID",
                        column: x => x.arcftID,
                        principalTable: "Aircraft",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AircraftFlight_Flight_flghtID",
                        column: x => x.flghtID,
                        principalTable: "Flight",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AircraftFlight_Schedule_schdlID",
                        column: x => x.schdlID,
                        principalTable: "Schedule",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArcftID = table.Column<int>(nullable: true),
                    FltID = table.Column<int>(nullable: true),
                    ScdlID = table.Column<int>(nullable: true),
                    TotalPrice = table.Column<int>(nullable: false),
                    UsrID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Booking_Aircraft_ArcftID",
                        column: x => x.ArcftID,
                        principalTable: "Aircraft",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Flight_FltID",
                        column: x => x.FltID,
                        principalTable: "Flight",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Schedule_ScdlID",
                        column: x => x.ScdlID,
                        principalTable: "Schedule",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_User_UsrID",
                        column: x => x.UsrID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bussiness = table.Column<int>(nullable: false),
                    Economy = table.Column<int>(nullable: false),
                    First = table.Column<int>(nullable: false),
                    LuggagePrice = table.Column<int>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    flghtID = table.Column<int>(nullable: true),
                    schdlID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Price_Flight_flghtID",
                        column: x => x.flghtID,
                        principalTable: "Flight",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Price_Schedule_schdlID",
                        column: x => x.schdlID,
                        principalTable: "Schedule",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    bknID = table.Column<int>(nullable: true),
                    seatID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ticket_Booking_bknID",
                        column: x => x.bknID,
                        principalTable: "Booking",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Seat_seatID",
                        column: x => x.seatID,
                        principalTable: "Seat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AircraftFlight_arcftID",
                table: "AircraftFlight",
                column: "arcftID");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftFlight_flghtID",
                table: "AircraftFlight",
                column: "flghtID");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftFlight_schdlID",
                table: "AircraftFlight",
                column: "schdlID");

            migrationBuilder.CreateIndex(
                name: "IX_Airport_ctyID",
                table: "Airport",
                column: "ctyID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ArcftID",
                table: "Booking",
                column: "ArcftID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FltID",
                table: "Booking",
                column: "FltID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ScdlID",
                table: "Booking",
                column: "ScdlID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UsrID",
                table: "Booking",
                column: "UsrID");

            migrationBuilder.CreateIndex(
                name: "IX_City_CntrID",
                table: "City",
                column: "CntrID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinationIdID",
                table: "Flight",
                column: "DestinationIdID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_OriginIdID",
                table: "Flight",
                column: "OriginIdID");

            migrationBuilder.CreateIndex(
                name: "IX_Price_flghtID",
                table: "Price",
                column: "flghtID");

            migrationBuilder.CreateIndex(
                name: "IX_Price_schdlID",
                table: "Price",
                column: "schdlID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_FltID",
                table: "Schedule",
                column: "FltID");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ArcftID",
                table: "Seat",
                column: "ArcftID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_bknID",
                table: "Ticket",
                column: "bknID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_seatID",
                table: "Ticket",
                column: "seatID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CntryID",
                table: "User",
                column: "CntryID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CtyID",
                table: "User",
                column: "CtyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftFlight");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
