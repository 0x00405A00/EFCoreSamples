using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "auth",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    user_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    remote_ip = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    remote_port = table.Column<uint>(type: "int unsigned", maxLength: 5, nullable: false),
                    local_ip = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    local_port = table.Column<uint>(type: "int unsigned", maxLength: 5, nullable: false),
                    token = table.Column<string>(type: "varchar(4096)", maxLength: 4096, nullable: false),
                    token_expires_in = table.Column<DateTime>(type: "datetime", nullable: false),
                    browser_user_agent = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    refresh_token_expires_in = table.Column<DateTime>(type: "datetime", nullable: false),
                    refresh_token = table.Column<string>(type: "varchar(4096)", maxLength: 4096, nullable: false),
                    logout_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 2, 31, 20, 19, DateTimeKind.Local).AddTicks(4757)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chat",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    picture_path = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true),
                    picture_path_file_extension = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 2, 31, 20, 22, DateTimeKind.Local).AddTicks(6506)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    modified_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    deleted_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chat_relation_to_user",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    chat_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    is_admin = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: false, comment: "boolean value to describe if chatmember is chat-admin"),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 2, 31, 20, 33, DateTimeKind.Local).AddTicks(3208)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    created_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    modified_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    deleted_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_relation_to_user", x => new { x.user_id, x.chat_id });
                    table.ForeignKey(
                        name: "FK_CHATRELATIONTOUSER_CHATFOREIGNKEY_TO_CHAT",
                        column: x => x.chat_id,
                        principalTable: "chat",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "e_user",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    password = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    user_type_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, defaultValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b")),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 2, 31, 19, 994, DateTimeKind.Local).AddTicks(6035)),
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
                        name: "FK_EUSER_CREATEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.created_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_EUSER_DELETEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.deleted_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_EUSER_LASTMODIFIEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.modified_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "friendship_request",
                columns: table => new
                {
                    requester_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    target_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    request_message = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 2, 31, 19, 983, DateTimeKind.Local).AddTicks(338)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friendship_request", x => new { x.requester_id, x.target_id });
                    table.ForeignKey(
                        name: "FK_FRIENDSHIPREQUEST_REQUESTUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.requester_id,
                        principalTable: "e_user",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FRIENDSHIPREQUEST_TARGETUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.target_id,
                        principalTable: "e_user",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    chat_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    user_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    text = table.Column<string>(type: "TEXT", nullable: true),
                    binary_content_path = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true),
                    binary_content_path_file_extension = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    binary_content_base64 = table.Column<string>(type: "TEXT", nullable: true),
                    binary_content_base64_mime_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 2, 31, 20, 46, DateTimeKind.Local).AddTicks(632)),
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
                        name: "FK_MESSAGE_CHATFOREIGNKEY_TO_CHAT",
                        column: x => x.chat_id,
                        principalTable: "chat",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MESSAGE_CREATEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.created_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_MESSAGE_DELETEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.deleted_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_MESSAGE_LASTMODIFIEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.modified_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_MESSAGE_USERFOREIGNKEY_TO_EUSER",
                        column: x => x.user_id,
                        principalTable: "e_user",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 2, 31, 20, 11, DateTimeKind.Local).AddTicks(5228)),
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
                name: "user_has_relation_to_friend",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    friend_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 2, 31, 19, 977, DateTimeKind.Local).AddTicks(3040)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_has_relation_to_friend", x => new { x.user_id, x.friend_id });
                    table.ForeignKey(
                        name: "FK_USERHASRELATIONTOFRIEND_USERFOREIGNKEY_TO_EUSER",
                        column: x => x.user_id,
                        principalTable: "e_user",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USERHASRELATIONTOFRIEND_USERFRIENDFOREIGNKEY_TO_EUSER",
                        column: x => x.friend_id,
                        principalTable: "e_user",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_type",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 2, 31, 19, 967, DateTimeKind.Local).AddTicks(6940)),
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
                name: "message_outbox",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    message_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    user_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 2, 31, 20, 58, DateTimeKind.Local).AddTicks(2280)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_MESSAGEOUTBOX_MESSAGEFOREIGNKEY_TO_CHAT",
                        column: x => x.message_id,
                        principalTable: "message",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MESSAGEOUTBOX_USERFOREIGNKEY_TO_EUSER",
                        column: x => x.user_id,
                        principalTable: "e_user",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_has_relation_to_role",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    user_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    role_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, defaultValue: new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b")),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 2, 31, 20, 18, DateTimeKind.Local).AddTicks(8552)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_USERHASRELATIONTOROLE_ROLEFOREIGNKEY_TO_ROLE",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USERHASRELATIONTOROLE_USERFOREIGNKEY_TO_EUSER",
                        column: x => x.user_id,
                        principalTable: "e_user",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "uuid", "created_by_uuid", "created_time", "deleted_by_uuid", "deleted_time", "modified_by_uuid", "modified_time", "name" },
                values: new object[,]
                {
                    { new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"), null, new DateTime(2023, 12, 28, 2, 31, 20, 18, DateTimeKind.Local).AddTicks(3863), null, null, null, null, "Admin" },
                    { new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"), null, new DateTime(2023, 12, 28, 2, 31, 20, 18, DateTimeKind.Local).AddTicks(3894), null, null, null, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "user_type",
                columns: new[] { "uuid", "created_by_uuid", "created_time", "deleted_by_uuid", "deleted_time", "modified_by_uuid", "modified_time", "name" },
                values: new object[,]
                {
                    { new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"), null, new DateTime(2023, 12, 28, 2, 31, 19, 976, DateTimeKind.Local).AddTicks(8539), null, null, null, null, "Root" },
                    { new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"), null, new DateTime(2023, 12, 28, 2, 31, 19, 976, DateTimeKind.Local).AddTicks(8481), null, null, null, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "e_user",
                columns: new[] { "uuid", "created_by_uuid", "created_time", "deleted_by_uuid", "deleted_time", "email", "modified_by_uuid", "modified_time", "name", "password", "user_type_id" },
                values: new object[,]
                {
                    { new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), null, new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8439), null, null, "root@localhost", null, null, "Root", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("13fbd48a-abd1-4b33-85e4-c879c26ba9f6"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8666), null, null, "test9@localhost", null, new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8667), "Test9", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("146dfc1f-9ce0-4d56-ba66-ab4736164b0f"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8649), null, null, "test6@localhost", null, new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8650), "Test6", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("256e2ca9-4ff8-409c-b152-ab09681397e7"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8578), null, null, "test0@localhost", null, new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8580), "Test0", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("8cb91647-dcd0-41f6-b89b-b9eaf1f8041d"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8596), null, null, "test1@localhost", null, new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8597), "Test1", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("a971f50e-50e5-4c33-abe0-b2b4202db5c4"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8633), null, null, "test3@localhost", null, new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8634), "Test3", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("bba6a2f8-0f12-4c56-bf2a-a1a067090f30"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8653), null, null, "test7@localhost", null, new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8654), "Test7", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("d12671c9-baca-459a-bb18-38154a5a7787"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8638), null, null, "test4@localhost", null, new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8639), "Test4", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("d809ae39-d78f-45bd-b0e5-4422c4f03023"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8644), null, null, "test5@localhost", null, new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8645), "Test5", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("d9536f19-ca2b-446a-a36c-c97631f9b98b"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8657), null, null, "test8@localhost", null, new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8659), "Test8", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("fad11e86-70eb-4928-836c-e071a2b6c9d0"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8628), null, null, "test2@localhost", null, new DateTime(2023, 12, 28, 2, 31, 20, 10, DateTimeKind.Local).AddTicks(8629), "Test2", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_auth_user_uuid",
                table: "auth",
                column: "user_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_chat_created_by_uuid",
                table: "chat",
                column: "created_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_chat_deleted_by_uuid",
                table: "chat",
                column: "deleted_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_chat_modified_by_uuid",
                table: "chat",
                column: "modified_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_chat_relation_to_user_chat_id",
                table: "chat_relation_to_user",
                column: "chat_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_relation_to_user_created_by_uuid",
                table: "chat_relation_to_user",
                column: "created_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_chat_relation_to_user_deleted_by_uuid",
                table: "chat_relation_to_user",
                column: "deleted_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_chat_relation_to_user_modified_by_uuid",
                table: "chat_relation_to_user",
                column: "modified_by_uuid");

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
                name: "IDX_FK_FRIENDSHIPREQUEST_REQUESTERUSER_EUSER",
                table: "friendship_request",
                column: "requester_id");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_FRIENDSHIPREQUEST_TARGETUSER_EUSER",
                table: "friendship_request",
                column: "target_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_chat_id",
                table: "message",
                column: "chat_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_created_by_uuid",
                table: "message",
                column: "created_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_message_deleted_by_uuid",
                table: "message",
                column: "deleted_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_message_modified_by_uuid",
                table: "message",
                column: "modified_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_message_user_id",
                table: "message",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_outbox_message_id",
                table: "message_outbox",
                column: "message_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_outbox_user_id",
                table: "message_outbox",
                column: "user_id");

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
                name: "IDX_FK_USERHASRELATIONTOFRIEND_USERFOREIGNKEY_EUSER",
                table: "user_has_relation_to_friend",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_USERHASRELATIONTOFRIEND_USERFRIENDFOREIGNKEY_EUSER",
                table: "user_has_relation_to_friend",
                column: "friend_id");

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
                name: "FK_AUTH_USERID_TO_EUSER",
                table: "auth",
                column: "user_uuid",
                principalTable: "e_user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CHAT_CREATEDBYUSERFOREIGNKEY_TO_EUSER",
                table: "chat",
                column: "created_by_uuid",
                principalTable: "e_user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CHAT_DELETEDBYUSERFOREIGNKEY_TO_EUSER",
                table: "chat",
                column: "deleted_by_uuid",
                principalTable: "e_user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CHAT_LASTMODIFIEDBYUSERFOREIGNKEY_TO_EUSER",
                table: "chat",
                column: "modified_by_uuid",
                principalTable: "e_user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CHATRELATIONTOUSER_CREATEDBYUSERFOREIGNKEY_TO_EUSER",
                table: "chat_relation_to_user",
                column: "created_by_uuid",
                principalTable: "e_user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CHATRELATIONTOUSER_DELETEDBYUSERFOREIGNKEY_TO_EUSER",
                table: "chat_relation_to_user",
                column: "deleted_by_uuid",
                principalTable: "e_user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CHATRELATIONTOUSER_LASTMODIFIEDBYUSERFOREIGNKEY_TO_EUSER",
                table: "chat_relation_to_user",
                column: "modified_by_uuid",
                principalTable: "e_user",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CHATRELATIONTOUSER_USERFOREIGNKEY_TO_EUSER",
                table: "chat_relation_to_user",
                column: "user_id",
                principalTable: "e_user",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EUSER_USERTYPEFOREIGNKEY_TO_USERTYPE",
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
                name: "FK_USERTYPE_CREATEDBYUSERFOREIGNKEY_TO_EUSER",
                table: "user_type");

            migrationBuilder.DropForeignKey(
                name: "FK_USERTYPE_DELETEDBYUSERFOREIGNKEY_TO_EUSER",
                table: "user_type");

            migrationBuilder.DropForeignKey(
                name: "FK_USERTYPE_LASTMODIFIEDBYUSERFOREIGNKEY_TO_EUSER",
                table: "user_type");

            migrationBuilder.DropTable(
                name: "auth");

            migrationBuilder.DropTable(
                name: "chat_relation_to_user");

            migrationBuilder.DropTable(
                name: "friendship_request");

            migrationBuilder.DropTable(
                name: "message_outbox");

            migrationBuilder.DropTable(
                name: "user_has_relation_to_friend");

            migrationBuilder.DropTable(
                name: "user_has_relation_to_role");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "chat");

            migrationBuilder.DropTable(
                name: "e_user");

            migrationBuilder.DropTable(
                name: "user_type");
        }
    }
}
