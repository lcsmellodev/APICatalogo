using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "VALUES('Coca-Cola DIET', 'Refrigerante de cola 350 ml', 5.45, 'cocacola.jpg', 50, now(), 1)");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
               "VALUES('Lanchce de Atum', 'Lanche de atum com maionese', 8.50, 'atum.jpg.jpg', 10, now(), 2)");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
               "VALUES('Pudim 100g', 'Pudim de leite condensado 100 g', 6.75, 'pudim.jpg', 20, now(), 3)");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM produtos");
        }
    }
}
