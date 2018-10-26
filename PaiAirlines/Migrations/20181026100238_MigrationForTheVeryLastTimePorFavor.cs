using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaiAirlines.Migrations
{
    public partial class MigrationForTheVeryLastTimePorFavor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Aircraft_ArcftID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Flight_FltID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Schedule_ScdlID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_UsrID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ArcftID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_FltID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ScdlID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_UsrID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "ArcftID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "FltID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "ScdlID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "UsrID",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Flight",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlightID",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Booking",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "FlightID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "ArcftID",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FltID",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScdlID",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsrID",
                table: "Booking",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Aircraft_ArcftID",
                table: "Booking",
                column: "ArcftID",
                principalTable: "Aircraft",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Flight_FltID",
                table: "Booking",
                column: "FltID",
                principalTable: "Flight",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Schedule_ScdlID",
                table: "Booking",
                column: "ScdlID",
                principalTable: "Schedule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_UsrID",
                table: "Booking",
                column: "UsrID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
