using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Account.Microservice.Migrations
{
    public partial class seed_roles_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreateUserId", "CreatedDate", "Description", "IsActive", "ModifyDate", "ModifyUserId", "RoleName", "StatusId" },
                values: new object[,]
                {
                    { 1, "builder.seed", new DateTime(2022, 4, 19, 11, 18, 7, 251, DateTimeKind.Local).AddTicks(2163), "An administrator role normaly does everything", true, new DateTime(2022, 4, 19, 11, 18, 7, 255, DateTimeKind.Local).AddTicks(3364), "builder.seed", "Admin", 1 },
                    { 2, "builder.seed", new DateTime(2022, 4, 19, 11, 18, 7, 255, DateTimeKind.Local).AddTicks(3875), "An student role makes applications to ITS 4.0", true, new DateTime(2022, 4, 19, 11, 18, 7, 255, DateTimeKind.Local).AddTicks(3879), "builder.seed", "Student", 1 },
                    { 3, "builder.seed", new DateTime(2022, 4, 19, 11, 18, 7, 255, DateTimeKind.Local).AddTicks(3881), "A clerk is responsible for creating subject and modifying the subjects based on their Faculty Subject Aps requirements", true, new DateTime(2022, 4, 19, 11, 18, 7, 255, DateTimeKind.Local).AddTicks(3882), "builder.seed", "Clerk", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
