using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNoToCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNo", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Rajkot", "Tech Solutions", "1234567890", "12121", "Gujarat", "123 tech St" },
                    { 2, "Ahemedabad", "Spark Solutions", "1634527890", "12121", "Gujarat", "123 Spark St" },
                    { 3, "Surat", "Viv Solutions", "1324067891", "12122", "Gujarat", "123 Viv St" },
                    { 4, "Bhavnagar", "Bios Solutions", "7894561230", "12121", "Gujarat", "123 Bios St" },
                    { 5, "Junagadh", "Click Solutions", "4567891230", "12521", "Gujarat", "123 Click St" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);

        }
    }
}
