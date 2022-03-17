﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogCentralApp.Migrations
{
    public partial class initial : Migration
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
                values: new object[] { "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", 0, "cfb2bfc2-682e-4f6c-b493-94b7563cf269", "Author", "ibrahim@intec.be", true, false, null, "IBRAHIM@INTEC.BE", "IBRAHIM", "AQAAAAEAACcQAAAAEOOl1V+5+8bHcrRP7gz6P2/t1nOsB3HY3JJVuMTnr9yK1/bjIFjvvqLMDNIKrEBSvw==", null, false, "8bd14e9a-dc8d-4ade-948d-9668624309c8", false, "Ibrahim", null, "Ibrahim", null, null, "Awad", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CityName", "FirstName", "HouseNumber", "ImageUrl", "LastName", "StreetName", "ZipCode" },
                values: new object[] { "ce8a91ab-41ca-4e08-8cae-40d4cda1a938", 0, "9b3fc4b9-b840-4133-8293-d2065a2a4cb5", "Author", "quinten@intec.be", true, false, null, "QUINTEN@INTEC.BE", "QUINTEN", "AQAAAAEAACcQAAAAEOOl1V+5+8bHcrRP7gz6P2/t1nOsB3HY3JJVuMTnr9yK1/bjIFjvvqLMDNIKrEBSvw==", null, false, "1dd1724e-8b52-4c9b-b0b9-12d144644087", false, "Quinten", null, "Quinten", null, null, "De Clerck", null, null });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "AuthorId", "Content", "Date", "Likes", "Title" },
                values: new object[,]
                {
                    { 1, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content1", new DateTime(2022, 3, 15, 14, 41, 4, 883, DateTimeKind.Local).AddTicks(3894), 1, "BlogPost1" },
                    { 20, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content9", new DateTime(2022, 2, 24, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8682), 1, "BlogPost20" },
                    { 19, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content8", new DateTime(2022, 2, 25, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8678), 1, "BlogPost19" },
                    { 18, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content7", new DateTime(2022, 2, 26, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8675), 1, "BlogPost18" },
                    { 17, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content6", new DateTime(2022, 2, 27, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8671), 6, "BlogPost17" },
                    { 16, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content5", new DateTime(2022, 2, 28, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8667), 1, "BlogPost16" },
                    { 15, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content4", new DateTime(2022, 3, 1, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8664), 1, "BlogPost15" },
                    { 14, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content3", new DateTime(2022, 3, 2, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8661), 3, "BlogPost14" },
                    { 13, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content2", new DateTime(2022, 3, 3, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8656), 1, "BlogPost13" },
                    { 12, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content1", new DateTime(2022, 3, 4, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8650), 1, "BlogPost12" },
                    { 11, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content11", new DateTime(2022, 3, 5, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8647), 1, "BlogPost11" },
                    { 10, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content10", new DateTime(2022, 3, 6, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8643), 1, "BlogPost10" },
                    { 9, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content9", new DateTime(2022, 3, 7, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8640), 1, "BlogPost9" },
                    { 8, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content8", new DateTime(2022, 3, 8, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8636), 1, "BlogPost8" },
                    { 7, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content7", new DateTime(2022, 3, 9, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8633), 1, "BlogPost7" },
                    { 6, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content6", new DateTime(2022, 3, 10, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8628), 6, "BlogPost6" },
                    { 5, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content5", new DateTime(2022, 3, 11, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8625), 1, "BlogPost5" },
                    { 4, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content4", new DateTime(2022, 3, 12, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8621), 1, "BlogPost4" },
                    { 3, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content3", new DateTime(2022, 3, 13, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8615), 3, "BlogPost3" },
                    { 2, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content2", new DateTime(2022, 3, 14, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8551), 1, "BlogPost2" },
                    { 21, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content10", new DateTime(2022, 2, 23, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8685), 1, "BlogPost21" },
                    { 22, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content11", new DateTime(2022, 2, 22, 14, 41, 4, 886, DateTimeKind.Local).AddTicks(8690), 1, "BlogPost22" }
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