using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Estoque_E_Faturamento.Migrations
{
    public partial class NewOneToManyRelationshipAmongProductInventoryAnProductInventoryRegisterPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventoryRegisterPurchase_ProductInventory_ProductIn~",
                table: "ProductInventoryRegisterPurchase");

            migrationBuilder.AlterColumn<int>(
                name: "ProductInventoryId",
                table: "ProductInventoryRegisterPurchase",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventoryRegisterPurchase_ProductInventory_ProductIn~",
                table: "ProductInventoryRegisterPurchase",
                column: "ProductInventoryId",
                principalTable: "ProductInventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventoryRegisterPurchase_ProductInventory_ProductIn~",
                table: "ProductInventoryRegisterPurchase");

            migrationBuilder.AlterColumn<int>(
                name: "ProductInventoryId",
                table: "ProductInventoryRegisterPurchase",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventoryRegisterPurchase_ProductInventory_ProductIn~",
                table: "ProductInventoryRegisterPurchase",
                column: "ProductInventoryId",
                principalTable: "ProductInventory",
                principalColumn: "Id");
        }
    }
}
