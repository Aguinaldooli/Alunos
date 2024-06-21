using System.ComponentModel.DataAnnotations;

namespace Alunos.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        // O recurso dataAnnotation indica para o entity
        // As restrições de cada coluna o termo [Required] diz para o framework
        //que a coluna não pode ser nula!
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        public int Idade { get; set; }
    }
}
