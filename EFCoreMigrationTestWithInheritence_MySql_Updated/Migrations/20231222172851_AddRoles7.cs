using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USER_ID_TO_USERTYPE",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_user_type_id",
                table: "user");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "CreatedTime",
                value: new DateTime(2023, 12, 22, 18, 28, 51, 301, DateTimeKind.Local).AddTicks(3342));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "CreatedTime",
                value: new DateTime(2023, 12, 22, 18, 21, 4, 381, DateTimeKind.Local).AddTicks(8148));

            migrationBuilder.CreateIndex(
                name: "IX_user_user_type_id",
                table: "user",
                column: "user_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_USER_ID_TO_USERTYPE",
                table: "user",
                column: "user_type_id",
                principalTable: "user_type",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
