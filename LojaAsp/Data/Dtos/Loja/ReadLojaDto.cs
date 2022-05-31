using System.ComponentModel.DataAnnotations;

namespace LojaAsp
{
    public class ReadLojaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite um nome ")]
        public string Nome { get; set; }
    }
}