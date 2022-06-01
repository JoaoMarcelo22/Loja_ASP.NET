using System.ComponentModel.DataAnnotations;

namespace LojaAsp.Models
{
    public class Loja
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite um nome ")]
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public int EnderecoID { get; set; }
        
        
    }
}