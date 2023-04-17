using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlunoCursoIdentity.Models
{
    public class Aluno
    {
        [Key]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a matricula")]
        [Display(Name = "Matricula: ")]
        public string Matricula { get; set; }

        [Display(Name = "Telefone: ")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail: ")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Display(Name = "Sexo: ")]
        public string Sexo { get; set; }

        [ForeignKey("Curso")]
        [Column(Order = 1)]
        public int? CursoId { get; set; }

        public virtual Curso? Curso { get; set; }
    }
}
