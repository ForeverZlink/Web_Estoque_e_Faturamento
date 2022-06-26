using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web_Estoque_E_Faturamento.Migrations
{
    public partial class NewModelProductInventoryRegisterPurchasesAndProviderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Andress = table.Column<string>(type: "text", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventoryRegisterPurchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuantityBuyed = table.Column<float>(type: "real", nullable: false),
                    DateOfPurchase = table.Column<string>(type: "text", nullable: false),
                    PriceOfPurchase = table.Column<float>(type: "real", nullable: false),
                    PriceProductUnity = table.Column<float>(type: "real", nullable: false),
                    ProviderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventoryRegisterPurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInventoryRegisterPurchase_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInventoryRegisterPurchase_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventoryRegisterPurchase_ProductId",
                table: "ProductInventoryRegisterPurchase",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventoryRegisterPurchase_ProviderId",
                table: "ProductInventoryRegisterPurchase",
                column: "ProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInventoryRegisterPurchase");

            migrationBuilder.DropTable(
                name: "Provider");
        }
    }
}
