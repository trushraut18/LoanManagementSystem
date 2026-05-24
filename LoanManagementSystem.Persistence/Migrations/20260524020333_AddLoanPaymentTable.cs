using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanPaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoansPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionReference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoansPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoansPayment_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "Amount", "CreatedDate", "DurationInMonths", "InterestRate", "Status", "UpdatedDate", "UserId" },
                values: new object[] { 1, 50000m, new DateTime(2026, 5, 24, 2, 3, 32, 507, DateTimeKind.Utc).AddTicks(6526), 12, 10m, "Approved", null, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 24, 2, 3, 32, 506, DateTimeKind.Utc).AddTicks(3355), "$2a$11$r7TsT0PAW2iAwcOyDd650.Bn4vaO3nikiAapLRFFTTDL3vGBedrvC" });

            migrationBuilder.InsertData(
                table: "LoansPayment",
                columns: new[] { "Id", "AmountPaid", "CreatedDate", "LoanId", "PaymentDate", "PaymentMode", "TransactionReference", "UpdatedDate" },
                values: new object[] { 1, 5000m, new DateTime(2026, 5, 24, 2, 3, 32, 508, DateTimeKind.Utc).AddTicks(6239), 1, new DateTime(2026, 5, 24, 2, 3, 32, 508, DateTimeKind.Utc).AddTicks(6236), "UPI", "TXN123456", null });

            migrationBuilder.CreateIndex(
                name: "IX_LoansPayment_LoanId",
                table: "LoansPayment",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoansPayment_PaymentDate",
                table: "LoansPayment",
                column: "PaymentDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoansPayment");

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 23, 3, 55, 49, 496, DateTimeKind.Utc).AddTicks(1511), "$2a$11$W9RwzXisu1Ml/w26y0.R9uxtFek8ay2RrV/AjHA.3ZaUO4QnGHvp6" });
        }
    }
}
