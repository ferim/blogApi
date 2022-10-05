using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blogApi.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2c90cdb6-910b-4f9a-a0b9-de2e88c79de0"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 10, 59, 54, 323, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9c24f5f5-23f5-40f0-8452-db9445700895"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 10, 59, 54, 323, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36c4b44f-a389-43dd-a587-c10536eb393f", "754f7f08-6c4a-4c54-a8a7-c029ef0f5122", "Administrator", "ADMINISTRATOR" },
                    { "3cafbb49-0f23-4929-aa46-b27b05dd7bed", "1157f776-6585-4237-b101-c3b8b3318589", "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4cc2f0ce-9e1a-46e3-a2b0-d75a275a6aec"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 10, 59, 54, 323, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a522488a-931f-4424-946f-213dd65ea1b3"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 10, 59, 54, 323, DateTimeKind.Local).AddTicks(8097));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36c4b44f-a389-43dd-a587-c10536eb393f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cafbb49-0f23-4929-aa46-b27b05dd7bed");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2c90cdb6-910b-4f9a-a0b9-de2e88c79de0"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 3, 19, 59, 708, DateTimeKind.Local).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9c24f5f5-23f5-40f0-8452-db9445700895"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 3, 19, 59, 708, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4cc2f0ce-9e1a-46e3-a2b0-d75a275a6aec"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 3, 19, 59, 708, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a522488a-931f-4424-946f-213dd65ea1b3"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 3, 19, 59, 708, DateTimeKind.Local).AddTicks(2120));
        }
    }
}
