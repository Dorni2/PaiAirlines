using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaiAirlines.Migrations
{
    public partial class UserModelFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Country_CntryID",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_City_CtyID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CntryID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CtyID",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "User",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "User",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CtyID",
                table: "User",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CntryID",
                table: "User",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "CtyID",
                table: "User",
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "CntryID",
                table: "User",
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_User_CntryID",
                table: "User",
                column: "CntryID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CtyID",
                table: "User",
                column: "CtyID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Country_CntryID",
                table: "User",
                column: "CntryID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_City_CtyID",
                table: "User",
                column: "CtyID",
                principalTable: "City",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
