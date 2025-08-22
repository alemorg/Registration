using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Migrations
{
    /// <inheritdoc />
    public partial class addBookedRoomtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedRoom_RoomInfo_RoomId",
                table: "BookedRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedRoom_UserInfo_VisitorId",
                table: "BookedRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomInfo_HotelInfo_HotelId",
                table: "RoomInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomInfo",
                table: "RoomInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelInfo",
                table: "HotelInfo");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "RoomInfo",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "HotelInfo",
                newName: "Hotel");

            migrationBuilder.RenameIndex(
                name: "IX_RoomInfo_HotelId",
                table: "Room",
                newName: "IX_Room_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedRoom_Room_RoomId",
                table: "BookedRoom",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedRoom_User_VisitorId",
                table: "BookedRoom",
                column: "VisitorId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Hotel_HotelId",
                table: "Room",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedRoom_Room_RoomId",
                table: "BookedRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedRoom_User_VisitorId",
                table: "BookedRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Hotel_HotelId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "UserInfo");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "RoomInfo");

            migrationBuilder.RenameTable(
                name: "Hotel",
                newName: "HotelInfo");

            migrationBuilder.RenameIndex(
                name: "IX_Room_HotelId",
                table: "RoomInfo",
                newName: "IX_RoomInfo_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomInfo",
                table: "RoomInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelInfo",
                table: "HotelInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedRoom_RoomInfo_RoomId",
                table: "BookedRoom",
                column: "RoomId",
                principalTable: "RoomInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedRoom_UserInfo_VisitorId",
                table: "BookedRoom",
                column: "VisitorId",
                principalTable: "UserInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomInfo_HotelInfo_HotelId",
                table: "RoomInfo",
                column: "HotelId",
                principalTable: "HotelInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
