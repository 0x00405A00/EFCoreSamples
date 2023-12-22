using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "CreatedTime",
                value: new DateTime(2023, 12, 22, 18, 21, 4, 381, DateTimeKind.Local).AddTicks(8148));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "CreatedTime",
                value: new DateTime(2023, 12, 22, 18, 10, 18, 946, DateTimeKind.Local).AddTicks(6057));
        }
    }
}
