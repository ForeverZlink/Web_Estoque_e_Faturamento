using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Estoque_E_Faturamento.MvcIndependentObjectsOfProductsContextSqlServer
{
    public partial class NewMigrationsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductListReminderToBuyWithoutUseProductAlreadyRegistered",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfCreation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeOfProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityToBuy = table.Column<float>(type: "real", nullable: false),
                    WillBePurchased = table.Column<bool>(type: "bit", nullable: false),
                    AlreadyBuyed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductListReminderToBuyWithoutUseProductAlreadyRegistered", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductListReminderToBuyWithoutUseProductAlreadyRegistered");
        }
    }
}
