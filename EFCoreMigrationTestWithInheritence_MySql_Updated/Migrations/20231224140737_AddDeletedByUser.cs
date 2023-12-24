using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedByUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_type",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 7, 37, 544, DateTimeKind.Local).AddTicks(1),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 47, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_uuid",
                table: "user_type",
                type: "char(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_has_relation_to_role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 7, 37, 565, DateTimeKind.Local).AddTicks(9370),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 62, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_uuid",
                table: "user_has_relation_to_role",
                type: "char(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 7, 37, 550, DateTimeKind.Local).AddTicks(1453),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 50, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_uuid",
                table: "user",
                type: "char(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 7, 37, 561, DateTimeKind.Local).AddTicks(3107),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 59, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by_uuid",
                table: "role",
                type: "char(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"),
                columns: new[] { "created_time", "deleted_by_uuid" },
                values: new object[] { new DateTime(2023, 12, 24, 15, 7, 37, 561, DateTimeKind.Local).AddTicks(4163), null });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"),
                columns: new[] { "created_time", "deleted_by_uuid" },
                values: new object[] { new DateTime(2023, 12, 24, 15, 7, 37, 561, DateTimeKind.Local).AddTicks(4166), null });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                columns: new[] { "created_time", "deleted_by_uuid" },
                values: new object[] { new DateTime(2023, 12, 24, 15, 7, 37, 557, DateTimeKind.Local).AddTicks(8626), null });

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"),
                columns: new[] { "created_time", "deleted_by_uuid" },
                values: new object[] { new DateTime(2023, 12, 24, 15, 7, 37, 544, DateTimeKind.Local).AddTicks(850), null });

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"),
                columns: new[] { "created_time", "deleted_by_uuid" },
                values: new object[] { new DateTime(2023, 12, 24, 15, 7, 37, 544, DateTimeKind.Local).AddTicks(847), null });

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_DELETEDBYUSER_USER3",
                table: "user_type",
                column: "deleted_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_DELETEDBYUSER_USER2",
                table: "user_has_relation_to_role",
                column: "deleted_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_DELETEDBYUSER_USER1",
                table: "user",
                column: "deleted_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_DELETEDBYUSER_USER",
                table: "role",
                column: "deleted_by_uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_role_user_deleted_by_uuid",
                table: "role",
                column: "deleted_by_uuid",
                principalTable: "user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_deleted_by_uuid",
                table: "user",
                column: "deleted_by_uuid",
                principalTable: "user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_user_has_relation_to_role_user_deleted_by_uuid",
                table: "user_has_relation_to_role",
                column: "deleted_by_uuid",
                principalTable: "user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_user_type_user_deleted_by_uuid",
                table: "user_type",
                column: "deleted_by_uuid",
                principalTable: "user",
                principalColumn: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_user_deleted_by_uuid",
                table: "role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_user_deleted_by_uuid",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_user_has_relation_to_role_user_deleted_by_uuid",
                table: "user_has_relation_to_role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_type_user_deleted_by_uuid",
                table: "user_type");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_DELETEDBYUSER_USER3",
                table: "user_type");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_DELETEDBYUSER_USER2",
                table: "user_has_relation_to_role");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_DELETEDBYUSER_USER1",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_DELETEDBYUSER_USER",
                table: "role");

            migrationBuilder.DropColumn(
                name: "deleted_by_uuid",
                table: "user_type");

            migrationBuilder.DropColumn(
                name: "deleted_by_uuid",
                table: "user_has_relation_to_role");

            migrationBuilder.DropColumn(
                name: "deleted_by_uuid",
                table: "user");

            migrationBuilder.DropColumn(
                name: "deleted_by_uuid",
                table: "role");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_type",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 47, DateTimeKind.Local).AddTicks(1570),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 7, 37, 544, DateTimeKind.Local).AddTicks(1));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_has_relation_to_role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 62, DateTimeKind.Local).AddTicks(3991),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 7, 37, 565, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 50, DateTimeKind.Local).AddTicks(7965),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 7, 37, 550, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 59, DateTimeKind.Local).AddTicks(4740),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 7, 37, 561, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 5, 10, 59, DateTimeKind.Local).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 5, 10, 59, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 5, 10, 57, DateTimeKind.Local).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 5, 10, 47, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 5, 10, 47, DateTimeKind.Local).AddTicks(2140));
        }
    }
}
