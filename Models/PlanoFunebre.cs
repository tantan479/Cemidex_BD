using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class PlanoFunebre
{
    [Key]
    public int IDPlano { get; set; }

    [StringLength(64)][Required]
    public string Nome{ get; set; }
    
    [StringLength(1024)][Required]
    public string Descricao { get; set; }

    public double Preco{ get; set; }
}