using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopItems_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopItemModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_ShopItems_ShopItemModelId",
                        column: x => x.ShopItemModelId,
                        principalTable: "ShopItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopItemTags",
                columns: table => new
                {
                    ShopItemId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemTags", x => new { x.TagId, x.ShopItemId });
                    table.ForeignKey(
                        name: "FK_ShopItemTags_ShopItems_ShopItemId",
                        column: x => x.ShopItemId,
                        principalTable: "ShopItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopItemTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Food Shop" },
                    { 2, false, "Electronics Shop" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name", "ShopItemModelId" },
                values: new object[,]
                {
                    { 1, "Tag #1", null },
                    { 2, "Tag #2", null },
                    { 3, "Other Tag #3", null },
                    { 4, "One more Tag #4", null }
                });

            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "ExpiryDate", "IsDeleted", "Name", "ShopId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 20, 18, 32, 29, 817, DateTimeKind.Utc).AddTicks(4254), false, "Banana", 1 },
                    { 2, new DateTime(2022, 2, 20, 18, 32, 29, 817, DateTimeKind.Utc).AddTicks(5130), false, "Apple", 1 },
                    { 6, new DateTime(2022, 2, 20, 18, 32, 29, 817, DateTimeKind.Utc).AddTicks(5138), false, "Potato", 1 },
                    { 3, new DateTime(2022, 2, 20, 18, 32, 29, 817, DateTimeKind.Utc).AddTicks(5134), false, "Phone", 2 },
                    { 4, new DateTime(2022, 2, 20, 18, 32, 29, 817, DateTimeKind.Utc).AddTicks(5135), false, "PC", 2 },
                    { 5, new DateTime(2022, 2, 20, 18, 32, 29, 817, DateTimeKind.Utc).AddTicks(5137), false, "TV", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_ShopId",
                table: "ShopItems",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemTags_ShopItemId",
                table: "ShopItemTags",
                column: "ShopItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ShopItemModelId",
                table: "Tags",
                column: "ShopItemModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopItemTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "ShopItems");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
