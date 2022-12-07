using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class PlanoFunebre
{
    [Key]
    public int IDPlano { get; set; }

    [StringLength(64)][Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Nome{ get; set; }
    
    [StringLength(1024)][Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Descricao { get; set; }

    public double Preco{ get; set; }
}