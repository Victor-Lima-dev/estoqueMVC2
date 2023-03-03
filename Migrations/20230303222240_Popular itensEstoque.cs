using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoqueMVC2.Migrations
{
    /// <inheritdoc />
    public partial class PopularitensEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           //popular a tabela de itens de estoque, a quantidade só pode ser: 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, começa pelo produto de id 2 vai até o 23, o estoqueid é sem 1
              migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (2, 10, 1)");
                
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (4, 30, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (5, 40, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (6, 50, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (7, 60, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (8, 70, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (9, 80, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (10, 90, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (11, 100, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (12, 10, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (13, 20, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (14, 30, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (15, 40, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (16, 50, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (17, 60, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (18, 70, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (19, 80, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (20, 90, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (21, 100, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (22, 10, 1)");
                migrationBuilder.Sql("INSERT INTO ItensEstoque (ProdutoId, Quantidade, EstoqueId) VALUES (23, 20, 1)");



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //delete
            migrationBuilder.Sql("DELETE FROM ItensEstoque");
        }
    }
}
