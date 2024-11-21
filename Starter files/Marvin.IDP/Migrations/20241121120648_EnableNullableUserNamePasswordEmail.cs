using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marvin.IDP.Migrations
{
    /// <inheritdoc />
    public partial class EnableNullableUserNamePasswordEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

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
        }
    }
}
