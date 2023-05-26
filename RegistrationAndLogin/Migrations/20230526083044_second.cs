using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationAndLogin.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserName = table.Column<string>(name: "User Name", type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(name: "Phone Number", type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                name: "User");
        }
    }
}
