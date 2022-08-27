using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web_Estoque_E_Faturamento.MigrationsIndependentObjectsOfProductsContext
{
    public partial class NewModelTORegisterProductWIthNOtAreInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductListReminderToBuyWithoutUseProductAlreadyRegistered",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameOfProduct = table.Column<string>(type: "text", nullable: false),
                    CodeOfProduct = table.Column<string>(type: "text", nullable: false),
                    DateOfCreation = table.Column<string>(type: "text", nullable: false),
                    AlreadyBuyed = table.Column<bool>(type: "boolean", nullable: false)
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
