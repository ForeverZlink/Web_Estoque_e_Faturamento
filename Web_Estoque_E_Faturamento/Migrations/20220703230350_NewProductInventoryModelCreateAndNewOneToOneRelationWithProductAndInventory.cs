using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web_Estoque_E_Faturamento.Migrations
{
    public partial class NewProductInventoryModelCreateAndNewOneToOneRelationWithProductAndInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductInventoryId",
                table: "ProductInventoryRegisterPurchase",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuantityInStock = table.Column<float>(type: "real", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventoryRegisterPurchase_ProductInventoryId",
                table: "ProductInventoryRegisterPurchase",
                column: "ProductInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_ProductId",
                table: "ProductInventory",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventoryRegisterPurchase_ProductInventory_ProductIn~",
                table: "ProductInventoryRegisterPurchase",
                column: "ProductInventoryId",
                principalTable: "ProductInventory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventoryRegisterPurchase_ProductInventory_ProductIn~",
                table: "ProductInventoryRegisterPurchase");

            migrationBuilder.DropTable(
                name: "ProductInventory");

            migrationBuilder.DropIndex(
                name: "IX_ProductInventoryRegisterPurchase_ProductInventoryId",
                table: "ProductInventoryRegisterPurchase");

            migrationBuilder.DropColumn(
                name: "ProductInventoryId",
                table: "ProductInventoryRegisterPurchase");
        }
    }
}
