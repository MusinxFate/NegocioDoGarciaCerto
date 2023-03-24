using System.ComponentModel.DataAnnotations;

namespace NegocioDoGarcia.Model
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}