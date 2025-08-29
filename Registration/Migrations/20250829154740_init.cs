using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Registration.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "text", nullable: false),
                    IsAgree = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Square = table.Column<int>(type: "integer", nullable: false),
                    Capasity = table.Column<int>(type: "integer", nullable: false),
                    isActivity = table.Column<bool>(type: "boolean", nullable: false),
                    Discription = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booked",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dataBooked = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GuestFirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GuestSecondName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GuestLastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GuestPhone = table.Column<string>(type: "text", nullable: false),
                    NumberGuest = table.Column<int>(type: "integer", nullable: false),
                    SpecialRequests = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Roomid = table.Column<int>(type: "integer", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booked", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booked_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Booked_Room_Roomid",
                        column: x => x.Roomid,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booked_HotelId",
                table: "Booked",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Booked_Roomid",
                table: "Booked",
                column: "Roomid");

            migrationBuilder.CreateIndex(
                name: "IX_Room_HotelId",
                table: "Room",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booked");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
