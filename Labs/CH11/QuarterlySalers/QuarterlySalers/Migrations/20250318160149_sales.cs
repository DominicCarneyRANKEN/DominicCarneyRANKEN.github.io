using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuarterlySalers.Migrations
{
    /// <inheritdoc />
    public partial class sales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Employees_EmployeeEmployId",
                table: "Sales");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeEmployId",
                table: "Sales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Sales",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Amount", "EmployId", "EmployeeEmployId", "Quarter", "Year" },
                values: new object[,]
                {
                    { 1, 1000.0, 1, null, 1, 2024 },
                    { 2, 2000.0, 2, null, 2, 2025 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Employees_EmployeeEmployId",
                table: "Sales",
                column: "EmployeeEmployId",
                principalTable: "Employees",
                principalColumn: "EmployId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Employees_EmployeeEmployId",
                table: "Sales");

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeEmployId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Employees_EmployeeEmployId",
                table: "Sales",
                column: "EmployeeEmployId",
                principalTable: "Employees",
                principalColumn: "EmployId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
