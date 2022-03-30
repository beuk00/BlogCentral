using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogCentralApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09f8c9a1-2263-4eb5-8fd9-600ba680b94a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe402905-c52a-4056-b561-f92c656a3a2e", "AQAAAAEAACcQAAAAEHAu2LHW6X6ksG8Y3aXR5bMhwy1OnUK88x8U63mwTOuxRn376bJkJ3N7uHKDgTUVpQ==", "5615f4c5-ea75-44cc-a164-c607b2a8e0ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce8a91ab-41ca-4e08-8cae-40d4cda1a938",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1eabebf2-8caa-49a4-8e4a-d9305e91e474", "AQAAAAEAACcQAAAAEHAu2LHW6X6ksG8Y3aXR5bMhwy1OnUK88x8U63mwTOuxRn376bJkJ3N7uHKDgTUVpQ==", "7bff7eb3-d353-4f9c-baef-657bcea1687b" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 26, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(3417), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 25, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4239), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 24, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4271), 3 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 23, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4277), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 22, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4282), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 21, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4286), 6 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 20, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4291), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 19, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4295), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 18, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4300), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 17, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4304), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 16, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4308), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 15, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4314), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 14, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4319), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 13, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4323), 3 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 12, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4327), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 11, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4332), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 10, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4336), 6 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 9, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4340), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 8, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4344), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 7, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4349), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 6, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4353), 1 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 5, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4357), 1 });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "AuthorId", "Content", "Date", "Likes", "Title" },
                values: new object[] { 23, "ce8a91ab-41ca-4e08-8cae-40d4cda1a938", "De Japanse regering waarschuwt vandaag voor mogelijke stroomonderbrekingen in de regio van Tokio. Een koudeprik in combinatie met verschillende centrales die er uitliggen na de aardbeving van vorige week zetten het stroomnet er onder druk. De overheden waarschuwen voor mogelijke stroomonderbrekingen dinsdagavond. Twee tot drie miljoen huishoudens dreigen er enkele uren in het donker te zitten.De regering roept gezinnen en bedrijven op deze week zo weinig mogelijk elektriciteit te verbruiken.Door abnormaal koud weer is er veel vraag naar stroom, terwijl de capaciteit krap is. Japan werd vorige week getroffen door een zware aardbeving. Verscheidene thermische centrales liggen als gevolg uit.Het gaat om de eerste waarschuwingen voor black-outs sinds 2011, toen een tsunami een kernramp veroorzaakte in Fukushima.", new DateTime(2022, 3, 27, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(4362), 10, "Japan waarschuwt voor black-outs in Tokio" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BlogpostId", "CreationDate" },
                values: new object[] { 23, new DateTime(2022, 3, 26, 22, 11, 7, 738, DateTimeKind.Local).AddTicks(7684) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "BlogpostId", "Content", "CreationDate" },
                values: new object[] { 2, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", 23, "Comment 02", new DateTime(2022, 3, 25, 22, 11, 7, 743, DateTimeKind.Local).AddTicks(1375) });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09f8c9a1-2263-4eb5-8fd9-600ba680b94a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30260d9d-5828-4ff7-b48b-3d486f42e8a4", "AQAAAAEAACcQAAAAEJePz5y2d5NFib78ZeFuWLJ85nq1WgMGsj4PmCTPVUUVe/l1PRTEHTFIysA/NxSGNg==", "4bff7b38-dd70-49c8-a198-463c98a73cb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce8a91ab-41ca-4e08-8cae-40d4cda1a938",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0505fcf3-2ae0-4778-baf6-3c897ebff3e7", "AQAAAAEAACcQAAAAEJePz5y2d5NFib78ZeFuWLJ85nq1WgMGsj4PmCTPVUUVe/l1PRTEHTFIysA/NxSGNg==", "f98c7bf3-735f-4a73-addd-818460be8d1a" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 23, 9, 56, 40, 400, DateTimeKind.Local).AddTicks(4125), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 22, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2872), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 21, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2936), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 20, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2943), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 19, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2948), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 18, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2952), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 17, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2956), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 16, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2961), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 15, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2965), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 14, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2970), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 13, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2974), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 12, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2978), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 11, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2982), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 10, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2987), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 9, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2991), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 8, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(2996), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 7, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(3000), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 6, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(3004), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 5, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(3008), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 4, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(3012), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 3, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(3016), 0 });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Date", "Likes" },
                values: new object[] { new DateTime(2022, 3, 2, 9, 56, 40, 404, DateTimeKind.Local).AddTicks(3023), 0 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "BlogpostId", "Content" },
                values: new object[] { 1, "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", 1, "Comment 01" });
        }
    }
}
