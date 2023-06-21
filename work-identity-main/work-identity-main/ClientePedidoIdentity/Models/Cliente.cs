using System.ComponentModel.DataAnnotations;

namespace ClientePedidoIdentity.Models;

public class Cliente
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Sobrenome { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string CPF { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
    public DateTime DataNascimento { get; set; }

    public ICollection<Pedido>? Pedidos { get; set; }
}
