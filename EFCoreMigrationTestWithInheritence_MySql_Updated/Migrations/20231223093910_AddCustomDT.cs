using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomDT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "user");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "user_type",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateTime",
                table: "user_type",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "user_type",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "user_has_relation_to_role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateTime",
                table: "user_has_relation_to_role",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "user_has_relation_to_role",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "user",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateTime",
                table: "user",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "user",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateTime",
                table: "role",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "role",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"),
                columns: new[] { "CreatedDateTime", "DeletedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 39, 10, 342, DateTimeKind.Local).AddTicks(2818), null, null });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"),
                columns: new[] { "CreatedDateTime", "DeletedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 39, 10, 342, DateTimeKind.Local).AddTicks(2829), null, null });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                columns: new[] { "CreatedDateTime", "DeletedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 39, 10, 342, DateTimeKind.Local).AddTicks(1854), null, null });

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"),
                columns: new[] { "CreatedDateTime", "DeletedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 39, 10, 341, DateTimeKind.Local).AddTicks(2684), null, null });

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"),
                columns: new[] { "CreatedDateTime", "DeletedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2023, 12, 23, 10, 39, 10, 341, DateTimeKind.Local).AddTicks(2628), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_user_user_type_id",
                table: "user",
                column: "user_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_type_user_type_id",
                table: "user",
                column: "user_type_id",
                principalTable: "user_type",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_user_type_user_type_id",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_user_type_id",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "user_type");

            migrationBuilder.DropColumn(
                name: "DeletedDateTime",
                table: "user_type");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "user_type");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "user_has_relation_to_role");

            migrationBuilder.DropColumn(
                name: "DeletedDateTime",
                table: "user_has_relation_to_role");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "user_has_relation_to_role");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "user");

            migrationBuilder.DropColumn(
                name: "DeletedDateTime",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "role");

            migrationBuilder.DropColumn(
                name: "DeletedDateTime",
                table: "role");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "role");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "user",
                type: "datetime(6)",
                maxLength: 64,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "CreatedTime",
                value: new DateTime(2023, 12, 22, 18, 28, 51, 301, DateTimeKind.Local).AddTicks(3342));
        }
    }
}
