using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaiAirlines.Migrations
{
    public partial class ChangingForTheLastTimePorFavor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_DestinationIdID",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_OriginIdID",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Booking_bknID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Seat_seatID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_bknID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CntryID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsMatmid",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "bknID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CntrID",
                table: "City");

            migrationBuilder.RenameColumn(
                name: "seatID",
                table: "Ticket",
                newName: "UserIDID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_seatID",
                table: "Ticket",
                newName: "IX_Ticket_UserIDID");

            migrationBuilder.AddColumn<int>(
                name: "FlightID",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Flight",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Flight",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_City_DestinationIdID",
                table: "Flight",
                column: "DestinationIdID",
                principalTable: "City",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_City_OriginIdID",
                table: "Flight",
                column: "OriginIdID",
                principalTable: "City",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_UserIDID",
                table: "Ticket",
                column: "UserIDID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_City_DestinationIdID",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_City_OriginIdID",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_User_UserIDID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "FlightID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Flight");

            migrationBuilder.RenameColumn(
                name: "UserIDID",
                table: "Ticket",
                newName: "seatID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UserIDID",
                table: "Ticket",
                newName: "IX_Ticket_seatID");

            migrationBuilder.AddColumn<int>(
                name: "CntryID",
                table: "User",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsMatmid",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "User",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "User",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "bknID",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CntrID",
                table: "City",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_bknID",
                table: "Ticket",
                column: "bknID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_DestinationIdID",
                table: "Flight",
                column: "DestinationIdID",
                principalTable: "Airport",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_OriginIdID",
                table: "Flight",
                column: "OriginIdID",
                principalTable: "Airport",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Booking_bknID",
                table: "Ticket",
                column: "bknID",
                principalTable: "Booking",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Seat_seatID",
                table: "Ticket",
                column: "seatID",
                principalTable: "Seat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
