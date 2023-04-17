using System.ComponentModel.DataAnnotations;

namespace ClientePedidoIdentity.Models;

public class Pedido
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Descricao { get; set; }

    [Required]
    public decimal Preco { get; set; }

    [Required]
    public string Endereco { get; set; }

    [Required]
    public DateTime DataExpedicao { get; set; }

    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
}
