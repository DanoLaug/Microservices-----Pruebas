using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    IDProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IDProduct);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    IDProductInStock = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.IDProductInStock);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "IDProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "IDProduct", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for Product 1", "Product 1", 333m },
                    { 2, "Description for Product 2", "Product 2", 180m },
                    { 3, "Description for Product 3", "Product 3", 508m },
                    { 4, "Description for Product 4", "Product 4", 358m },
                    { 5, "Description for Product 5", "Product 5", 398m },
                    { 6, "Description for Product 6", "Product 6", 842m },
                    { 7, "Description for Product 7", "Product 7", 362m },
                    { 8, "Description for Product 8", "Product 8", 891m },
                    { 9, "Description for Product 9", "Product 9", 694m },
                    { 10, "Description for Product 10", "Product 10", 436m },
                    { 11, "Description for Product 11", "Product 11", 561m },
                    { 12, "Description for Product 12", "Product 12", 449m },
                    { 13, "Description for Product 13", "Product 13", 534m },
                    { 14, "Description for Product 14", "Product 14", 677m },
                    { 15, "Description for Product 15", "Product 15", 279m },
                    { 16, "Description for Product 16", "Product 16", 590m },
                    { 17, "Description for Product 17", "Product 17", 270m },
                    { 18, "Description for Product 18", "Product 18", 981m },
                    { 19, "Description for Product 19", "Product 19", 605m },
                    { 20, "Description for Product 20", "Product 20", 581m },
                    { 21, "Description for Product 21", "Product 21", 835m },
                    { 22, "Description for Product 22", "Product 22", 749m },
                    { 23, "Description for Product 23", "Product 23", 227m },
                    { 24, "Description for Product 24", "Product 24", 596m },
                    { 25, "Description for Product 25", "Product 25", 576m },
                    { 26, "Description for Product 26", "Product 26", 152m },
                    { 27, "Description for Product 27", "Product 27", 193m },
                    { 28, "Description for Product 28", "Product 28", 251m },
                    { 29, "Description for Product 29", "Product 29", 134m },
                    { 30, "Description for Product 30", "Product 30", 357m },
                    { 31, "Description for Product 31", "Product 31", 890m },
                    { 32, "Description for Product 32", "Product 32", 140m },
                    { 33, "Description for Product 33", "Product 33", 426m },
                    { 34, "Description for Product 34", "Product 34", 450m },
                    { 35, "Description for Product 35", "Product 35", 265m },
                    { 36, "Description for Product 36", "Product 36", 269m },
                    { 37, "Description for Product 37", "Product 37", 269m },
                    { 38, "Description for Product 38", "Product 38", 143m },
                    { 39, "Description for Product 39", "Product 39", 894m },
                    { 40, "Description for Product 40", "Product 40", 359m },
                    { 41, "Description for Product 41", "Product 41", 239m },
                    { 42, "Description for Product 42", "Product 42", 131m },
                    { 43, "Description for Product 43", "Product 43", 314m },
                    { 44, "Description for Product 44", "Product 44", 941m },
                    { 45, "Description for Product 45", "Product 45", 339m },
                    { 46, "Description for Product 46", "Product 46", 401m },
                    { 47, "Description for Product 47", "Product 47", 683m },
                    { 48, "Description for Product 48", "Product 48", 493m },
                    { 49, "Description for Product 49", "Product 49", 274m },
                    { 50, "Description for Product 50", "Product 50", 606m },
                    { 51, "Description for Product 51", "Product 51", 653m },
                    { 52, "Description for Product 52", "Product 52", 114m },
                    { 53, "Description for Product 53", "Product 53", 703m },
                    { 54, "Description for Product 54", "Product 54", 786m },
                    { 55, "Description for Product 55", "Product 55", 242m },
                    { 56, "Description for Product 56", "Product 56", 872m },
                    { 57, "Description for Product 57", "Product 57", 228m },
                    { 58, "Description for Product 58", "Product 58", 612m },
                    { 59, "Description for Product 59", "Product 59", 642m },
                    { 60, "Description for Product 60", "Product 60", 923m },
                    { 61, "Description for Product 61", "Product 61", 688m },
                    { 62, "Description for Product 62", "Product 62", 768m },
                    { 63, "Description for Product 63", "Product 63", 971m },
                    { 64, "Description for Product 64", "Product 64", 463m },
                    { 65, "Description for Product 65", "Product 65", 816m },
                    { 66, "Description for Product 66", "Product 66", 506m },
                    { 67, "Description for Product 67", "Product 67", 135m },
                    { 68, "Description for Product 68", "Product 68", 337m },
                    { 69, "Description for Product 69", "Product 69", 903m },
                    { 70, "Description for Product 70", "Product 70", 156m },
                    { 71, "Description for Product 71", "Product 71", 206m },
                    { 72, "Description for Product 72", "Product 72", 107m },
                    { 73, "Description for Product 73", "Product 73", 272m },
                    { 74, "Description for Product 74", "Product 74", 424m },
                    { 75, "Description for Product 75", "Product 75", 326m },
                    { 76, "Description for Product 76", "Product 76", 660m },
                    { 77, "Description for Product 77", "Product 77", 590m },
                    { 78, "Description for Product 78", "Product 78", 711m },
                    { 79, "Description for Product 79", "Product 79", 271m },
                    { 80, "Description for Product 80", "Product 80", 663m },
                    { 81, "Description for Product 81", "Product 81", 518m },
                    { 82, "Description for Product 82", "Product 82", 768m },
                    { 83, "Description for Product 83", "Product 83", 651m },
                    { 84, "Description for Product 84", "Product 84", 959m },
                    { 85, "Description for Product 85", "Product 85", 393m },
                    { 86, "Description for Product 86", "Product 86", 713m },
                    { 87, "Description for Product 87", "Product 87", 287m },
                    { 88, "Description for Product 88", "Product 88", 161m },
                    { 89, "Description for Product 89", "Product 89", 116m },
                    { 90, "Description for Product 90", "Product 90", 403m },
                    { 91, "Description for Product 91", "Product 91", 730m },
                    { 92, "Description for Product 92", "Product 92", 281m },
                    { 93, "Description for Product 93", "Product 93", 301m },
                    { 94, "Description for Product 94", "Product 94", 675m },
                    { 95, "Description for Product 95", "Product 95", 703m },
                    { 96, "Description for Product 96", "Product 96", 939m },
                    { 97, "Description for Product 97", "Product 97", 542m },
                    { 98, "Description for Product 98", "Product 98", 571m },
                    { 99, "Description for Product 99", "Product 99", 884m },
                    { 100, "Description for Product 100", "Product 100", 962m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "IDProductInStock", "ProductID", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 2, 14 },
                    { 3, 3, 5 },
                    { 4, 4, 7 },
                    { 5, 5, 3 },
                    { 6, 6, 10 },
                    { 7, 7, 13 },
                    { 8, 8, 11 },
                    { 9, 9, 14 },
                    { 10, 10, 8 },
                    { 11, 11, 16 },
                    { 12, 12, 16 },
                    { 13, 13, 10 },
                    { 14, 14, 7 },
                    { 15, 15, 18 },
                    { 16, 16, 10 },
                    { 17, 17, 4 },
                    { 18, 18, 16 },
                    { 19, 19, 14 },
                    { 20, 20, 16 },
                    { 21, 21, 14 },
                    { 22, 22, 12 },
                    { 23, 23, 13 },
                    { 24, 24, 0 },
                    { 25, 25, 17 },
                    { 26, 26, 5 },
                    { 27, 27, 16 },
                    { 28, 28, 5 },
                    { 29, 29, 14 },
                    { 30, 30, 9 },
                    { 31, 31, 16 },
                    { 32, 32, 8 },
                    { 33, 33, 2 },
                    { 34, 34, 6 },
                    { 35, 35, 2 },
                    { 36, 36, 1 },
                    { 37, 37, 6 },
                    { 38, 38, 10 },
                    { 39, 39, 8 },
                    { 40, 40, 6 },
                    { 41, 41, 12 },
                    { 42, 42, 7 },
                    { 43, 43, 19 },
                    { 44, 44, 0 },
                    { 45, 45, 2 },
                    { 46, 46, 15 },
                    { 47, 47, 11 },
                    { 48, 48, 14 },
                    { 49, 49, 7 },
                    { 50, 50, 5 },
                    { 51, 51, 0 },
                    { 52, 52, 13 },
                    { 53, 53, 7 },
                    { 54, 54, 9 },
                    { 55, 55, 16 },
                    { 56, 56, 4 },
                    { 57, 57, 10 },
                    { 58, 58, 15 },
                    { 59, 59, 6 },
                    { 60, 60, 5 },
                    { 61, 61, 0 },
                    { 62, 62, 6 },
                    { 63, 63, 18 },
                    { 64, 64, 17 },
                    { 65, 65, 2 },
                    { 66, 66, 0 },
                    { 67, 67, 2 },
                    { 68, 68, 10 },
                    { 69, 69, 7 },
                    { 70, 70, 17 },
                    { 71, 71, 9 },
                    { 72, 72, 17 },
                    { 73, 73, 11 },
                    { 74, 74, 8 },
                    { 75, 75, 3 },
                    { 76, 76, 7 },
                    { 77, 77, 1 },
                    { 78, 78, 13 },
                    { 79, 79, 12 },
                    { 80, 80, 5 },
                    { 81, 81, 19 },
                    { 82, 82, 10 },
                    { 83, 83, 7 },
                    { 84, 84, 17 },
                    { 85, 85, 1 },
                    { 86, 86, 7 },
                    { 87, 87, 17 },
                    { 88, 88, 10 },
                    { 89, 89, 8 },
                    { 90, 90, 7 },
                    { 91, 91, 13 },
                    { 92, 92, 18 },
                    { 93, 93, 7 },
                    { 94, 94, 16 },
                    { 95, 95, 0 },
                    { 96, 96, 5 },
                    { 97, 97, 15 },
                    { 98, 98, 1 },
                    { 99, 99, 6 },
                    { 100, 100, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductID",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
