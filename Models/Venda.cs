using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class Venda
{
    [Key]
    public int IDVenda { get; set; }

    public Requerente Requerente { get; set; }
    [ForeignKey("Requerente")]
    public int IDRequerente { get; set; }

    public Jazigo Jazigo { get; set; }
    [ForeignKey("Jazigo")]
    public int IDJazigo { get; set; }

    public double valor { get; set; }
}
