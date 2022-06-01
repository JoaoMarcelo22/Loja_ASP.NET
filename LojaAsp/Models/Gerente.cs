using System.ComponentModel.DataAnnotations;
using LojaAsp.Models;

namespace LojaAsp
{
    public class Gerente
    {
       [Key]
       [Required] 
       public int Id{get;set;}
       public string Nome{get;set;}
       public virtual List<Loja> Lojas{get;set;}
    }
}