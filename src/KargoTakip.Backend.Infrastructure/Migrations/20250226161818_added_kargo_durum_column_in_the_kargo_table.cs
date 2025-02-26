using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KargoTakip.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class added_kargo_durum_column_in_the_kargo_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KargoDurum",
                table: "Kargolarim",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KargoDurum",
                table: "Kargolarim");
        }
    }
}
