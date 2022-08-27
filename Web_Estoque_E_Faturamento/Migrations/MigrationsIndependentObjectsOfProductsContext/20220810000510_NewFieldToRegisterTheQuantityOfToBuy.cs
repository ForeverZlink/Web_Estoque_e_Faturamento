using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Estoque_E_Faturamento.MigrationsIndependentObjectsOfProductsContext
{
    public partial class NewFieldToRegisterTheQuantityOfToBuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "QuantityToBuy",
                table: "ProductListReminderToBuyWithoutUseProductAlreadyRegistered",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityToBuy",
                table: "ProductListReminderToBuyWithoutUseProductAlreadyRegistered");
        }
    }
}
