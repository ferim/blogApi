using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blogApi.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "Description", "SeoUrl", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2c90cdb6-910b-4f9a-a0b9-de2e88c79de0"), "Lorem ipsum dolor sit amet.", new DateTime(2022, 8, 18, 13, 50, 2, 374, DateTimeKind.Local).AddTicks(9691), "This is the first blog post", "first-blog-post", "First Blog Post", null },
                    { new Guid("9c24f5f5-23f5-40f0-8452-db9445700895"), "Lorem ipsum dolor sit amet 2.", new DateTime(2022, 8, 18, 13, 50, 2, 374, DateTimeKind.Local).AddTicks(9737), "This is the second blog post", "second-blog-post", "Second Blog Post", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4cc2f0ce-9e1a-46e3-a2b0-d75a275a6aec"), new DateTime(2022, 8, 18, 13, 50, 2, 374, DateTimeKind.Local).AddTicks(9865), "Dotnet Core", null },
                    { new Guid("a522488a-931f-4424-946f-213dd65ea1b3"), new DateTime(2022, 8, 18, 13, 50, 2, 374, DateTimeKind.Local).AddTicks(9871), "Dotnet Framework", null }
                });

            migrationBuilder.InsertData(
                table: "ArticleCategory",
                columns: new[] { "Id", "ArticleId", "CategoryId" },
                values: new object[] { 1, new Guid("2c90cdb6-910b-4f9a-a0b9-de2e88c79de0"), new Guid("4cc2f0ce-9e1a-46e3-a2b0-d75a275a6aec") });

            migrationBuilder.InsertData(
                table: "ArticleCategory",
                columns: new[] { "Id", "ArticleId", "CategoryId" },
                values: new object[] { 2, new Guid("2c90cdb6-910b-4f9a-a0b9-de2e88c79de0"), new Guid("a522488a-931f-4424-946f-213dd65ea1b3") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArticleCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9c24f5f5-23f5-40f0-8452-db9445700895"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2c90cdb6-910b-4f9a-a0b9-de2e88c79de0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4cc2f0ce-9e1a-46e3-a2b0-d75a275a6aec"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a522488a-931f-4424-946f-213dd65ea1b3"));
        }
    }
}
