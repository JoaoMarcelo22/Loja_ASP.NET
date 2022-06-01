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
        public  virtual Endereco Endereco { get; set; }
        public int EnderecoID { get; set; }
        public virtual Gerente Gerente { get; set; }
        public int GerenteId { get; set; }
        
        
    }
}