using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "LastName", "PasswordHash", "Role", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2026, 5, 23, 2, 53, 39, 67, DateTimeKind.Utc).AddTicks(6513), "admin@loan.com", "System", "Admin", "$2a$11$LaBemzMRLKiJuZBXO6XWfeFcGs1bcR5DFaMonuNj37xMN2FYh2eFm", "Admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
