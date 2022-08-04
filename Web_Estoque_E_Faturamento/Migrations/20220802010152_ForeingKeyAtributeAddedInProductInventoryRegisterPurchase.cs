using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Estoque_E_Faturamento.Migrations
{
    public partial class ForeingKeyAtributeAddedInProductInventoryRegisterPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventoryRegisterPurchase_ProductInventory_ProductIn~",
                table: "ProductInventoryRegisterPurchase");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventoryRegisterPurchase_ProductInventory_ProductIn~",
                table: "ProductInventoryRegisterPurchase",
                column: "ProductInventoryId",
                principalTable: "ProductInventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
