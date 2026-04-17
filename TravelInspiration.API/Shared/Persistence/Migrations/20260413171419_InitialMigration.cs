using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelInspiration.API.Shared.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ItenaryId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stops_Itineraries_ItenaryId",
                        column: x => x.ItenaryId,
                        principalTable: "Itineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Itineraries",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastUpdatedOn", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Paddy", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Five days in the City of Light", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A Trip to Paris", "user1" },
                    { 2, "Paddy", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A week-long journey through Tokyo", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Exploring Tokyo", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Stops",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ImageUri", "ItenaryId", "LastModifiedBy", "LastUpdatedOn", "Name" },
                values: new object[,]
                {
                    { 1, "Paddy", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://localhost/images/eiffel.jpg", 1, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Eiffel Tower" },
                    { 2, "Paddy", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://localhost/images/louvre.jpg", 1, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Louvre Museum" },
                    { 3, "Paddy", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://localhost/images/shibuya.jpg", 2, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Shibuya Crossing" },
                    { 4, "Paddy", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://localhost/images/sensoji.jpg", 2, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Senso-ji Temple" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stops_ItenaryId",
                table: "Stops",
                column: "ItenaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Itineraries");
        }
    }
}
