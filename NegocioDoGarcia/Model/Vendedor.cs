using System.ComponentModel.DataAnnotations;

namespace NegocioDoGarcia.Model
{
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }
        public string NomeVendedor { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
