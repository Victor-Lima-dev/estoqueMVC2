using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estoqueMVC2.Migrations
{
    /// <inheritdoc />
    public partial class populardatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //popular a tabela de produtos, a categoria só pode ser: Alimento, Bebida, Limpeza, Higiene , 5 de cada
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Arroz', 'Arroz 5kg', 10.00, 'Alimento')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Feijão', 'Feijão 1kg', 5.00, 'Alimento')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Macarrão', 'Macarrão 1kg', 3.00, 'Alimento')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Açúcar', 'Açúcar 1kg', 2.00, 'Alimento')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Farinha', 'Farinha 1kg', 2.00, 'Alimento')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Coca-Cola', 'Refrigerante 2L', 5.00, 'Bebida')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Guaraná', 'Refrigerante 2L', 5.00, 'Bebida')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Suco de Laranja', 'Suco 1L', 5.00, 'Bebida')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Suco de Uva', 'Suco 1L', 5.00, 'Bebida')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Suco de Abacaxi', 'Suco 1L', 5.00, 'Bebida')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Sabão em Pó', 'Sabão em Pó 1kg', 5.00, 'Limpeza')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Detergente', 'Detergente 1L', 5.00, 'Limpeza')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Água Sanitária', 'Água Sanitária 1L', 5.00, 'Limpeza')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Amaciante', 'Amaciante 1L', 5.00, 'Limpeza')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Sabonete', 'Sabonete 1 unidade', 5.00, 'Higiene')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Shampoo', 'Shampoo 1 unidade', 5.00, 'Higiene')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Condicionador', 'Condicionador 1 unidade', 5.00, 'Higiene')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Escova de Dente', 'Escova de Dente 1 unidade', 5.00, 'Higiene')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Categoria) VALUES ('Pasta de Dente', 'Pasta de Dente 1 unidade', 5.00, 'Higiene')");          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
            
        }
    }
}
