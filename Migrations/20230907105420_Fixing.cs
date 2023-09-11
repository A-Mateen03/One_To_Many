using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_CommerceSite.Migrations
{
    /// <inheritdoc />
    public partial class Fixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Products_ProductsP_ID",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ProductsP_ID",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ProductsP_ID",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "P_ID",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_P_ID",
                table: "Sizes",
                column: "P_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Products_P_ID",
                table: "Sizes",
                column: "P_ID",
                principalTable: "Products",
                principalColumn: "P_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Products_P_ID",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_P_ID",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "P_ID",
                table: "Sizes");

            migrationBuilder.AddColumn<int>(
                name: "ProductsP_ID",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ProductsP_ID",
                table: "Sizes",
                column: "ProductsP_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Products_ProductsP_ID",
                table: "Sizes",
                column: "ProductsP_ID",
                principalTable: "Products",
                principalColumn: "P_ID");
        }
    }
}
