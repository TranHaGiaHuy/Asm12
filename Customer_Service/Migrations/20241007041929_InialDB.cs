using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Customer_Service.Migrations
{
    /// <inheritdoc />
    public partial class InialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Username);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Username", "Address", "Birthday", "Email", "Fullname", "Gender", "Password", "Phone" },
                values: new object[,]
                {
                    { "user1", "120 Can tho", new DateOnly(2003, 1, 12), "huy@gmail.com", "Tran Ha Gia Huy", "Nam", "c4ca4238a0b923820dcc509a6f75849b", "0399176334" },
                    { "user2", "120 Can tho", new DateOnly(2003, 1, 12), "huy2@gmail.com", "Tran Ha Gia Huy2", "Nam", "c4ca4238a0b923820dcc509a6f75849b", "0399176334" },
                    { "user3", "120 Can tho", new DateOnly(2003, 1, 12), "huy3@gmail.com", "Tran Ha Gia Huy3", "Nam", "c4ca4238a0b923820dcc509a6f75849b", "0399176334" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
