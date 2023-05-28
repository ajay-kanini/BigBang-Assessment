using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageBooking.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(name: "Booking Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(name: "User Id", type: "int", nullable: false),
                    RoomId = table.Column<int>(name: "Room Id", type: "int", nullable: false),
                    HotelId = table.Column<int>(name: "Hotel Id", type: "int", nullable: false),
                    CheckinDate = table.Column<DateTime>(name: "Check-in Date", type: "datetime2", nullable: false),
                    CheckoutDate = table.Column<DateTime>(name: "Check-out Date", type: "datetime2", nullable: false),
                    BillAmount = table.Column<double>(name: "Bill Amount", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
