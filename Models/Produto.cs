using System.ComponentModel.DataAnnotations;
namespace ExemploSQLite.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Nome { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Preco { get; set; }
    }
}
