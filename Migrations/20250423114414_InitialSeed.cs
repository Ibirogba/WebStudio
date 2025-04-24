using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebStudio.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Company Id", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("76032384-50ad-4903-9889-f0e95ac9eedf"), "75 Ogunnusi Road, Off Ojodu-Berger, Ogba, Lagos-State", "NIGERIA", "WALURE CAPITAL" },
                    { new Guid("8d19dc2d-f84a-4ddb-9980-5f9326661dd0"), "62 Ajayi Road, Ogba, Ikeja", "NIGERIA", "VISION STEP" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Employee Id", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("35a06106-30f5-44e1-8998-014fc629db35"), 22, new Guid("76032384-50ad-4903-9889-f0e95ac9eedf"), "Ibirogba Taiwo", "Software Engineer" },
                    { new Guid("a780950f-9138-46c9-93aa-cec6c227f38a"), 25, new Guid("76032384-50ad-4903-9889-f0e95ac9eedf"), "Mercy Vivian", "Software Engineer" },
                    { new Guid("b60d66c9-528e-4874-bad8-0c6e7e73bcbe"), 26, new Guid("8d19dc2d-f84a-4ddb-9980-5f9326661dd0"), "Pearson Goodness", "Sales Person" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Employee Id",
                keyValue: new Guid("35a06106-30f5-44e1-8998-014fc629db35"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Employee Id",
                keyValue: new Guid("a780950f-9138-46c9-93aa-cec6c227f38a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Employee Id",
                keyValue: new Guid("b60d66c9-528e-4874-bad8-0c6e7e73bcbe"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Company Id",
                keyValue: new Guid("76032384-50ad-4903-9889-f0e95ac9eedf"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Company Id",
                keyValue: new Guid("8d19dc2d-f84a-4ddb-9980-5f9326661dd0"));
        }
    }
}
