using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogCentralApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<int>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    Likes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogpostId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_BlogPosts_BlogpostId",
                        column: x => x.BlogpostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CityName", "FirstName", "HouseNumber", "ImageUrl", "LastName", "StreetName", "ZipCode" },
                values: new object[] { "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", 0, "9a14b555-b764-488e-a01d-5ab2feac2ccb", "Author", "ibrahim@intec.be", true, false, null, "IBRAHIM@INTEC.BE", "IBRAHIM", "AQAAAAEAACcQAAAAEGqg4+8yZ/yt7gH0RcXKHrsGekAi0O8cZxdq+nk2TN8xunj9008EP+ctPd3cNdhNhg==", null, false, "39645fb4-57ee-4f7a-bc9e-1a2384c92221", false, "Ibrahim", null, "Ibrahim", null, null, "Awad", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CityName", "FirstName", "HouseNumber", "ImageUrl", "LastName", "StreetName", "ZipCode" },
                values: new object[] { "ce8a91ab-41ca-4e08-8cae-40d4cda1a938", 0, "aaf09ffe-cf0f-45f1-abec-2318888c6a77", "Author", "quinten@intec.be", true, false, null, "QUINTEN@INTEC.BE", "QUINTEN", "AQAAAAEAACcQAAAAEGqg4+8yZ/yt7gH0RcXKHrsGekAi0O8cZxdq+nk2TN8xunj9008EP+ctPd3cNdhNhg==", null, false, "4c7e8550-a54a-45f6-992c-23cd871799fa", false, "Quinten", null, "Quinten", null, null, "De Clerck", null, null });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "AuthorId", "Content", "Date", "Likes", "Title" },
                values: new object[,]
                {
                    { 1, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content1", new DateTime(2022, 3, 16, 10, 14, 26, 818, DateTimeKind.Local).AddTicks(3805), 2, "BlogPost1" },
                    { 2, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content2", new DateTime(2022, 3, 15, 10, 14, 26, 821, DateTimeKind.Local).AddTicks(6060), 5, "BlogPost2" },
                    { 3, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content3", new DateTime(2022, 3, 14, 10, 14, 26, 821, DateTimeKind.Local).AddTicks(6114), 1, "BlogPost3" },
                    { 4, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content4", new DateTime(2022, 3, 13, 10, 14, 26, 821, DateTimeKind.Local).AddTicks(6119), 1, "BlogPost4" },
                    { 5, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content5", new DateTime(2022, 3, 12, 10, 14, 26, 821, DateTimeKind.Local).AddTicks(6122), 1, "BlogPost5" },
                    { 6, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content6", new DateTime(2022, 3, 11, 10, 14, 26, 821, DateTimeKind.Local).AddTicks(6125), 10, "BlogPost6" },
                    { 7, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content7", new DateTime(2022, 3, 10, 10, 14, 26, 821, DateTimeKind.Local).AddTicks(6128), 1, "BlogPost7" },
                    { 8, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content8", new DateTime(2022, 3, 9, 10, 14, 26, 821, DateTimeKind.Local).AddTicks(6131), 1, "BlogPost8" },
                    { 9, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content9", new DateTime(2022, 3, 8, 10, 14, 26, 821, DateTimeKind.Local).AddTicks(6133), 1, "BlogPost9" },
                    { 10, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content10", new DateTime(2022, 3, 7, 10, 14, 26, 821, DateTimeKind.Local).AddTicks(6136), 1, "BlogPost10" },
                    { 11, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content11", new DateTime(2022, 3, 6, 10, 14, 26, 821, DateTimeKind.Local).AddTicks(6139), 1, "BlogPost11" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "AuthorId", "BlogpostId", "Content" },
                values: new object[] { 1, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", 1, "Comment 01" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_AuthorId",
                table: "BlogPosts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BlogpostId",
                table: "Comment",
                column: "BlogpostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
