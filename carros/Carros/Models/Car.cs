using System.ComponentModel.DataAnnotations;

namespace Carros.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
    }
}
