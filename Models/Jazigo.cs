using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class Jazigo
{
    [Key]
    public int IDJazigo { get; set; }

    public Localizacao Localizacao { get; set; }
    [ForeignKey("Localizacao")]
    public int IDLocal { get; set; }

    [Required]
    public int NumEspacos { get; set; }
}