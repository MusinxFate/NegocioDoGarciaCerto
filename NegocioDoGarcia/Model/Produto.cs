using System.ComponentModel.DataAnnotations;

namespace NegocioDoGarcia.Model
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string? Descricao { get; set; }
        public double Preco { get; set; }
    }
}
