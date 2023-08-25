using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical_Athena_Calendly.Migrations
{
    /// <inheritdoc />
    public partial class udatecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "user",
                newName: "LastName");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DOB",
                table: "user",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "user");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "user",
                newName: "Name");
        }
    }
}
