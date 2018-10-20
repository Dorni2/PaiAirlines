using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaiAirlines.Migrations
{
    public partial class CityFixCntrId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CntrID",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_CntrID",
                table: "City");

            migrationBuilder.AlterColumn<int>(
                name: "CntrID",
                table: "City",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CntrID",
                table: "City",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_City_CntrID",
                table: "City",
                column: "CntrID");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CntrID",
                table: "City",
                column: "CntrID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
