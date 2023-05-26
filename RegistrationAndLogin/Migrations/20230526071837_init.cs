using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationAndLogin.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelId = table.Column<int>(name: "Hotel Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(name: "Hotel Name", type: "nvarchar(max)", nullable: true),
                    CityLocation = table.Column<string>(name: "City Location", type: "nvarchar(max)", nullable: true),
                    CountryLoacation = table.Column<string>(name: "Country Loacation", type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserName = table.Column<string>(name: "User Name", type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HashKey = table.Column<byte[]>(name: "Hash Key", type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
