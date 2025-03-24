using System.ComponentModel.DataAnnotations;

namespace EsercizioS7L1.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cognome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
