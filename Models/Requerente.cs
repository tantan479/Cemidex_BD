using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class Requerente
{
    [Key]
    public int IdRequerente { get; set; }

    [StringLength(11)][Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string CPF { get; set; }
    [StringLength(32)][Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Nome { get; set; }
    [StringLength(13)]
    public string Telefone { get; set; }
    [StringLength(256)][Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Email { get; set; }

    [StringLength(1024)]
    public string Endereco { get; set; }

    public PlanoFunebre PlanoFunebre{ get; set; }
    [ForeignKey("PlanoFunebre")]
    public int IdPlano{get; set;}
}
