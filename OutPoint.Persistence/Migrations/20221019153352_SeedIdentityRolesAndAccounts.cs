using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutPoint.Persistence.Migrations
{
    public partial class SeedIdentityRolesAndAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28d70a89-2149-47cc-bd78-55d82d406fcd", "b57fdfd0-a102-4f93-984e-25e1fce1f3d0", "User", "USER" },
                    { "ab195862-9152-4976-8958-a5c74a8f858d", "fa89f30d-5de2-4a45-b1c0-4ec68ccc7911", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3fea5c15-07c5-4d8e-bc99-a9eb44a57edb", 0, "e2d5a578-d74a-4cc0-9efe-268c5716d548", "user@outpoint.com", false, "", "", false, null, "USER@OUTPOINT.COM", "USER@OUTPOINT.COM", "AQAAAAEAACcQAAAAEId63mMardP2QvXk+3W2oGl5bAgNBq0zj1sTS5V+VhA83F7u4qjciVg2IGkydmdIoQ==", null, false, "9fb1eac5-d25f-47f7-8142-f3ae61c6d7e6", false, "User" },
                    { "a14b986b-da6c-42a1-9c17-5b0df26f28dd", 0, "9e06a522-6ab1-47e4-843b-88053d5b1cc0", "admin@outpoint.com", false, "", "", false, null, "ADMIN@OUTPOINT.COM", "ADMIN@OUTPOINT.COM", "AQAAAAEAACcQAAAAEPRG+Q4iFdiHIm++hfOt6qdSyAyZVOiDAyiVx6DeO8j5njL0/V5br7QSTmPxIgAxpQ==", null, false, "5676f4c8-fdf1-4234-a968-63402fec1ce2", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "28d70a89-2149-47cc-bd78-55d82d406fcd", "3fea5c15-07c5-4d8e-bc99-a9eb44a57edb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ab195862-9152-4976-8958-a5c74a8f858d", "a14b986b-da6c-42a1-9c17-5b0df26f28dd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "28d70a89-2149-47cc-bd78-55d82d406fcd", "3fea5c15-07c5-4d8e-bc99-a9eb44a57edb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ab195862-9152-4976-8958-a5c74a8f858d", "a14b986b-da6c-42a1-9c17-5b0df26f28dd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28d70a89-2149-47cc-bd78-55d82d406fcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab195862-9152-4976-8958-a5c74a8f858d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fea5c15-07c5-4d8e-bc99-a9eb44a57edb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a14b986b-da6c-42a1-9c17-5b0df26f28dd");
        }
    }
}
