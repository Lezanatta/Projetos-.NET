using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiNova.Models
{

    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; } 

        [Required]
        [MaxLength(80)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Descricao { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(10,2)")]
        public decimal? Preco { get; set; }

        [Required]
        [MaxLength(300)]
        public string? ImagemUrl { get; set; }
        public float? Estoque { get; set; }
        public DateTime? DataCadastro { get; set; }
        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria? Categoria{ get; set; }


    }
}
