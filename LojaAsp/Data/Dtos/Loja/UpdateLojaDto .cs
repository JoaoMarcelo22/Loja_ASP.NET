using System.ComponentModel.DataAnnotations;

namespace LojaAsp
{
    public class UpdateLojaDto
    {
        [Required(ErrorMessage ="Digite um nome ")]
        public string Nome { get; set; }
    }
}