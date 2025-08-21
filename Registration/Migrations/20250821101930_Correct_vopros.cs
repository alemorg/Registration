using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Migrations
{
    /// <inheritdoc />
    public partial class Correct_vopros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedRoom_UserInfo_VisitorId",
                table: "BookedRoom");

            migrationBuilder.AlterColumn<int>(
                name: "VisitorId",
                table: "BookedRoom",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedRoom_UserInfo_VisitorId",
                table: "BookedRoom",
                column: "VisitorId",
                principalTable: "UserInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedRoom_UserInfo_VisitorId",
                table: "BookedRoom");

            migrationBuilder.AlterColumn<int>(
                name: "VisitorId",
                table: "BookedRoom",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedRoom_UserInfo_VisitorId",
                table: "BookedRoom",
                column: "VisitorId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
