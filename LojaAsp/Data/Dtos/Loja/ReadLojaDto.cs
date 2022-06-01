using System.ComponentModel.DataAnnotations;
using LojaAsp.Models;

namespace LojaAsp
{
    public class ReadLojaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite um nome ")]
        public string Nome { get; set; }
        public Endereco Endereco{get;set;}
    }
}