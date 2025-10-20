using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DOTNET.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addedstudentseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "EnrollmentDate", "FirstName", "Gender", "Initials", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agatha", 0, "R", "John", "AghathaRJohnbull.jpg" },
                    { 3, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrew", 0, "B", "Johnson", "AndrewBJohnson.jpg" },
                    { 4, new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beauty", 0, "U", "Karthryn", "BeautyUKartryn.jpg" },
                    { 5, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clement", 0, "T", "Chukwu", "ClementTChukwu.jpg" },
                    { 6, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", 0, "Y", "Harriman", "JaneYHarriman.jpg" },
                    { 7, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Josephine", 0, "T", "Aliu", "JosephineTAliu.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
