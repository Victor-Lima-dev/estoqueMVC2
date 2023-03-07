using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoqueMVC2.Migrations
{
    /// <inheritdoc />
    public partial class modificaçoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Relatorios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Relatorios");
        }
    }
}
