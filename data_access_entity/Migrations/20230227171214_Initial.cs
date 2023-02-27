using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data_access_entity.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxPassangers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fligths",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivelTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArrivelCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    AirplaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fligths", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Fligths_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    CredentialsId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.CredentialsId);
                    table.ForeignKey(
                        name: "FK_Passengers_Credentials_CredentialsId",
                        column: x => x.CredentialsId,
                        principalTable: "Credentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientFlight",
                columns: table => new
                {
                    ClientsCredentialsId = table.Column<int>(type: "int", nullable: false),
                    FlightsNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFlight", x => new { x.ClientsCredentialsId, x.FlightsNumber });
                    table.ForeignKey(
                        name: "FK_ClientFlight_Fligths_FlightsNumber",
                        column: x => x.FlightsNumber,
                        principalTable: "Fligths",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFlight_Passengers_ClientsCredentialsId",
                        column: x => x.ClientsCredentialsId,
                        principalTable: "Passengers",
                        principalColumn: "CredentialsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airplanes",
                columns: new[] { "Id", "MaxPassangers", "Model" },
                values: new object[,]
                {
                    { 1, 1200, "Boeing 747" },
                    { 2, 1300, "Boeing 425" }
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "Id", "ClientId", "Login", "Password" },
                values: new object[,]
                {
                    { 1, null, "user1", "1111" },
                    { 2, null, "user2", "2222" }
                });

            migrationBuilder.InsertData(
                table: "Fligths",
                columns: new[] { "Number", "AirplaneId", "ArrivelCity", "ArrivelTime", "DepartureCity", "DepartureTime", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "Lviv", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyiv", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 2, "Lviv", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warsaw", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "CredentialsId", "Birthday", "Email", "FirstName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "victor@gmail.com", "Victor" },
                    { 2, new DateTime(2005, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "olga@gmail.com", "Olga" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFlight_FlightsNumber",
                table: "ClientFlight",
                column: "FlightsNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Fligths_AirplaneId",
                table: "Fligths",
                column: "AirplaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFlight");

            migrationBuilder.DropTable(
                name: "Fligths");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "Credentials");
        }
    }
}
