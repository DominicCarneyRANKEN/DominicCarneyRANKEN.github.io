using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuarterlySalers.Migrations
{
    /// <inheritdoc />
    public partial class modi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Employees_EmployeeEmployId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_EmployeeEmployId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "EmployeeEmployId",
                table: "Sales");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployId",
                table: "Sales",
                column: "EmployId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Employee",
                table: "Sales",
                column: "EmployId",
                principalTable: "Employees",
                principalColumn: "EmployId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Employee",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_EmployId",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeEmployId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmployeeEmployId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmployeeEmployId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeEmployId",
                table: "Sales",
                column: "EmployeeEmployId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Employees_EmployeeEmployId",
                table: "Sales",
                column: "EmployeeEmployId",
                principalTable: "Employees",
                principalColumn: "EmployId");
        }
    }
}
