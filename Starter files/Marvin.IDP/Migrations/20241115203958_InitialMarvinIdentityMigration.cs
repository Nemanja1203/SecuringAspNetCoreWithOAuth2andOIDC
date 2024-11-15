using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marvin.IDP.Migrations
{
    /// <inheritdoc />
    public partial class InitialMarvinIdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Password", "Subject", "UserName" },
                values: new object[,]
                {
                    { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), true, "70f651c1-f534-4ef6-83e5-db2337ec2815", "password", "d860efca-22d9-47fd-8249-791ba61b07c7", "David" },
                    { new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), true, "d6abbd1a-d092-4475-a95e-bf95b3c8b8c0", "password", "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "Emma" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subject",
                table: "Users",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
