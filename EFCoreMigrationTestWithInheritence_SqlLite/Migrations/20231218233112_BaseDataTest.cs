using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreMigrationTestWithInheritence_SqlLite.Migrations
{
    /// <inheritdoc />
    public partial class BaseDataTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user_type",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { new Guid("3d578ea4-c790-44c9-90eb-af5467c62ad1"), "Root" },
                    { new Guid("792cf741-ac63-4383-acf5-315e9c78107d"), "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_type",
                keyColumn: "id",
                keyValue: new Guid("3d578ea4-c790-44c9-90eb-af5467c62ad1"));

            migrationBuilder.DeleteData(
                table: "user_type",
                keyColumn: "id",
                keyValue: new Guid("792cf741-ac63-4383-acf5-315e9c78107d"));
        }
    }
}
