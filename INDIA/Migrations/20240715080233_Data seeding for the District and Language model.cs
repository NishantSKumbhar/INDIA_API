using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace INDIA.Migrations
{
    /// <inheritdoc />
    public partial class DataseedingfortheDistrictandLanguagemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "AreaInSqrKm", "Code", "DistrictImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("02c0ee3c-0734-4bd8-aee0-c891cffaa6d4"), 19999.0, "PNQ", "pune/baner.jpg", "Pune" },
                    { new Guid("04da054a-fe7f-4961-bb72-5342c389bae7"), 17293.0, "SNGL", "sangali/faui.png", "Sangali" },
                    { new Guid("05536da6-f49d-4dab-80fe-567597c047d8"), 17899.0, "KLPR", null, "Kolhapur" },
                    { new Guid("47a5276e-5ae0-4c5f-982a-638a5aba10d5"), 19829.0, "STRA", "satara/patan.jpeg", "Satara" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("07a4c903-83c1-4d51-8398-94a9ca8905a3"), "Marathi" },
                    { new Guid("1c47dbde-52d9-497d-9f9b-9ccb2cc28dfa"), "Telugu" },
                    { new Guid("5d5992b3-55a4-48ec-b18f-2f9ef4544614"), "Kannada" },
                    { new Guid("64b3bf89-e50f-4297-919a-36194660c9fc"), "Hindi" },
                    { new Guid("77b4897f-5aaf-47b2-9404-6b7b2e60760a"), "Tamil" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("02c0ee3c-0734-4bd8-aee0-c891cffaa6d4"));

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("04da054a-fe7f-4961-bb72-5342c389bae7"));

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("05536da6-f49d-4dab-80fe-567597c047d8"));

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("47a5276e-5ae0-4c5f-982a-638a5aba10d5"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("07a4c903-83c1-4d51-8398-94a9ca8905a3"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("1c47dbde-52d9-497d-9f9b-9ccb2cc28dfa"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("5d5992b3-55a4-48ec-b18f-2f9ef4544614"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("64b3bf89-e50f-4297-919a-36194660c9fc"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("77b4897f-5aaf-47b2-9404-6b7b2e60760a"));
        }
    }
}
