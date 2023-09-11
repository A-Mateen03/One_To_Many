using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_CommerceSite.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    P_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Price = table.Column<int>(type: "int", nullable: false),
                    P_Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.P_ID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductsP_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                    table.ForeignKey(
                        name: "FK_Sizes_Products_ProductsP_ID",
                        column: x => x.ProductsP_ID,
                        principalTable: "Products",
                        principalColumn: "P_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ProductsP_ID",
                table: "Sizes",
                column: "ProductsP_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
