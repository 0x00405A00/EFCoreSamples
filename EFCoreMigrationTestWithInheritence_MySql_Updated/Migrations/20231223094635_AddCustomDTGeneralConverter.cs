using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomDTGeneralConverter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"),
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 23, 10, 46, 35, 875, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 23, 10, 46, 35, 875, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 23, 10, 46, 35, 875, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"),
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 23, 10, 46, 35, 874, DateTimeKind.Local).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 23, 10, 46, 35, 874, DateTimeKind.Local).AddTicks(4594));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"),
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 23, 10, 39, 10, 342, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 23, 10, 39, 10, 342, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 23, 10, 39, 10, 342, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"),
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 23, 10, 39, 10, 341, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 23, 10, 39, 10, 341, DateTimeKind.Local).AddTicks(2628));
        }
    }
}
