using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCompositeIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Loans",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 24, 2, 18, 12, 440, DateTimeKind.Utc).AddTicks(6871));

            migrationBuilder.UpdateData(
                table: "LoansPayment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PaymentDate" },
                values: new object[] { new DateTime(2026, 5, 24, 2, 18, 12, 441, DateTimeKind.Utc).AddTicks(3252), new DateTime(2026, 5, 24, 2, 18, 12, 441, DateTimeKind.Utc).AddTicks(3245) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 24, 2, 18, 12, 437, DateTimeKind.Utc).AddTicks(2640), "$2a$11$S9vpAV8zh2S8plyTTEbPIOVIB5Mh8cL8KcqbpUOKhEY9YMLhONNqC" });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId_Status",
                table: "Loans",
                columns: new[] { "UserId", "Status" })
                .Annotation("SqlServer:Include", new[] { "Amount", "InterestRate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Loans_UserId_Status",
                table: "Loans");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 24, 2, 3, 32, 507, DateTimeKind.Utc).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "LoansPayment",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PaymentDate" },
                values: new object[] { new DateTime(2026, 5, 24, 2, 3, 32, 508, DateTimeKind.Utc).AddTicks(6239), new DateTime(2026, 5, 24, 2, 3, 32, 508, DateTimeKind.Utc).AddTicks(6236) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 24, 2, 3, 32, 506, DateTimeKind.Utc).AddTicks(3355), "$2a$11$r7TsT0PAW2iAwcOyDd650.Bn4vaO3nikiAapLRFFTTDL3vGBedrvC" });
        }
    }
}
