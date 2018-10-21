using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaiAirlines.Migrations
{
    public partial class ChangingForTheSecondLastTimePorFavor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_City_DestinationIdID",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_City_OriginIdID",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_DestinationIdID",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_OriginIdID",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "DestinationIdID",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "OriginIdID",
                table: "Flight");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Flight",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "Flight",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "Flight");

            migrationBuilder.AddColumn<int>(
                name: "DestinationIdID",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginIdID",
                table: "Flight",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinationIdID",
                table: "Flight",
                column: "DestinationIdID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_OriginIdID",
                table: "Flight",
                column: "OriginIdID");

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
        }
    }
}
