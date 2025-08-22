using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Migrations
{
    /// <inheritdoc />
    public partial class addNavpropBookedRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedRoom_Room_RoomId",
                table: "BookedRoom");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "BookedRoom",
                newName: "Roomid");

            migrationBuilder.RenameIndex(
                name: "IX_BookedRoom_RoomId",
                table: "BookedRoom",
                newName: "IX_BookedRoom_Roomid");

            migrationBuilder.AlterColumn<int>(
                name: "Roomid",
                table: "BookedRoom",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedRoom_Room_Roomid",
                table: "BookedRoom",
                column: "Roomid",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedRoom_Room_Roomid",
                table: "BookedRoom");

            migrationBuilder.RenameColumn(
                name: "Roomid",
                table: "BookedRoom",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_BookedRoom_Roomid",
                table: "BookedRoom",
                newName: "IX_BookedRoom_RoomId");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "BookedRoom",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedRoom_Room_RoomId",
                table: "BookedRoom",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }
    }
}
