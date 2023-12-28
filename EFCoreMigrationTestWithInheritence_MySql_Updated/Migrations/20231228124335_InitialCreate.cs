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
                name: "email_type",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 609, DateTimeKind.Local).AddTicks(795)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mail_outbox",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    from = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    subject = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    body = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    is_body_html = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: false, comment: "boolean value to describe if email contain html content"),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 609, DateTimeKind.Local).AddTicks(4132)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uuid);
                })
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
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 576, DateTimeKind.Local).AddTicks(5919)),
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
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 576, DateTimeKind.Local).AddTicks(9010)),
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
                name: "chat_invite_request",
                columns: table => new
                {
                    chat_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    target_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    requester_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    request_message = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 604, DateTimeKind.Local).AddTicks(7699)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat_invite_request", x => new { x.chat_id, x.target_id });
                    table.ForeignKey(
                        name: "FK_CHATINVITEREQUEST_CHATFOREIGNKEY_TO_CHAT",
                        column: x => x.chat_id,
                        principalTable: "chat",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chat_relation_to_user",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    chat_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    is_admin = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: false, comment: "boolean value to describe if chatmember is chat-admin"),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 582, DateTimeKind.Local).AddTicks(8862)),
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
                    created_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    modified_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    deleted_by_uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true),
                    name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    user_type_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, defaultValue: new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b")),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 550, DateTimeKind.Local).AddTicks(5608)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
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
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 547, DateTimeKind.Local).AddTicks(2453)),
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
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 592, DateTimeKind.Local).AddTicks(2417)),
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
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(7145)),
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
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 543, DateTimeKind.Local).AddTicks(7412)),
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
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 536, DateTimeKind.Local).AddTicks(3094)),
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
                    message_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    user_id = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 601, DateTimeKind.Local).AddTicks(8419)),
                    modified_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    uuid = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message_outbox", x => new { x.message_id, x.user_id });
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
                    UsersId = table.Column<Guid>(type: "char(36)", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2023, 12, 28, 13, 43, 35, 569, DateTimeKind.Local).AddTicks(7456)),
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
                        name: "FK_USERHASRELATIONTOROLE_CREATEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.created_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_USERHASRELATIONTOROLE_DELETEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.deleted_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_USERHASRELATIONTOROLE_LASTMODIFIEDBYUSERFOREIGNKEY_TO_EUSER",
                        column: x => x.modified_by_uuid,
                        principalTable: "e_user",
                        principalColumn: "uuid");
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
                    table.ForeignKey(
                        name: "FK_user_has_relation_to_role_e_user_UsersId",
                        column: x => x.UsersId,
                        principalTable: "e_user",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "email_type",
                columns: new[] { "uuid", "created_time", "deleted_time", "modified_time", "name" },
                values: new object[,]
                {
                    { new Guid("c4f357ff-1c85-4e3c-b6b2-21ef4afba71f"), new DateTime(2023, 12, 28, 13, 43, 35, 609, DateTimeKind.Local).AddTicks(1474), null, null, "to" },
                    { new Guid("c52db414-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 609, DateTimeKind.Local).AddTicks(1487), null, null, "bcc" },
                    { new Guid("c62db414-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 609, DateTimeKind.Local).AddTicks(1485), null, null, "cc" }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "uuid", "created_by_uuid", "created_time", "deleted_by_uuid", "deleted_time", "modified_by_uuid", "modified_time", "name" },
                values: new object[,]
                {
                    { new Guid("c3f357ff-1c85-4e3c-b6b2-21ef4afba71f"), null, new DateTime(2023, 12, 28, 13, 43, 35, 569, DateTimeKind.Local).AddTicks(1985), null, null, null, null, "Admin" },
                    { new Guid("c92db414-765b-46dd-bf40-ef7d5a5abd7b"), null, new DateTime(2023, 12, 28, 13, 43, 35, 569, DateTimeKind.Local).AddTicks(2007), null, null, null, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "user_type",
                columns: new[] { "uuid", "created_by_uuid", "created_time", "deleted_by_uuid", "deleted_time", "modified_by_uuid", "modified_time", "name" },
                values: new object[,]
                {
                    { new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f"), null, new DateTime(2023, 12, 28, 13, 43, 35, 543, DateTimeKind.Local).AddTicks(4453), null, null, null, null, "Root" },
                    { new Guid("c92db314-765b-46dd-bf40-ef7d5a5abd7b"), null, new DateTime(2023, 12, 28, 13, 43, 35, 543, DateTimeKind.Local).AddTicks(4419), null, null, null, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "e_user",
                columns: new[] { "uuid", "created_by_uuid", "created_time", "deleted_by_uuid", "deleted_time", "email", "modified_by_uuid", "modified_time", "name", "password", "user_type_id" },
                values: new object[,]
                {
                    { new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), null, new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6287), null, null, "root@localhost", null, null, "Root", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("107e45cd-95ab-436b-8f03-a37759129aca"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6365), null, null, "test0@localhost", null, new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6367), "Test0", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("5fa9980f-cb1c-40fd-9649-9a907586ff1b"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6398), null, null, "test5@localhost", null, new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6399), "Test5", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("8b8ca8c6-770b-4c67-98e3-fd7ccdca6e05"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6376), null, null, "test2@localhost", null, new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6377), "Test2", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("8bf685a5-ba34-41eb-923e-74cf9a293a02"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6380), null, null, "test3@localhost", null, new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6381), "Test3", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("8fabe214-70b1-4e50-88e1-f2a942e450a0"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6437), null, null, "test8@localhost", null, new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6438), "Test8", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("a4587341-1e1f-4e73-b23f-26101c361fff"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6402), null, null, "test6@localhost", null, new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6404), "Test6", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("ca3c9577-fe90-40d5-92f4-abe14aa1f6ef"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6384), null, null, "test4@localhost", null, new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6386), "Test4", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("cbab4fda-aa35-4c3e-aac3-8795b93f1356"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6432), null, null, "test7@localhost", null, new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6434), "Test7", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("db5d7f2e-32d4-496b-bb18-bdd3ef596d22"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6371), null, null, "test1@localhost", null, new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6373), "Test1", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") },
                    { new Guid("f7c9a917-8f84-4629-9379-5e1551bafb16"), new Guid("c92db313-765b-46dd-bf40-ef7d5a5abd7b"), new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6442), null, null, "test9@localhost", null, new DateTime(2023, 12, 28, 13, 43, 35, 562, DateTimeKind.Local).AddTicks(6443), "Test9", "abcd1234", new Guid("c3f257ff-1c85-4e3c-b6b2-21ef4afba71f") }
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
                name: "IDX_FK_CHATINVITEREQUEST_CHAT_CHAT",
                table: "chat_invite_request",
                column: "chat_id");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_CHATINVITEREQUEST_REQUESTERUSER_EUSER",
                table: "chat_invite_request",
                column: "requester_id");

            migrationBuilder.CreateIndex(
                name: "IDX_FK_CHATINVITEREQUEST_TARGETUSER_EUSER",
                table: "chat_invite_request",
                column: "target_id");

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
                name: "IX_user_has_relation_to_role_created_by_uuid",
                table: "user_has_relation_to_role",
                column: "created_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_user_has_relation_to_role_deleted_by_uuid",
                table: "user_has_relation_to_role",
                column: "deleted_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_user_has_relation_to_role_modified_by_uuid",
                table: "user_has_relation_to_role",
                column: "modified_by_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_user_has_relation_to_role_UsersId",
                table: "user_has_relation_to_role",
                column: "UsersId");

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
                name: "FK_CHATINVITEREQUEST_REQUESTERUSERFOREIGNKEY_TO_EUSER",
                table: "chat_invite_request",
                column: "requester_id",
                principalTable: "e_user",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CHATINVITEREQUEST_TARGETUSERFOREIGNKEY_TO_EUSER",
                table: "chat_invite_request",
                column: "target_id",
                principalTable: "e_user",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

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
                name: "chat_invite_request");

            migrationBuilder.DropTable(
                name: "chat_relation_to_user");

            migrationBuilder.DropTable(
                name: "email_type");

            migrationBuilder.DropTable(
                name: "friendship_request");

            migrationBuilder.DropTable(
                name: "mail_outbox");

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
