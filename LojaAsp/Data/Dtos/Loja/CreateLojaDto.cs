using System.ComponentModel.DataAnnotations;

namespace LojaAsp
{
    public class CreateLojaDto
    {
        [Required(ErrorMessage ="Digite um nome ")]
        public string Nome { get; set; }

        public int EnderecoId {get; set;}
    }
}