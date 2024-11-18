using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marvin.IDP.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountActivation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("44bd9774-07c1-4f04-85f2-694116856ff5"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("5bec8ddb-e02a-43ab-913e-09c6845abe1f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("62fea10b-2e2b-4d80-adba-e2ba074db543"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("7558a4c7-10da-4025-8777-b1981338eb3f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("89025d4a-bd0b-43c0-ae28-a01dc52c3380"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9289c528-82fc-4ae5-a911-45322a6b74ad"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9a6a05ea-e87d-48af-a496-998035f9641d"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ea68d364-ec52-4293-a835-07edce2f0ce6"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecurityCodeExpirationDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode", "SecurityCodeExpirationDate" },
                values: new object[] { "a7b0a961-91a9-479b-9c43-0d3bbee2e2b6", "david@someprovider.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode", "SecurityCodeExpirationDate" },
                values: new object[] { "18f81f6b-076f-41e5-9c2b-8b7a4f3c10c5", "emma@someprovider.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCodeExpirationDate",
                table: "Users");

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("44bd9774-07c1-4f04-85f2-694116856ff5"), "e04b717e-0b96-4819-891e-696348c850d3", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("5bec8ddb-e02a-43ab-913e-09c6845abe1f"), "6e170202-ebdb-40ff-a9c4-2cd1c81a0dfa", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("62fea10b-2e2b-4d80-adba-e2ba074db543"), "d8c56edd-a938-4cb7-8d40-1d341d7675a9", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("7558a4c7-10da-4025-8777-b1981338eb3f"), "abda4bf8-95e1-4568-b7b4-c411c758d0fb", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("89025d4a-bd0b-43c0-ae28-a01dc52c3380"), "a16521b5-ce41-4056-be5a-c9a3333121da", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("9289c528-82fc-4ae5-a911-45322a6b74ad"), "bf752782-6c00-452a-9311-2ea422be4ee4", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("9a6a05ea-e87d-48af-a496-998035f9641d"), "456c601c-3a80-4141-b570-753a64c86449", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("ea68d364-ec52-4293-a835-07edce2f0ce6"), "e8d08a82-8c44-40f3-9962-24883e198e03", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "70f651c1-f534-4ef6-83e5-db2337ec2815");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "d6abbd1a-d092-4475-a95e-bf95b3c8b8c0");
        }
    }
}
