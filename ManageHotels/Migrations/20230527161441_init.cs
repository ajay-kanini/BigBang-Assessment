using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageHotels.Migrations
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
                    Amenties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
