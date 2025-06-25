using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 25, 20, 5, 56, 261, DateTimeKind.Utc).AddTicks(1108), "Elektronik Ürünler", null, "Elektronik" },
                    { 2, new DateTime(2025, 6, 25, 20, 5, 56, 261, DateTimeKind.Utc).AddTicks(1120), "Giyim Ürünler,", null, "Giyim" },
                    { 3, new DateTime(2025, 6, 25, 20, 5, 56, 261, DateTimeKind.Utc).AddTicks(1122), "Kozmetik Ürünler", null, "Kozmetik" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImageUrl", "LastModifiedDate", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("051c2d42-a940-4082-b50a-aa9efcadb2ff"), 1, new DateTime(2025, 6, 25, 20, 5, 56, 261, DateTimeKind.Utc).AddTicks(1460), "Akıllı telefon", "noimage.png", null, "Samsung Galaxy S21", 9999.99m, 50 },
                    { new Guid("158b14cd-8a97-4a9e-9109-d5f4db325ed1"), 1, new DateTime(2025, 6, 25, 20, 5, 56, 261, DateTimeKind.Utc).AddTicks(1512), "Akıllı telefon", "noimage.png", null, "Apple iPhone 13", 12999.99m, 30 },
                    { new Guid("9718982f-4fc1-4c84-b302-e16d1b2aef1e"), 3, new DateTime(2025, 6, 25, 20, 5, 56, 261, DateTimeKind.Utc).AddTicks(1674), "Saç şampuanı", "noimage.png", null, "L'Oréal Paris Şampuan", 49.99m, 200 },
                    { new Guid("f9e83617-bad1-4617-9329-8ded2f129f12"), 2, new DateTime(2025, 6, 25, 20, 5, 56, 261, DateTimeKind.Utc).AddTicks(1516), "Spor ayakkabı", "noimage.png", null, "Nike Air Max", 799.99m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
