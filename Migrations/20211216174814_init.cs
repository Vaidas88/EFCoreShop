using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "ExpiryDate", "Name", "ShopId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 14, 17, 48, 14, 551, DateTimeKind.Utc).AddTicks(1067), "Banana", 1 },
                    { 2, new DateTime(2022, 2, 14, 17, 48, 14, 551, DateTimeKind.Utc).AddTicks(1951), "Apple", 1 },
                    { 3, new DateTime(2022, 2, 14, 17, 48, 14, 551, DateTimeKind.Utc).AddTicks(1955), "Phone", 2 },
                    { 4, new DateTime(2022, 2, 14, 17, 48, 14, 551, DateTimeKind.Utc).AddTicks(1956), "PC", 2 },
                    { 5, new DateTime(2022, 2, 14, 17, 48, 14, 551, DateTimeKind.Utc).AddTicks(1958), "TV", 2 },
                    { 6, new DateTime(2022, 2, 14, 17, 48, 14, 551, DateTimeKind.Utc).AddTicks(1959), "Potato", 1 }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Food Shop" },
                    { 2, "Electronics Shop" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopItems");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
