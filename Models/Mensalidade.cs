using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class Mensalidade
{

    [Key]
    public int IDMensalidade { get; set; }
    public PlanoFunebre PlanoFunebre { get; set; }
    [ForeignKey("PlanoFunebre")]
    public int IDPlano { get; set; }
    [Required]
    public double valor { get; set; }
}
