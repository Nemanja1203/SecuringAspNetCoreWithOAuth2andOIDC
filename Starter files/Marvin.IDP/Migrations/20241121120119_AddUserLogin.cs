using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marvin.IDP.Migrations
{
    /// <inheritdoc />
    public partial class AddUserLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2c66bdb8-bdda-46b4-a6ab-6e85554ef956"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2dbe78d5-f984-4643-9dbb-1d7010dc74ae"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("36f667bf-4f84-43a6-8ea4-f590da798d2c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3d41a06a-d399-4870-bc08-06475762f2b3"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("997da6a5-14f3-45bd-b9f5-f58212ce535e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("cad76fe1-7856-492a-b784-04644201d320"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("dbdfcb79-5884-4d21-b91a-4e66a38eb041"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fd982ada-b0e6-487a-b328-b9d90a6f6a3a"));

            migrationBuilder.CreateTable(
                name: "UsersLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Provider = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ProviderIdentityKey = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("09a75838-adf3-446b-b50b-d192ffd68c47"), "0d33c758-0aab-4fd8-9bbd-c651f12416fc", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("0cc3dbd9-1222-405e-9018-0a14dbd3110f"), "f42e933d-6b51-4da7-9a95-35dc104f9e8c", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("3c0f1426-2483-4946-9687-43a95dec89d9"), "d2d45a27-6e55-4e0f-81a7-6f50759d7137", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("59671af5-63d9-400e-a35c-437c2713e9c9"), "ddc2dc9b-4681-4fbe-8461-52a494a8ed12", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("6bc32366-891c-433b-a827-6668d26baa1e"), "d68e97ba-d4b5-4338-824a-b630bf9ed0cb", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("87096f61-6806-45a1-b636-5e9fc36b36aa"), "8cdc1046-7651-40d6-b8b5-d3e52ec565bb", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("9d929d2d-b87a-4953-b2d5-f60b8192a37e"), "71c44a2b-2a64-423a-b0dc-d38e0c647f5a", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("c8682ddd-6a0f-4938-9c5a-a48c9f700671"), "1a19bd82-9c48-4120-91fd-50d471c04bdd", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "d3c011c3-f4c6-4331-9e45-7ffe945ed02e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "5f3597dc-7162-4a08-9711-ba4715d71c0a");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLogins_UserId",
                table: "UsersLogins",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersLogins");

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("09a75838-adf3-446b-b50b-d192ffd68c47"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("0cc3dbd9-1222-405e-9018-0a14dbd3110f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3c0f1426-2483-4946-9687-43a95dec89d9"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("59671af5-63d9-400e-a35c-437c2713e9c9"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6bc32366-891c-433b-a827-6668d26baa1e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("87096f61-6806-45a1-b636-5e9fc36b36aa"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9d929d2d-b87a-4953-b2d5-f60b8192a37e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c8682ddd-6a0f-4938-9c5a-a48c9f700671"));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("2c66bdb8-bdda-46b4-a6ab-6e85554ef956"), "7215c254-a317-4c62-8e8a-97f15f585faf", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("2dbe78d5-f984-4643-9dbb-1d7010dc74ae"), "342cc3e5-9302-4e10-9477-e01ef3850423", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("36f667bf-4f84-43a6-8ea4-f590da798d2c"), "15014f70-9b65-4e31-a13e-915012945814", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("3d41a06a-d399-4870-bc08-06475762f2b3"), "51354fc3-445f-427a-8e9a-74631b0c75b5", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("997da6a5-14f3-45bd-b9f5-f58212ce535e"), "4896bdbf-f798-4a07-97b7-53396d9b47d8", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("cad76fe1-7856-492a-b784-04644201d320"), "c766ee6c-7de9-4fc5-a441-fecd630ba0fd", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("dbdfcb79-5884-4d21-b91a-4e66a38eb041"), "a959a310-fd48-4bb8-937b-8560358132d8", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("fd982ada-b0e6-487a-b328-b9d90a6f6a3a"), "00f03588-159e-421b-be52-070389e730d2", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "a7b0a961-91a9-479b-9c43-0d3bbee2e2b6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "18f81f6b-076f-41e5-9c2b-8b7a4f3c10c5");
        }
    }
}
