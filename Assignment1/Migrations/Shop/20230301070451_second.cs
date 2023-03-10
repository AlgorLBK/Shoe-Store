using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Migrations.Shop
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartBid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndBid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserAuhtor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 1, "Nike" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 2, "Adidas" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 3, "Puma" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "Code", "Condition", "Description", "EndBid", "Name", "Price", "StartBid", "UserAuhtor" },
                values: new object[,]
                {
                    { 1, 1, "nike_mercurial", "Good", "Shoes", "2023/5/15", "Nike Mercurial", 125m, "2022/12/1", "admin@gmail.com" },
                    { 2, 1, "nike_vapor", "Good", "Shoes", "2023/5/15", "Nike Vapor", 208.85m, "2022/12/1", "admin@gmail.com" },
                    { 3, 3, "puma_future", "Good", "Shoes", "2023/5/15", "Puma Future", 285m, "2022/12/1", "admin@gmail.com" },
                    { 4, 3, "puma_court", "Good", "Shoes", "2023/5/15", "Court Rider", 120m, "2022/12/1", "admin@gmail.com" },
                    { 5, 2, "adidas_ozelia", "Good", "Shoes", "2023/5/15", "Adidas Ozelia", 130m, "2022/12/1", "admin@gmail.com" },
                    { 6, 2, "adidas_ozweego", "Good", "Shoes", "2023/5/15", "Adidas Ozweego", 170m, "2022/12/1", "admin@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
