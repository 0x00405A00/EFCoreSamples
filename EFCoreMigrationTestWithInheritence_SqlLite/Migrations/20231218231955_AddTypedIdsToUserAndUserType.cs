using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMigrationTestWithInheritence_SqlLite.Migrations
{
    /// <inheritdoc />
    public partial class AddTypedIdsToUserAndUserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "user_type",
                type: "TEXT",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 36)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "user",
                type: "TEXT",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 36)
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "user_type",
                type: "INTEGER",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldMaxLength: 36)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "user",
                type: "INTEGER",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldMaxLength: 36)
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
