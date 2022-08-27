using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Estoque_E_Faturamento.MigrationsIndependentObjectsOfProductsContext
{
    public partial class ChangedNameAlready : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_AlreadyBuyed",
                table: "ProductListReminderToBuyWithoutUseProductAlreadyRegistered",
                newName: "AlreadyBuyed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlreadyBuyed",
                table: "ProductListReminderToBuyWithoutUseProductAlreadyRegistered",
                newName: "_AlreadyBuyed");
        }
    }
}
