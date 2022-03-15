using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogCentralApp.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09f8c9a1-2263-4eb5-8fd9-600ba680b94a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48d7935a-53a3-4f88-a4e8-9f6c4cf4d085", "AQAAAAEAACcQAAAAEGHsYGlQ1b4QhmnmfU5tn4SIJkA5AefcHHYLjX5Tu3v/+1QYyxbjn2JJcCHiNqESsg==", "06ad4e0a-9559-415f-b74f-0dfabb1fb8b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce8a91ab-41ca-4e08-8cae-40d4cda1a938",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c182242-937c-4ff9-974f-a01c370e3101", "AQAAAAEAACcQAAAAEGHsYGlQ1b4QhmnmfU5tn4SIJkA5AefcHHYLjX5Tu3v/+1QYyxbjn2JJcCHiNqESsg==", "8f95edcc-b2c2-40db-8e41-bd2e09ea4b96" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 14, 13, 42, 35, 41, DateTimeKind.Local).AddTicks(7336));

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "AuthorId", "Content", "Date", "Title" },
                values: new object[,]
                {
                    { 2, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content2", new DateTime(2022, 3, 13, 13, 42, 35, 45, DateTimeKind.Local).AddTicks(7452), "BlogPost2" },
                    { 3, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", "content3", new DateTime(2022, 3, 12, 13, 42, 35, 45, DateTimeKind.Local).AddTicks(7506), "BlogPost3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09f8c9a1-2263-4eb5-8fd9-600ba680b94a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cce2b46f-145c-4451-9af1-458926091017", "AQAAAAEAACcQAAAAEL5nv1j8c8gk3Wj6Pi1BddRFI5JQQMOTjSihzw4wdm+ISGu16eNogSQ9nqNvFcRLXw==", "716c23de-1d31-4412-908a-91f4266d6531" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce8a91ab-41ca-4e08-8cae-40d4cda1a938",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c8189f0-6edf-401c-9d6e-80a060d8bd3e", "AQAAAAEAACcQAAAAEL5nv1j8c8gk3Wj6Pi1BddRFI5JQQMOTjSihzw4wdm+ISGu16eNogSQ9nqNvFcRLXw==", "f24db92d-ce2f-41dd-bf96-58e72a75d4a0" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
