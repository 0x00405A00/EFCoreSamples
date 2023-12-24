using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Migrations
{
    /// <inheritdoc />
    public partial class AddLastModifiedByUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_type",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 47, DateTimeKind.Local).AddTicks(1570),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 787, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.AddColumn<Guid>(
                name: "modified_by_uuid",
                table: "user_type",
                type: "char(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_has_relation_to_role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 62, DateTimeKind.Local).AddTicks(3991),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 799, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.AddColumn<Guid>(
                name: "modified_by_uuid",
                table: "user_has_relation_to_role",
                type: "char(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 50, DateTimeKind.Local).AddTicks(7965),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 789, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.AddColumn<Guid>(
                name: "modified_by_uuid",
                table: "user",
                type: "char(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 59, DateTimeKind.Local).AddTicks(4740),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 797, DateTimeKind.Local).AddTicks(6364));

            migrationBuilder.AddColumn<Guid>(
                name: "modified_by_uuid",
                table: "role",
                type: "char(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"),
                columns: new[] { "created_time", "modified_by_uuid" },
                values: new object[] { new DateTime(2023, 12, 24, 15, 5, 10, 59, DateTimeKind.Local).AddTicks(5303), null });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"),
                columns: new[] { "created_time", "modified_by_uuid" },
                values: new object[] { new DateTime(2023, 12, 24, 15, 5, 10, 59, DateTimeKind.Local).AddTicks(5307), null });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "uuid",
                keyValue: new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"),
                columns: new[] { "created_time", "modified_by_uuid" },
                values: new object[] { new DateTime(2023, 12, 24, 15, 5, 10, 57, DateTimeKind.Local).AddTicks(2372), null });

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"),
                columns: new[] { "created_time", "modified_by_uuid" },
                values: new object[] { new DateTime(2023, 12, 24, 15, 5, 10, 47, DateTimeKind.Local).AddTicks(2143), null });

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"),
                columns: new[] { "created_time", "modified_by_uuid" },
                values: new object[] { new DateTime(2023, 12, 24, 15, 5, 10, 47, DateTimeKind.Local).AddTicks(2140), null });

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER3",
                table: "user_type",
                column: "modified_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER2",
                table: "user_has_relation_to_role",
                column: "modified_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER1",
                table: "user",
                column: "modified_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER",
                table: "role",
                column: "modified_by_uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_role_user_modified_by_uuid",
                table: "role",
                column: "modified_by_uuid",
                principalTable: "user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_modified_by_uuid",
                table: "user",
                column: "modified_by_uuid",
                principalTable: "user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_user_has_relation_to_role_user_modified_by_uuid",
                table: "user_has_relation_to_role",
                column: "modified_by_uuid",
                principalTable: "user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_user_type_user_modified_by_uuid",
                table: "user_type",
                column: "modified_by_uuid",
                principalTable: "user",
                principalColumn: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_user_modified_by_uuid",
                table: "role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_user_modified_by_uuid",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_user_has_relation_to_role_user_modified_by_uuid",
                table: "user_has_relation_to_role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_type_user_modified_by_uuid",
                table: "user_type");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER3",
                table: "user_type");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER2",
                table: "user_has_relation_to_role");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER1",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IDX_FK_TENTITY_LASTMODIFIEDTIME_USER",
                table: "role");

            migrationBuilder.DropColumn(
                name: "modified_by_uuid",
                table: "user_type");

            migrationBuilder.DropColumn(
                name: "modified_by_uuid",
                table: "user_has_relation_to_role");

            migrationBuilder.DropColumn(
                name: "modified_by_uuid",
                table: "user");

            migrationBuilder.DropColumn(
                name: "modified_by_uuid",
                table: "role");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_type",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 787, DateTimeKind.Local).AddTicks(7154),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 47, DateTimeKind.Local).AddTicks(1570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user_has_relation_to_role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 799, DateTimeKind.Local).AddTicks(995),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 62, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "user",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 789, DateTimeKind.Local).AddTicks(5835),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 50, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_time",
                table: "role",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 24, 15, 3, 48, 797, DateTimeKind.Local).AddTicks(6364),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 24, 15, 5, 10, 59, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 3, 48, 797, DateTimeKind.Local).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "uuid",
                keyValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 3, 48, 797, DateTimeKind.Local).AddTicks(6975));

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
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 3, 48, 787, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "user_type",
                keyColumn: "uuid",
                keyValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"),
                column: "created_time",
                value: new DateTime(2023, 12, 24, 15, 3, 48, 787, DateTimeKind.Local).AddTicks(7679));
        }
    }
}
