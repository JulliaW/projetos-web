using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlunoCursoIdentity.Models
{
    public class Curso
    {
        [Key]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do curso")]
        [Display(Name = "Nome do curso: ")]
        public string NomeCurso { get; set; }

        [Required(ErrorMessage = "Informe a carga horária")]
        [Display(Name = "Carga horária: ")]

        public string CH { get; set; }

        [Display(Name = "Disciplina: ")]
        public string Disciplina { get; set; }

        [Display(Name = "Total de alunos: ")]
        public string TotalAlunos { get; set; }

        [Display(Name = "Professor: ")]
        public string Professor { get; set; }

        public virtual ICollection<Aluno>? Alunos { get; set; }
    }
}
