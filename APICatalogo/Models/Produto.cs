using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        [Column(TypeName  = "decimal(10,2)")]// 10 dígitos com 2 casas decimais
        public decimal Preco { get; set; }
        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; } // chave estrangeira

        [JsonIgnore] // assim, essa propriedade de navegação não será serializada
        public Categoria? Categoria { get; set; }//propriedade de navegação

    }
}
