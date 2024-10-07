using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer_Service.Migrations
{
    /// <inheritdoc />
    public partial class Nx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Username",
                keyValue: "user1",
                column: "Password",
                value: "AQAAAAIAAYagAAAAEHJXbfTj55LpVNKA69UYsecdSsPHJTbNjp3xvax94zoFEBq5cnW4azbx6eEj6RSkow==");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Username",
                keyValue: "user2",
                column: "Password",
                value: "AQAAAAIAAYagAAAAENcjyqu6V+g6wIpJpCrxPrdNKhpzN4C4NzhJR3bK9lebJdD7EJa2Z+b+21d+M4XJSA==");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Username",
                keyValue: "user3",
                column: "Password",
                value: "AQAAAAIAAYagAAAAEBjHLQBPcdymW2dVH/tKzGraL9RX9Jgl08v00GEkQK0dypJsFeuOcbsX8Pmd/yadVA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Username",
                keyValue: "user1",
                column: "Password",
                value: "c4ca4238a0b923820dcc509a6f75849b");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Username",
                keyValue: "user2",
                column: "Password",
                value: "c4ca4238a0b923820dcc509a6f75849b");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Username",
                keyValue: "user3",
                column: "Password",
                value: "c4ca4238a0b923820dcc509a6f75849b");
        }
    }
}
