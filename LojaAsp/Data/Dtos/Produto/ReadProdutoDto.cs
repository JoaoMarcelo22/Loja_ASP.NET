using System.ComponentModel.DataAnnotations;

namespace LojaAsp
{
    public class ReadProdutoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite um nome ")]
        public string Nome { get; set; }
        [StringLength(30, ErrorMessage ="Digite uma Categoria")]
        public string Categoria { get; set; }
        [Range(0,1500, ErrorMessage ="Digite um valor entre 0 e 1.500")]
        public double Preco { get; set; }
        public DateTime HoraDaConsulta {get;set;}
    }
}