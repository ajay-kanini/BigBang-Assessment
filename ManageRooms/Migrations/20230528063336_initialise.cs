using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageRooms.Migrations
{
    public partial class initialise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(name: "Room Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(name: "Room Type", type: "nvarchar(max)", nullable: false),
                    Numberofrooms = table.Column<string>(name: "Number of rooms", type: "nvarchar(max)", nullable: false),
                    AvailabilityStatusYesorNo = table.Column<string>(name: "Availability Status  Yes or No", type: "nvarchar(max)", nullable: false),
                    Amenties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomPrice = table.Column<float>(name: "Room Price", type: "real", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
