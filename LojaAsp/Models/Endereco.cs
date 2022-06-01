using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LojaAsp.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite um nome ")]
        public string Estado { get; set; }
        [StringLength(30, ErrorMessage ="Digite uma Categoria")]
        public string Cidade { get; set; }
        [Range(0,1500, ErrorMessage ="Digite um valor entre 0 e 1.500")]
        public int Numero { get; set; }
        [JsonIgnore]
        public virtual Loja Loja { get; set; }
    }
}