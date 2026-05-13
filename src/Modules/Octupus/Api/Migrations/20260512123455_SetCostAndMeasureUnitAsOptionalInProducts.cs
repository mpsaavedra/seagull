using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Octupus.Api.Migrations
{
    /// <inheritdoc />
    public partial class SetCostAndMeasureUnitAsOptionalInProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moneys_Currencies_CurrentyId",
                table: "Moneys");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MeasureUnits_MeasureUnitId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CurrentyId",
                table: "Moneys",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Moneys_CurrentyId",
                table: "Moneys",
                newName: "IX_Moneys_CurrencyId");

            migrationBuilder.AlterColumn<string>(
                name: "MeasureUnitId",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Moneys_Currencies_CurrencyId",
                table: "Moneys",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MeasureUnits_MeasureUnitId",
                table: "Products",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moneys_Currencies_CurrencyId",
                table: "Moneys");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MeasureUnits_MeasureUnitId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Moneys",
                newName: "CurrentyId");

            migrationBuilder.RenameIndex(
                name: "IX_Moneys_CurrencyId",
                table: "Moneys",
                newName: "IX_Moneys_CurrentyId");

            migrationBuilder.AlterColumn<string>(
                name: "MeasureUnitId",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Moneys_Currencies_CurrentyId",
                table: "Moneys",
                column: "CurrentyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MeasureUnits_MeasureUnitId",
                table: "Products",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
