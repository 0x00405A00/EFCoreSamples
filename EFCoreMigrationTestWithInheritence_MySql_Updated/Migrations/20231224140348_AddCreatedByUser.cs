using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_type",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 787, DateTimeKind.Local).AddTicks(7154),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 0, 38, 274, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_uuid",
                table: "user_type",
                type: "char(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_has_relation_to_role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 799, DateTimeKind.Local).AddTicks(995),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 0, 38, 279, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "user_has_relation_to_role",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_uuid",
                table: "user_has_relation_to_role",
                type: "char(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 789, DateTimeKind.Local).AddTicks(5835),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 0, 38, 276, DateTimeKind.Local).AddTicks(3237));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_uuid",
                table: "user",
                type: "char(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 797, DateTimeKind.Local).AddTicks(6364),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 0, 38, 279, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_uuid",
                table: "role",
                type: "char(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"),
                columns: new[] { "created_by_uuid", "created_time" },
                values: new object[] { new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 24, 15, 3, 48, 797, DateTimeKind.Local).AddTicks(6914) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"),
                columns: new[] { "created_by_uuid", "created_time" },
                values: new object[] { new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 24, 15, 3, 48, 797, DateTimeKind.Local).AddTicks(6975) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 3, 48, 796, DateTimeKind.Local).AddTicks(2817));

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"),
                columns: new[] { "created_by_uuid", "created_time" },
                values: new object[] { new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 24, 15, 3, 48, 787, DateTimeKind.Local).AddTicks(7683) });

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"),
                columns: new[] { "created_by_uuid", "created_time" },
                values: new object[] { new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 24, 15, 3, 48, 787, DateTimeKind.Local).AddTicks(7679) });

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_CREATEDBYUSER_USER3",
                table: "user_type",
                column: "created_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_CREATEDBYUSER_USER2",
                table: "user_has_relation_to_role",
                column: "created_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_user_has_relation_to_role_UsersId",
                table: "user_has_relation_to_role",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_CREATEDBYUSER_USER1",
                table: "user",
                column: "created_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_CREATEDBYUSER_USER",
                table: "role",
                column: "created_by_uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_role_user_created_by_uuid",
                table: "role",
                column: "created_by_uuid",
                principalTable: "user",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_created_by_uuid",
                table: "user",
                column: "created_by_uuid",
                principalTable: "user",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_has_relation_to_role_user_UsersId",
                table: "user_has_relation_to_role",
                column: "UsersId",
                principalTable: "user",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_has_relation_to_role_user_created_by_uuid",
                table: "user_has_relation_to_role",
                column: "created_by_uuid",
                principalTable: "user",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_type_user_created_by_uuid",
                table: "user_type",
                column: "created_by_uuid",
                principalTable: "user",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_user_created_by_uuid",
                table: "role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_user_created_by_uuid",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_user_has_relation_to_role_user_UsersId",
                table: "user_has_relation_to_role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_has_relation_to_role_user_created_by_uuid",
                table: "user_has_relation_to_role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_type_user_created_by_uuid",
                table: "user_type");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_CREATEDBYUSER_USER3",
                table: "user_type");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_CREATEDBYUSER_USER2",
                table: "user_has_relation_to_role");

            migrationBuilder.DropIndex(
                name: "IX_user_has_relation_to_role_UsersId",
                table: "user_has_relation_to_role");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_CREATEDBYUSER_USER1",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_CREATEDBYUSER_USER",
                table: "role");

            migrationBuilder.DropColumn(
                name: "created_by_uuid",
                table: "user_type");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "user_has_relation_to_role");

            migrationBuilder.DropColumn(
                name: "created_by_uuid",
                table: "user_has_relation_to_role");

            migrationBuilder.DropColumn(
                name: "created_by_uuid",
                table: "user");

            migrationBuilder.DropColumn(
                name: "created_by_uuid",
                table: "role");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_type",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 0, 38, 274, DateTimeKind.Local).AddTicks(8435),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 787, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_has_relation_to_role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 0, 38, 279, DateTimeKind.Local).AddTicks(7006),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 799, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 0, 38, 276, DateTimeKind.Local).AddTicks(3237),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 789, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 0, 38, 279, DateTimeKind.Local).AddTicks(1934),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 797, DateTimeKind.Local).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 0, 38, 279, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 0, 38, 279, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 0, 38, 278, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 0, 38, 274, DateTimeKind.Local).AddTicks(8974));

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 0, 38, 274, DateTimeKind.Local).AddTicks(8970));
        }
    }
}
