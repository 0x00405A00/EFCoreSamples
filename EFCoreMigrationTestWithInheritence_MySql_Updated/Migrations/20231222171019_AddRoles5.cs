using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_type",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", maxLength: 64, nullable: false),
                    user_type_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, defaultValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_USER_ID_TO_USERTYPE",
                        column: x => x.user_type_id,
                        principalTable: "user_type",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_has_relation_to_role",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    role_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, defaultValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b")),
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.role_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_user_has_relation_to_role_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_has_relation_to_role_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "uuid", "Name" },
                values: new object[,]
                {
                    { new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"), "Admin" },
                    { new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"), "User" }
                });

            migrationBuilder.InsertData(
                table: "user_type",
                columns: new[] { "uuid", "Name" },
                values: new object[,]
                {
                    { new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"), "Root" },
                    { new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"), "User" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "uuid", "CreatedTime", "Email", "Name", "Password", "user_type_id" },
                values: new object[] { new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 22, 18, 10, 18, 946, DateTimeKind.Local).AddTicks(6057), "root@localhost", "Root", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") });

            migrationBuilder.CreateIndex(
                name: "IDX_ID",
                table: "role",
                column: "uuid");

            migrationBuilder.CreateIndex(
                name: "IDX_ID1",
                table: "user",
                column: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_user_user_type_id",
                table: "user",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_USERHASRELATIONTOROLE_ID_ROLE",
                table: "user_has_relation_to_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_USERHASRELATIONTOROLE_ID_USER",
                table: "user_has_relation_to_role",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IDX_ID2",
                table: "user_type",
                column: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_has_relation_to_role");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "user_type");
        }
    }
}
