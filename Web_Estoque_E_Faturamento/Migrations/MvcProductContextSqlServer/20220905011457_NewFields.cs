using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Estoque_E_Faturamento.Migrations.MvcProductContextSqlServer
{
    public partial class NewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DanfeNumber",
                table: "ProductInventoryRegisterPurchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Serie",
                table: "ProductInventoryRegisterPurchase",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DanfeNumber",
                table: "ProductInventoryRegisterPurchase");

            migrationBuilder.DropColumn(
                name: "Serie",
                table: "ProductInventoryRegisterPurchase");
        }
    }
}
