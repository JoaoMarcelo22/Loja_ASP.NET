using System.ComponentModel.DataAnnotations;

namespace LojaAsp
{
    public class CreateEnderecoDto
    {
        [Required(ErrorMessage ="Digite um nome ")]
        public string Estado { get; set; }
        [StringLength(30, ErrorMessage ="Digite uma Categoria")]
        public string Cidade { get; set; }
        [Range(0,1500, ErrorMessage ="Digite um valor entre 0 e 1.500")]
        public int Numero { get; set; }
    }
}