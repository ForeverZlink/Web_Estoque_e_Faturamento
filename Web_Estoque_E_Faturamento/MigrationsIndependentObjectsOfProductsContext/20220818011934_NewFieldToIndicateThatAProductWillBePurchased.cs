using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Estoque_E_Faturamento.MigrationsIndependentObjectsOfProductsContext
{
    public partial class NewFieldToIndicateThatAProductWillBePurchased : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WillBePurchased",
                table: "ProductListReminderToBuyWithoutUseProductAlreadyRegistered",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WillBePurchased",
                table: "ProductListReminderToBuyWithoutUseProductAlreadyRegistered");
        }
    }
}
