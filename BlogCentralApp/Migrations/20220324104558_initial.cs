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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogpostId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_BlogPosts_BlogpostId",
                        column: x => x.BlogpostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogPostId = table.Column<int>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CityName", "FirstName", "HouseNumber", "ImageUrl", "LastName", "StreetName", "ZipCode" },
                values: new object[] { "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", 0, "1a7d1283-34ab-4af4-be94-26c0fec2038b", "Author", "ibrahim@intec.be", true, false, null, "IBRAHIM@INTEC.BE", "IBRAHIM", "AQAAAAEAACcQAAAAEMg8UJ4W0w4UmoIsT5paRrKStx0Lik0GPHfLMKl+rgATZBqEc0cl+jEzCZhLGnfIEA==", null, false, "fa003458-d0eb-40d6-a2e0-026938b226c1", false, "Ibrahim", null, "Ibrahim", null, "\\images\\Default.png", "Awad", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CityName", "FirstName", "HouseNumber", "ImageUrl", "LastName", "StreetName", "ZipCode" },
                values: new object[] { "ce8a91ab-41ca-4e08-8cae-40d4cda1a938", 0, "df768ce4-96aa-43cd-bffd-6cf6dc57f98f", "Author", "quinten@intec.be", true, false, null, "QUINTEN@INTEC.BE", "QUINTEN", "AQAAAAEAACcQAAAAEMg8UJ4W0w4UmoIsT5paRrKStx0Lik0GPHfLMKl+rgATZBqEc0cl+jEzCZhLGnfIEA==", null, false, "5788a5ca-d919-4f01-a1f7-059915007267", false, "Quinten", null, "Quinten", null, "\\images\\Default.png", "De Clerck", null, null });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "AuthorId", "Content", "Date", "Likes", "Title" },
                values: new object[,]
                {
                    { 1, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content1", new DateTime(2022, 3, 23, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(4509), 1, "BlogPost1" },
                    { 22, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content11", new DateTime(2022, 3, 2, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5422), 1, "BlogPost22" },
                    { 21, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content10", new DateTime(2022, 3, 3, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5418), 1, "BlogPost21" },
                    { 20, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content9", new DateTime(2022, 3, 4, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5414), 1, "BlogPost20" },
                    { 19, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content8", new DateTime(2022, 3, 5, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5410), 1, "BlogPost19" },
                    { 18, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content7", new DateTime(2022, 3, 6, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5405), 1, "BlogPost18" },
                    { 17, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content6", new DateTime(2022, 3, 7, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5401), 6, "BlogPost17" },
                    { 16, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content5", new DateTime(2022, 3, 8, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5397), 1, "BlogPost16" },
                    { 15, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content4", new DateTime(2022, 3, 9, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5392), 1, "BlogPost15" },
                    { 14, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content3", new DateTime(2022, 3, 10, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5388), 3, "BlogPost14" },
                    { 13, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content2", new DateTime(2022, 3, 11, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5383), 1, "BlogPost13" },
                    { 12, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content1", new DateTime(2022, 3, 12, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5302), 1, "BlogPost12" },
                    { 11, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content11", new DateTime(2022, 3, 13, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5298), 1, "BlogPost11" },
                    { 10, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content10", new DateTime(2022, 3, 14, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5294), 1, "BlogPost10" },
                    { 9, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content9", new DateTime(2022, 3, 15, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5289), 1, "BlogPost9" },
                    { 8, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content8", new DateTime(2022, 3, 16, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5284), 1, "BlogPost8" },
                    { 7, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content7", new DateTime(2022, 3, 17, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5280), 1, "BlogPost7" },
                    { 6, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content6", new DateTime(2022, 3, 18, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5276), 6, "BlogPost6" },
                    { 5, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content5", new DateTime(2022, 3, 19, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5271), 1, "BlogPost5" },
                    { 4, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content4", new DateTime(2022, 3, 20, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5263), 1, "BlogPost4" },
                    { 3, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content3", new DateTime(2022, 3, 21, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5256), 3, "BlogPost3" },
                    { 2, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content2", new DateTime(2022, 3, 22, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5220), 1, "BlogPost2" },
                    { 23, "ce8a91ab-41ca-4e08-8cae-40d4cda1a938", "De Japanse regering waarschuwt vandaag voor mogelijke stroomonderbrekingen in de regio van Tokio. Een koudeprik in combinatie met verschillende centrales die er uitliggen na de aardbeving van vorige week zetten het stroomnet er onder druk. De overheden waarschuwen voor mogelijke stroomonderbrekingen dinsdagavond. Twee tot drie miljoen huishoudens dreigen er enkele uren in het donker te zitten.De regering roept gezinnen en bedrijven op deze week zo weinig mogelijk elektriciteit te verbruiken.Door abnormaal koud weer is er veel vraag naar stroom, terwijl de capaciteit krap is. Japan werd vorige week getroffen door een zware aardbeving. Verscheidene thermische centrales liggen als gevolg uit.Het gaat om de eerste waarschuwingen voor black-outs sinds 2011, toen een tsunami een kernramp veroorzaakte in Fukushima.", new DateTime(2022, 3, 24, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5427), 10, "Japan waarschuwt voor black-outs in Tokio" },
                    { 24, "ce8a91ab-41ca-4e08-8cae-40d4cda1a938", "JapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapan", new DateTime(2022, 3, 24, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(5432), 10, "JapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapanJapan" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "BlogpostId", "Content", "CreationDate" },
                values: new object[] { 1, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", 23, "Comment 01", new DateTime(2022, 3, 23, 11, 45, 57, 496, DateTimeKind.Local).AddTicks(9608) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "BlogpostId", "Content", "CreationDate" },
                values: new object[] { 2, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", 23, "Comment 02", new DateTime(2022, 3, 22, 11, 45, 57, 502, DateTimeKind.Local).AddTicks(2662) });

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
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogpostId",
                table: "Comments",
                column: "BlogpostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_AuthorId",
                table: "Likes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_BlogPostId",
                table: "Likes",
                column: "BlogPostId");
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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
