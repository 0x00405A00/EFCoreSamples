using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAddAuditing2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "e_user",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    created_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    modified_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    deleted_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    password = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    user_type_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, defaultValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b")),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 27, 16, 10, 13, 571, DateTimeKind.Local).AddTicks(1081)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_e_user_e_user_created_by_uuid",
                        column: x => x.created_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_e_user_e_user_deleted_by_uuid",
                        column: x => x.deleted_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_e_user_e_user_modified_by_uuid",
                        column: x => x.modified_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 27, 16, 10, 13, 581, DateTimeKind.Local).AddTicks(5539)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    modified_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    deleted_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_ROLE_CREATEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.created_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_ROLE_DELETEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.deleted_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_ROLE_LASTMODIFIEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.modified_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_type",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 27, 16, 10, 13, 563, DateTimeKind.Local).AddTicks(3763)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    modified_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    deleted_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_USERTYPE_CREATEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.created_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_USERTYPE_DELETEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.deleted_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_USERTYPE_LASTMODIFIEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.modified_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_has_relation_to_role",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    user_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    role_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, defaultValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b")),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 27, 16, 10, 13, 586, DateTimeKind.Local).AddTicks(8230)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_user_has_relation_to_role_e_user_user_id",
                        column: x => x.user_id,
                        principalTable: "e_user",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_userRoleToRole",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "uuid", "created_by_uuid", "created_time", "deleted_by_uuid", "deleted_time", "modified_by_uuid", "modified_time", "name" },
                values: new object[,]
                {
                    { new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"), null, new DateTime(2023, 12, 27, 16, 10, 13, 586, DateTimeKind.Local).AddTicks(3721), null, null, null, null, "Admin" },
                    { new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"), null, new DateTime(2023, 12, 27, 16, 10, 13, 586, DateTimeKind.Local).AddTicks(3727), null, null, null, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "user_type",
                columns: new[] { "uuid", "created_by_uuid", "created_time", "deleted_by_uuid", "deleted_time", "modified_by_uuid", "modified_time", "name" },
                values: new object[,]
                {
                    { new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"), null, new DateTime(2023, 12, 27, 16, 10, 13, 569, DateTimeKind.Local).AddTicks(6233), null, null, null, null, "Root" },
                    { new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"), null, new DateTime(2023, 12, 27, 16, 10, 13, 569, DateTimeKind.Local).AddTicks(6227), null, null, null, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "e_user",
                columns: new[] { "uuid", "created_by_uuid", "created_time", "deleted_by_uuid", "deleted_time", "email", "modified_by_uuid", "modified_time", "name", "password", "user_type_id" },
                values: new object[] { new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), null, new DateTime(2023, 12, 27, 16, 10, 13, 580, DateTimeKind.Local).AddTicks(9745), null, null, "root@localhost", null, null, "Root", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") });

            migrationBuilder.CreateIndex(
                name: "IX_e_user_created_by_uuid",
                table: "e_user",
                column: "created_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_e_user_deleted_by_uuid",
                table: "e_user",
                column: "deleted_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_e_user_modified_by_uuid",
                table: "e_user",
                column: "modified_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_e_user_user_type_id",
                table: "e_user",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_created_by_uuid",
                table: "role",
                column: "created_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_role_deleted_by_uuid",
                table: "role",
                column: "deleted_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_role_modified_by_uuid",
                table: "role",
                column: "modified_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_USERHASRELATIONTOROLE_ROLEFOREIGNKEY_ROLE",
                table: "user_has_relation_to_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_USERHASRELATIONTOROLE_USERFOREIGNKEY_EUSER",
                table: "user_has_relation_to_role",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_type_created_by_uuid",
                table: "user_type",
                column: "created_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_user_type_deleted_by_uuid",
                table: "user_type",
                column: "deleted_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_user_type_modified_by_uuid",
                table: "user_type",
                column: "modified_by_uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_e_user_user_type_user_type_id",
                table: "e_user",
                column: "user_type_id",
                principalTable: "user_type",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_e_user_user_type_user_type_id",
                table: "e_user");

            migrationBuilder.DropTable(
                name: "user_has_relation_to_role");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user_type");

            migrationBuilder.DropTable(
                name: "e_user");
        }
    }
}
