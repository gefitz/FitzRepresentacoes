using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitzRepresentacoes.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoNomeColunaTpProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TpProduto",
                table: "TpProdutos",
                newName: "Tipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "TpProdutos",
                newName: "TpProduto");
        }
    }
}
