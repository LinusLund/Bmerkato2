using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerkato2._0.Migrations
{
    /// <inheritdoc />
    public partial class UserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93d5f009-5c11-4922-8313-de63423d21d6");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93d5f009-5c11-4922-8313-de63423d21d6", null, "Admin", "ADMIN" });
        }
    }
}
