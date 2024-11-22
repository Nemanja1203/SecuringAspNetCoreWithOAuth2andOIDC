using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marvin.IDP.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSecret : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("036a754a-722c-429b-9d3c-dd6327014211"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("1dd14d48-452d-418e-8cb9-7b8dc0d0c803"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("56360fb9-c90f-428a-a078-6dbd40bd4a71"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("7e5d902c-c459-4823-996b-87adb0b37c5a"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a507d0ae-a88e-457a-b0d4-1e9669ec14f5"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b220c9ae-76e8-4ae8-ad0f-8b18733f0ab1"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b686adde-a04b-433a-81de-f6c01fc7acd5"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ea9a770b-fa6e-4fc7-854f-62fc7e1dd3a5"));

            migrationBuilder.CreateTable(
                name: "UsersSecrets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Secret = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersSecrets_Users_UserId",
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
                    { new Guid("03867614-7984-4b9a-95b4-135c87f2e890"), "b636d944-4ee7-42ec-a1d4-f20386cef7f9", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("06613c69-e03e-49d1-a581-2376275586fa"), "c1f3c4ae-559b-4e9e-b3ae-ca1af0120852", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("2157c552-0135-4530-8ac4-76b62204b61f"), "6001455d-d07f-4ba8-bf57-9f11e5ac633e", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("226d4464-2edf-454b-99f7-0a9f3bece2b8"), "28052a6b-7b5e-42ac-af43-569bf220cb81", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("3556097e-6be0-4e60-9404-318f45447f24"), "11c3b993-a297-47db-bbe5-2a777d793de5", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("65a49f13-705a-41c7-ae0c-9c12265dad76"), "009b9daf-cbd3-437f-a10f-a4bc9c91f8c1", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("c408acb6-1ce3-41a9-9a69-b2dd3db7113c"), "a4d07ba9-40de-46b6-9d23-fa759f154fae", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("cb14062e-d7d9-443f-b4a2-8cff7073927b"), "06885e76-1f54-4188-89f0-23718e11273a", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "c5051899-2660-4a30-9e80-fd9400b980e3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "7184ea15-4e07-4c89-8000-71783bed21fb");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSecrets_UserId",
                table: "UsersSecrets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersSecrets");

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("03867614-7984-4b9a-95b4-135c87f2e890"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("06613c69-e03e-49d1-a581-2376275586fa"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2157c552-0135-4530-8ac4-76b62204b61f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("226d4464-2edf-454b-99f7-0a9f3bece2b8"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3556097e-6be0-4e60-9404-318f45447f24"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("65a49f13-705a-41c7-ae0c-9c12265dad76"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c408acb6-1ce3-41a9-9a69-b2dd3db7113c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("cb14062e-d7d9-443f-b4a2-8cff7073927b"));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("036a754a-722c-429b-9d3c-dd6327014211"), "768e9c84-ea1f-472a-bd70-2940741956b9", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("1dd14d48-452d-418e-8cb9-7b8dc0d0c803"), "933a14d8-2aff-44d9-8639-88fa895fdbaa", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("56360fb9-c90f-428a-a078-6dbd40bd4a71"), "31445005-9b7e-4832-b595-9a2e2643e6b5", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("7e5d902c-c459-4823-996b-87adb0b37c5a"), "0b65eecc-7533-44e9-874d-3ddc0c3175ef", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("a507d0ae-a88e-457a-b0d4-1e9669ec14f5"), "028221d7-5696-414a-bfdd-3c59d93cadbe", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("b220c9ae-76e8-4ae8-ad0f-8b18733f0ab1"), "3a7e7631-e7c2-4d0c-842d-c8795558a789", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("b686adde-a04b-433a-81de-f6c01fc7acd5"), "9326f732-fdfc-42a8-b5ea-866b4c378773", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("ea9a770b-fa6e-4fc7-854f-62fc7e1dd3a5"), "0cddeb78-ccbd-4468-85c6-6d9f8fd4ed5d", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "206a1569-cf8c-4aee-b53f-6c5249026d41");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "5be0b7a6-5627-4583-bfd2-8a0ac0c6f13f");
        }
    }
}
